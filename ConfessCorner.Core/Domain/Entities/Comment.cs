﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfessCorner.Core.Domain.Entities
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CommentId { get; set; }

        [StringLength(20)]
        public string? Author { get; set; }

        [StringLength(200)]
        public string? Content { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? CreatedOn { get; set; }

        public Guid? ConfessionId { get; set; }

        [ForeignKey(nameof(ConfessionId))]
        public virtual Confession? Confession { get; set; }
    }
}
