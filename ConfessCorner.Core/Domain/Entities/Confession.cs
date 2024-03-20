using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfessCorner.Core.Domain.Entities
{
    public class Confession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ConfessionId { get; set; }

        [StringLength(60)]
        public string? Header { get; set; }

        [StringLength(1000)]
        public string? Content { get; set; }

        [StringLength(20)]
        public string? Author { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? CreatedOn { get; set; }

        public virtual List<Comment>? Comments { get; set; }
    }
}
