using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
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

        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext nZWalksDbContext)
        {
            this.dbContext = nZWalksDbContext;
        }

        [HttpGet]

        /// <summary>
        /// GetAll method returns all
        /// </summary>
        public IActionResult GetAll()
        {
            var region = dbContext.Regions.ToList();
            return Ok(region);
        }

        // GET REGION BY ID

        [HttpGet]
        [Route("{id:guid}")]

        /// <summary>
        /// GetRegionById method returns a region by its id
        /// </summary>

        public IActionResult GetRegionById(Guid id)
        {
            try
            {
                //var region = dbContext.Regions.Find(id);
                var region = dbContext.Regions.FirstOrDefault(r => r.Id == id);
                if (region !=  null)
                {
                    return Ok(region);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

            return NotFound();
        }

        
    }
}
