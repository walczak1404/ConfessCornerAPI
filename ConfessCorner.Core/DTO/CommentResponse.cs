namespace ConfessCorner.Core.DTO
{
    public class CommentResponse
    {
        public Guid CommentId { get; set; }

        public string? Author { get; set; }

        public string? Content { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ConfessionId { get; set; }
    }
}
