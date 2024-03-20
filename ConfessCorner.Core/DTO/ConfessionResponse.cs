namespace ConfessCorner.Core.DTO
{
    public class ConfessionResponse
    {
        public Guid ConfessionId { get; set; }

        public string? Header { get; set; }

        public string? Content { get; set; }

        public string? Author { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
