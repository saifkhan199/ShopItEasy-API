using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.ViewModel;
using UserService.Service.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using UserService.Model;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]

    public class UserMgmtController : ControllerBase
    {
        private readonly IUserService _userService;
        private IMemoryCache _cache;

        public UserMgmtController(IMemoryCache cache, IUserService userService)
        {
            _userService = userService;
            _cache = cache;
        }


        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> POST(UserViewModel user)
        {

            if (user == null)
            {
                return BadRequest("Bad Request");
            }
            else
            {
                user.isAdmin = false;
                User response = await _userService.AddUserAsync(user);
                if (response.Email != null)
                    return Ok("AccountCreated");

                else
                    return Ok("UserAlreadyExists");


            }


        }
        [HttpPost("changePassword")]

        public async Task<IActionResult> changePassword(ChangePasswordViewModel chP)
        {

            if (chP == null)
            {
                return BadRequest("Bad Request");
            }
            else if (_cache.Get("resetCode") == null)
            {
                return BadRequest("Invalid reset code !");
            }
            else
            {
                try
                {
                    var response = await _userService.ChangePassAsync(chP);
                    _cache.Remove("resetCode");
                    return Ok("Password Has been changed !");
                }
                catch (Exception ex)
                {
                    _cache.Remove("resetCode");
                    return BadRequest("Account not found !");
                }

            }
        }

        [HttpGet]
        public string GetToken()
        {
            string key = "SuperSecret@12345678910"; //Secret key which will be used later during validation    
            var issuer = "https://localhost:5001";  //normally this will be your site URL
            var Audience = "https://localhost:5001";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Create Security Token object by giving required parameters which we set on startup    
            var tokenOptions = new JwtSecurityToken(
                            issuer, //Issure    
                            Audience,  //Audience    
                            claims: new List<Claim>(),
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);

            var jwt_token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);


            return jwt_token;

        }

        [Authorize]
        [HttpPost("getname")]
        public Object GetName2()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var email = claims.Where(p => p.Type == "email").FirstOrDefault()?.Value;
                var password = claims.Where(p => p.Type == "password").FirstOrDefault()?.Value;
                return new
                {
                    mail = email,
                    pass = password
                };

            }
            return null;
        }
        [HttpPost("getname1")]
        public String GetName1()
        {

            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                }
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUserViewModel user)
        {

            try
            {

                if (user == null)
                {
                    return BadRequest("No Data Entered!");
                }
                else
                {
                    var result = await _userService.GetUsersByIdAsync(user);
                    if (result != null)
                    {
                        var Token = GetToken();
                        if (Token != null)
                        {


                            return Ok(new { Token = Token, Result = result });

                        }


                    }
                    return NoContent();

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        [HttpGet("GetAllCustomers")]
        public async Task<List<User>> GetAllCustomers()
        {

            try
            {

                var result = await _userService.GetAllCustomersAsync();
                return result;


            }


            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}
