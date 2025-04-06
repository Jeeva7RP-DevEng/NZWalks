using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using Microsoft.SqlServer.Server;
using NZWalks.API.Models.DTO;
using AutoMapper;
using NZWalks.API.Repositoties;
using NZWalks.API.CustomActionFilters;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="WalksController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper instance.</param>
        /// <param name="walkRepository">The walk repository instance.</param>
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        /// <summary>
        /// Creates a new walk.
        /// </summary>
        /// <param name="addWalkRequestDto">The walk details to add.</param>
        /// <returns>The created walk details.</returns>
        [HttpPost]
        [ValidateModelAttribute]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            // Map Domain model to DTO
            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }

        /// <summary>
        /// Gets all walks.
        /// </summary>
        /// <returns>A list of all walks.</returns>
        [HttpGet]
        [ValidateModelAttribute]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var walkDomainModels = await walkRepository.GetAllAsync();
                return Ok(mapper.Map<List<WalkDto>>(walkDomainModels));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Gets a walk by its ID.
        /// </summary>
        /// <param name="id">The ID of the walk.</param>
        /// <returns>The walk details.</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalksById([FromRoute] Guid id)
        {
            var walksDomainModel = await walkRepository.GetWalksByIdAsync(id);
            if (walksDomainModel == null)
            {
                return NotFound();
            }
            // Map Domain to DTO
            return Ok(mapper.Map<WalkDto>(walksDomainModel));
        }

        /// <summary>
        /// Updates an existing walk.
        /// </summary>
        /// <param name="id">The ID of the walk to update.</param>
        /// <param name="updateWalkRequestDto">The updated walk details.</param>
        /// <returns>The updated walk details.</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModelAttribute]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        { // Map DTO to Domain
            var updatedWalksModel = mapper.Map<Walk>(updateWalkRequestDto);
            updatedWalksModel = await walkRepository.UpdateWalkAsync(id, updatedWalksModel);
            if (updatedWalksModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(updatedWalksModel));
        }

        /// <summary>
        /// Deletes a walk by its ID.
        /// </summary>
        /// <param name="id">The ID of the walk to delete.</param>
        /// <returns>The deleted walk details.</returns>
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await walkRepository.DeleteAsync(id);
            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            //Map Model to DTO
            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));

        }
    }
}
