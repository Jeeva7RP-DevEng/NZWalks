namespace NZWalks.API.Models.Domain
{
    public class Walk : BaseModel
    {

        public string Description { get; set; }

        public double LengthInkm { get; set; }

        public string? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }

        public Difficulty Difficulty { get; set; }

        public Region Region { get; set; }
    }
}
