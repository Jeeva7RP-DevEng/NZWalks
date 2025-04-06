using NZWalks.API.Models.Domain;
namespace NZWalks.API.Models.DTO
{
    /// <summary>
    /// DTO for adding a new region.
    /// </summary>
    public class AddRegionRequestDto
    {
        /// <summary>
        /// Gets or sets the name of the region.
        /// </summary>
        public string Name { get; set; }

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
