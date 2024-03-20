using System.ComponentModel.DataAnnotations;

namespace ConfessCorner.Core.DTO
{
    public class ConfessionAddRequest
    {
        [Required]
        [StringLength(60)]
        public string? Header { get; set; }

        [Required]
        [StringLength(1000)]
        public string? Content { get; set; }

        [StringLength(20)]
        public string? Author { get; set; }

    }
}
