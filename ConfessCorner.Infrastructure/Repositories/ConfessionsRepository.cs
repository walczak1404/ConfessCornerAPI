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
    public class ConfessionsRepository : IConfessionsRepository
    {
        private readonly AppDbContext _db;

        public ConfessionsRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Confession>> GetConfessions(int pageNumber)
        {
            IEnumerable<Confession> confessions = await _db.Confessions.OrderByDescending(c => c.CreatedOn).Skip((pageNumber - 1) * 10).Take(10).ToListAsync();

            return confessions;
        }

        public async Task<Confession?> GetConfessionById(Guid confessionId)
        {
            Confession? confession = await _db.Confessions.FirstOrDefaultAsync(c => c.ConfessionId == confessionId);

            return confession;
        }

        public async Task<Confession> PostConfession(Confession confession)
        {
            _db.Add(confession);

            if (await _db.SaveChangesAsync() == 0) throw new DbUpdateException("Cannot add confession to database");

            return confession;
        }
    }
}
