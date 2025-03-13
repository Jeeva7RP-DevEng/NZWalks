using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Log;
using NZWalks.API.Repositoties;

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
        private readonly IRegionRepository regionRepository;
        List<Log> log = new List<Log>();


        public RegionsController(NZWalksDbContext nZWalksDbContext, IRegionRepository regionRepository)
        {
            this.dbContext = nZWalksDbContext;
            this.regionRepository = regionRepository;
        }

        [HttpGet]

        /// <summary>
        /// GetAll method returns all
        /// </summary>
        public async Task<IActionResult> GetAll()
        {
            try
            {
                //GET regions using  Domain model
                var regionDomains = await regionRepository.GetAllAsync();
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

        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            try
            {
                //var region = dbContext.Regions.Find(id);
                //Get regionbyid uisng Domain model
                var region = await regionRepository.GetById(id);
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
        /// Create method Create Regions and  returns regions
        /// </summary>

        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegion)
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

                //Use Domain Model to create the region into the database
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                if (regionDomainModel == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating the region");
                }

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
        public async Task<IActionResult> UpdateRegionById([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto regionRequest)
        {
            try
            {
                //update region Dto to Domain Model
                var regionDomainModel = new Region
                {
                    Code = regionRequest.Code,
                    Name = regionRequest.Name,
                    RegionImageUrl = regionRequest.RegionImageUrl
                };

                regionDomainModel = await regionRepository.UpdateRegionByIdAsync(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound($"Region with Id: {id} not found");
                }

                // Convert DomainModel Values into Dto format
                var regionDto = new RegionDto
                {
                    Id = regionDomainModel.Id,
                    Code = regionDomainModel.Code,
                    Name = regionDomainModel.Name,
                    RegionImageUrl = regionDomainModel.RegionImageUrl,
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

        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var regionDetails = await regionRepository.DeleteRegionAsyn(id);
            if (regionDetails == null)
            {
                return NotFound($"No Id : {id} Found");
            }

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
