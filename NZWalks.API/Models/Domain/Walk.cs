namespace NZWalks.API.Models.Domain
{
    /// <summary>
    /// Represents a walking trail with details such as description, length, difficulty, and region.
    /// </summary>
    public class Walk : BaseModel
    {
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
        /// Gets or sets the identifier for the difficulty level of the walk.
        /// </summary>
        public Guid DifficultyId { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the region of the walk.
        /// </summary>
        public Guid RegionId { get; set; }

        /// <summary>
        /// Gets or sets the difficulty level of the walk.
        /// </summary>
        public Difficulty Difficulty { get; set; }

        /// <summary>
        /// Gets or sets the region of the walk.
        /// </summary>
        public Region Region { get; set; }
    }
}
