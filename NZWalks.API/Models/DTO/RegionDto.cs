using NZWalks.API.Models.Domain;
namespace NZWalks.API.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for Region
    /// </summary>
    public class RegionDto : BaseModel
    {
        /// <summary>
        /// Gets or sets the code of the region.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the URL of the region image.
        /// </summary>
        public string? RegionImageUrl { get; set; }
    }
}
