using ConfessCorner.Core.Domain.Entities;
using System;

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

    public static class ConfessionExtensions
    {
        public static ConfessionResponse ToConfessionResponse(this Confession confession)
        {
            return new ConfessionResponse()
            {
                ConfessionId = confession.ConfessionId,
                Header = confession.Header,
                Content = confession.Content,
                Author = confession.Author,
                CreatedOn = confession.CreatedOn
            };
        }
    }
}
