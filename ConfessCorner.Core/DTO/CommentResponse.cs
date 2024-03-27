using ConfessCorner.Core.Domain.Entities;
using System;

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

    public static class CommentExtensions
    {
        public static CommentResponse ToCommentResponse(this Comment comment)
        {
            return new CommentResponse()
            {
                CommentId = comment.CommentId,
                Author = comment.Author,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                ConfessionId = comment.ConfessionId
            };
        }
    }
}
