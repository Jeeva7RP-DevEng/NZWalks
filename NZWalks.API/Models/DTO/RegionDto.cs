using NZWalks.API.Models.Domain;
namespace NZWalks.API.Models.DTO
{
    public class RegionDto : Models.Domain.BaseModel
    {
        public string Code { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
