﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Mappings;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Log;
using NZWalks.API.Repositoties;
using System.Collections.Generic;

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
        private readonly IMapper mapper;
        List<Log> log = new List<Log>();


        public RegionsController(NZWalksDbContext nZWalksDbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = nZWalksDbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
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

                return Ok(mapper.Map<List<RegionDto>>(regionDomains));
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
                //Get regionbyid uisng Domain model
                var region = await regionRepository.GetById(id);

                if (region == null)
                {
                    return NotFound($"Given region id : {id} NOT found");
                }

                //Mapping DTOs to Model using Auto map
                var regionDto = (mapper.Map<RegionDto>(region));
                return Ok(regionDto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
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

                //Mapping DTOs to Model using Auto map
                return Ok(mapper.Map<RegionDto>(regionDomainModel));

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

                //Mapping DTOs to Model using Auto map
                return Ok(mapper.Map<RegionDto>(regionDomainModel));
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
            var regionDomainModel = await regionRepository.DeleteRegionAsyn(id);
            if (regionDomainModel == null)
            {
                return NotFound($"No Id : {id} Found");
            }
            //Mapping DTOs to Model using Auto map
            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }

    }
}
