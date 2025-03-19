using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using Microsoft.SqlServer.Server;
using NZWalks.API.Models.DTO;
using AutoMapper;
using NZWalks.API.Repositoties;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        // CREATE Walks
        //POST : /api/walks

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map DTO  model to  Domain
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);
            
            await walkRepository.CreateAsync(walkDomainModel);

            //Map Domain model to DTO
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
    }
}
