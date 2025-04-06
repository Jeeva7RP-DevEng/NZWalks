using System.ComponentModel.DataAnnotations;

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
        [Required]
        [MinLength(3, ErrorMessage = "Name has to be Minimum of 3 character")]
        public string Name { get; set; }
    }
}
