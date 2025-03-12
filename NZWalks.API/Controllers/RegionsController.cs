using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Log;

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
        List<Log> log = new List<Log>();

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
            try
            {
                //GET regions using  Domain model
                var regionDomains = dbContext.Regions.ToList();
                //GET regions using  DTOs Method
                var regionDto = new List<RegionDto>();
                foreach (var regiondomain in regionDomains)
                {
                    regionDto.Add(new RegionDto()
                    {
                        Id = regiondomain.Id,
                        Code = regiondomain.Code,
                        RegionImageUrl = regiondomain.RegionImageUrl
                    });
                }
                return Ok(regionDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET REGION BY ID

        [HttpGet]
        [Route("{id:guid}")]

        /// <summary>
        /// GetRegionById method returns a region by its id
        /// </summary>

        public IActionResult GetRegionById([FromRoute] Guid id)
        {
            try
            {
                //var region = dbContext.Regions.Find(id);
                //Get regionbyid uisng Domain model
                var region = dbContext.Regions.FirstOrDefault(r => r.Id == id);
                //Get region by id uisng DTOs
                if (region != null)
                {
                    var regionDto = new RegionDto
                    {
                        Id = region.Id,
                        Code = region.Code,
                        RegionImageUrl = region.RegionImageUrl,
                        Name = region.Name
                    };

                    return Ok(regionDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
            return Ok();
        }

        //POST Method for Regions 
        [HttpPost]

        /// <summary>
        /// Create method Add a new region
        /// </summary>

        public IActionResult Create([FromBody] AddRegionRequestDto addRegion)
        {
            try
            {
                //Map the DTO to Domain model
                var regionDomainModel = new Region
                {
                    Code = addRegion.Code,
                    RegionImageUrl = addRegion.RegionImageUrl,
                    Name = addRegion.Name
                };

                //Use Domain Model to create  the region into the database
                dbContext.Regions.Add(regionDomainModel);
                dbContext.SaveChanges();

                //Converting Model to DTO
                var regionDto = new RegionDto
                {
                    Id = regionDomainModel.Id,
                    Code = regionDomainModel.Code,
                    Name = regionDomainModel.Name,
                    RegionImageUrl = regionDomainModel.RegionImageUrl
                };

                //return the newly created region because it is a post method
                return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        //PUT Method for Update a Region

        [HttpPut]
        [Route("{id:guid}")]
        /// <summary>
        /// UpdateRegionById Method for Update a Region
        /// </summary>

        public IActionResult UpdateRegionById([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto regionRequest)
        {
            try
            {
                var regionDomain = dbContext.Regions.FirstOrDefault(r => r.Id == id);

                if (regionDomain == null)
                {
                    return NotFound();
                }

                regionDomain.Code = regionRequest.Code;
                regionDomain.Name = regionRequest.Name;
                regionDomain.RegionImageUrl = regionRequest.RegionImageUrl;
                dbContext.Regions.Update(regionDomain);
                dbContext.SaveChanges();

                // Convert DomainModel Values into Dto format
                var regionDto = new RegionDto
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl,
                };


                return Ok(regionDto);
            }
            catch (Exception ex)
            {
                log.Add(new Log { Message = ex.Message, LogType = "Error" });
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }

        //Delete Method for UpdDeleteate a Region

        [HttpDelete]
        [Route("{id:guid}")]

        /// <summary>
        /// DeleteById  Method for Update a Region
        /// </summary>

        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var regionDetails = dbContext.Regions.FirstOrDefault(r => r.Id == id);
            if (regionDetails == null)
            {
                return NotFound($"No Id : {id} Found");
            }

            dbContext.Regions.Remove(regionDetails);
            dbContext.SaveChanges();

            //return delete Region back optional.
            //Map Domain Model to DTO

            var regionDto = new RegionDto
            {
                Id = regionDetails.Id,
                Code = regionDetails.Code,
                Name = regionDetails.Name,
                RegionImageUrl = regionDetails.RegionImageUrl,
            };


            return Ok(regionDto);
        }

    }
}
