using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductServices.Services;
using ProductServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IUserViewService _userViewService;

        public SalesController(IUserViewService userViewService)
        {
            _userViewService = userViewService;

        }


        [HttpGet("searchQuery/{keyword}")]
        public IActionResult searchQuery(string keyword)
        {
            var response = _userViewService.searchQueryAsync(keyword);
            if (!response.Any())
            {
                return NotFound("No Result found");
            }
            else
                return Ok(response);
        }

        [HttpGet("cityWiseStats")]
        public IActionResult cityWiseStats()
        {
            var response = _userViewService.cityWiseStatsAsync();
            if (!response.Any())
            {
                return NotFound("No Result found");
            }
            else
                return Ok(response);
        }

        [HttpGet("salesStats")]
        public IActionResult salesStats()
        {
            var response = _userViewService.salesStatsAsync();
            if (!response.Any())
            {
                return NotFound("No Result found");
            }
            else
                return Ok(response);
        }

        [HttpGet("pendingOrders")]
        public IActionResult pendingOrders()
        {
            var response = _userViewService.pendingOrdersAsync();
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound("No Result found");
            }
          
               
        }
    }
}
