namespace NZWalks.API.Models.Domain
{
    /// <summary>
    /// Represents a region with a unique code and an optional image URL.
    /// </summary>
    public class Region : BaseModel
    {
        /// <summary>
        /// Gets or sets the unique code for the region.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the URL of the region's image.
        /// </summary>
        public string? RegionImageUrl { get; set; }
    }
}
