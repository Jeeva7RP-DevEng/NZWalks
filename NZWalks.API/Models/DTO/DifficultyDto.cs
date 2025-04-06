namespace NZWalks.API.Models.DTO
{
    /// <summary>
    /// Represents the difficulty level of a walk.
    /// </summary>
    public class DifficultyDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the difficulty.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the difficulty level.
        /// </summary>
        public string Name { get; set; }
    }
}
