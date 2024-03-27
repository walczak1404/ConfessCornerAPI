using ConfessCorner.Core.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

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

        public Comment ToComment()
        {
            return new Comment()
            {
                Author = Author,
                Content = Content,
                ConfessionId = ConfessionId
            };
        }
    }
}
