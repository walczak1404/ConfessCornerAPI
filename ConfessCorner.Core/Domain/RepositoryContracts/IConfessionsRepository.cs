using ConfessCorner.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfessCorner.Core.Domain.RepositoryContracts
{
    public interface IConfessionsRepository
    {
        Task<IEnumerable<Confession>> GetConfessions(int pageNumber);

        Task<Confession?> GetConfessionById(Guid confessionId);

        Task<Confession> PostConfession(Confession confession);
    }
}
