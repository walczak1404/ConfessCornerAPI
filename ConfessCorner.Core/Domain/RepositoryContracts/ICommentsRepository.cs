using ConfessCorner.Core.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfessCorner.Core.Domain.RepositoryContracts
{
    public interface ICommentsRepository
    {
        Task<IEnumerable<Comment>> GetCommentsforConfession(Guid confessionId);

        Task<int> GetCommentsAmountForConfession(Guid confessionId);

        Task<Comment> PostComment(Comment comment);
    }
}
