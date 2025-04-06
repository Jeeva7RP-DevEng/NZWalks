using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    /// <summary>
    /// DTO for updating a region.
    /// </summary>
    public class UpdateRegionRequestDto
    {
        /// <summary>
        /// Gets or sets the name of the region.
        /// </summary>
        [Required]
        [MinLength(3, ErrorMessage = "Name has to be Minimum of 3 character")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code of the region.
        /// </summary>
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be Minimum of 3 character")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the URL of the region image.
        /// </summary>
        public string? RegionImageUrl { get; set; }
    }
}
