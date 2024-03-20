using System.ComponentModel.DataAnnotations;

namespace ConfessCorner.Core.DTO
{
    public class CommentAddRequest
    {
        [StringLength(20)]
        public string? Author { get; set; }

        [Required]
        [StringLength(200)]
        public string? Content { get; set; }

        [Required]
        public Guid? ConfessionId { get; set; }
    }
}
