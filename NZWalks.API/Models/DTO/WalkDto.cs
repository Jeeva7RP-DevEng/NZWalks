using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for Walk entity.
    /// </summary>
    public class WalkDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the walk.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the walk.
        /// </summary>
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
        /// Gets or sets the region information of the walk.
        /// </summary>
        public RegionDto Region { get; set; }

        /// <summary>
        /// Gets or sets the difficulty information of the walk.
        /// </summary>
        public DifficultyDto Difficulty { get; set; }
    }
}
