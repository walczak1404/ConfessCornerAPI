using ConfessCorner.Core.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfessCorner.Core.ServiceContracts
{
    public interface ICommentsService
    {
        Task<IEnumerable<CommentResponse>> GetCommentsforConfession(Guid? confessionId);

        Task<int> GetCommentsAmountforConfession(Guid? confessionId);

        Task<CommentResponse> PostComment(CommentAddRequest commentAddRequest);
    }
}
