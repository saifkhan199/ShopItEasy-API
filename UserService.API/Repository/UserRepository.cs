using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserService.Model;
using UserService.Model.Repository;
using UserService.Repository.Interaface;
using UserService.ViewModel;

namespace UserService.Repository
{
     public class UserRepository : DataRepository<User>, IUserRepository
        {
            public UserRepository(UserContext context) : base(context)
            {
            }
           

        public async Task<LoginUserViewModel> GetUserByIdAsync(LoginUserViewModel user)
            {
            var uname = GetAll().Where(u => u.Email == user.Email);
            if (!uname.Any())
            {
                throw new Exception("User Not Found !");
            }
            else
            {
                string hash;
                using (MD5 md5Hash = MD5.Create())
                {
                    hash = GetMd5Hash(md5Hash, user.pass);

                }
               
                var selectedUser=uname.Where(u => u.pass == hash);

               
                if (selectedUser.Any())
                { 
                    var Adminrole = selectedUser.Select(u => u.isAdmin);
                    var u_name = selectedUser.Select(u => u.User_Name);
                    var u_id= selectedUser.Select(u => u.UserID);


                    if (Adminrole.ToList()[0].Equals(true)){
                        user.isAdmin = true;
                    }

                    user.User_Name = u_name.ToList()[0].ToString();
                    user.UserID = u_id.ToList()[0];
                    
                    return user;
                   
                }
                else
                {
                    throw new Exception("Password Do not Match!");
                }
            }

        }
        public async Task<User> ChangePassAsync(ChangePasswordViewModel chP)
        {
           
            string newPassHash;
            using (MD5 md5Hash = MD5.Create())
            {
                
                newPassHash = GetMd5Hash(md5Hash, chP.newPassword);
            }
           

            var uname = GetAll().Where(u => u.Email == chP.email);
            if (!uname.Any())
            {
                throw new Exception("User Not Found !");
            }
            else
            {
                var user = _context.Set<User>().FirstOrDefault(u => u.Email == chP.email);
                user.pass = newPassHash;
                await _context.SaveChangesAsync();
                return user;

            }
                
            
        }
        public async Task<List<string>> GetAllAdminEmailsAsync()
        {
            var users = _context.Users.Where(u => u.isAdmin == true).Select(e=>e.Email).ToList();
            return users;
        }

        //public string DecodeFrom64(string encodedData)
        //{
        //    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
        //    System.Text.Decoder utf8Decode = encoder.GetDecoder();
        //    byte[] todecode_byte = Convert.FromBase64String(encodedData);
        //    int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        //    char[] decoded_char = new char[charCount];
        //    utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        //    string result = new String(decoded_char);
        //    return result;
        //}
        //public static string EncodePasswordToBase64(string password)
        //{
        //    try
        //    {
        //        byte[] encData_byte = new byte[password.Length];
        //        encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
        //        string encodedData = Convert.ToBase64String(encData_byte);
        //        return encodedData;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error in base64Encode" + ex.Message);
        //    }
        //}
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }


        public Task<User> AddUserAsync(UserViewModel User)
            {

                Guid guid = Guid.NewGuid();

                User User_obj = new User();
                User_obj.UserID = guid;
                User_obj.User_Name = User.User_Name;
                User_obj.Country = User.Country;
                User_obj.Email = User.Email;
                User_obj.isAdmin = User.isAdmin;
                User_obj.Phone = User.Phone;
            
                string hash;
                using (MD5 md5Hash = MD5.Create())
                {
                    hash = GetMd5Hash(md5Hash, User.pass);
                    
                }
                 User_obj.pass = hash;


            try
                {

                    return AddAsync(User_obj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        public async Task<List<User>> GetAllCustomersAsync()
        {
            var users = await _context.Users.Where(u => !u.isAdmin).ToListAsync();
            return users;
        }
    }
    }

