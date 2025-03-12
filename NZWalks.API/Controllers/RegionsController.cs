using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers
{
    //https://localhost:portnumber/api/Regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        // GET ALL REGIONS
        // GET : https://localhost:portnumber/api/Regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var region = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://media.istockphoto.com/id/504712721/photo/auckland-dawn.jpg?s=1024x1024&w=is&k=20&c=MaJbOeSQv2qTAmRNBlCw3IynvEBVoCqAwMklhKmXw9U="
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Wellington Region",
                    Code = "WLG",
                    RegionImageUrl = "https://images.pexels.com/photos/17025916/pexels-photo-17025916/free-photo-of-early-morning-sunrise-in-the-city-center-of-zierikzee-zeeland-the-netherlands.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2"
                }
            };
            return Ok(region);
        }
    }
}
