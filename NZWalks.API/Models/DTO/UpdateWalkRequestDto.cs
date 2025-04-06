using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    /// <summary>
    /// DTO for updating a walk.
    /// </summary>
    public class UpdateWalkRequestDto
    {
        /// <summary>
        /// Name of the walk.
        /// </summary>
        [Required]
        [MinLength(3, ErrorMessage = "Name has to be Minimum of 3 character")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the walk.
        /// </summary>
        [Required]
        [MinLength(3, ErrorMessage = "Name has to be Minimum of 3 character")]
        [MaxLength(1000, ErrorMessage = "Description Should be within of 1000 character")]
        public string Description { get; set; }

        /// <summary>
        /// Length of the walk in kilometers.
        /// </summary>
        public double LengthInkm { get; set; }

        /// <summary>
        /// URL of the walk image url.
        /// </summary>
        public string? WalkImageUrl { get; set; }

        /// <summary>
        /// ID of the difficulty level.
        /// </summary>
        public Guid DifficultyId { get; set; }

        /// <summary>
        /// ID of the region.
        /// </summary>
        public Guid RegionId { get; set; }
    }
}
