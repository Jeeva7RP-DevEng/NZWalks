using AutoMapper;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Mappings
{
    /// <summary>
    /// AutoMapper profile configuration for mapping between domain and DTO objects.
    /// </summary>
    public class AutoMapperProfiles : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfiles"/> class.
        /// Configures the mappings between domain and DTO objects.
        /// </summary>
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, RegionDto>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, RegionDto>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
        }
    }



    //uisng Custom MAPPING 
    //CreateMap<UserDTO, UserDomain>().ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName)).ReverseMap();


    //public class UserDTO
    //{ 
    //    public string FullName { get; set; }
    //}

    //public class UserDomain
    //{
    //    public string Name { get; set; }
    //}

}
