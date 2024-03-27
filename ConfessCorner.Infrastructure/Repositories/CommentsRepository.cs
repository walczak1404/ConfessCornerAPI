using ConfessCorner.Core.Domain.Entities;
using ConfessCorner.Core.Domain.RepositoryContracts;
using ConfessCorner.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfessCorner.Infrastructure.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly AppDbContext _db;

        public CommentsRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Comment>> GetCommentsforConfession(Guid confessionId)
        {
            return await _db.Comments.Where(comm => comm.ConfessionId == confessionId).OrderByDescending(comm => comm.CreatedOn).ToListAsync();
        }

        public async Task<int> GetCommentsAmountForConfession(Guid confessionId)
        {
            return await _db.Comments.CountAsync(comm => comm.ConfessionId == confessionId);
        }

        public async Task<Comment> PostComment(Comment comment)
        {
            _db.Comments.Add(comment);

            if (await _db.SaveChangesAsync() != 0) return comment;
            else throw new DbUpdateException("Cannot add comment to database");
        }
    }
}
