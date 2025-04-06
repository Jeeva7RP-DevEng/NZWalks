using NZWalks.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    /// <summary>
    /// DTO for adding a new walk.
    /// </summary>
    public class AddWalkRequestDto
    {
        /// <summary>
        /// Gets or sets the name of the walk.
        /// </summary>
        [Required]
        [MinLength(3, ErrorMessage = "Name has to be Minimum of 3 character")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the walk.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the length of the walk in kilometers.
        /// </summary>
        public double LengthInkm { get; set; }

        /// <summary>
        /// Gets or sets the URL of the walk image.
        /// </summary>
        public string? WalkImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the difficulty ID of the walk.
        /// </summary>
        public Guid DifficultyId { get; set; }

        /// <summary>
        /// Gets or sets the region ID of the walk.
        /// </summary>
        public Guid RegionId { get; set; }
    }
}
