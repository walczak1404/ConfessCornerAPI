using ConfessCorner.Core.Domain.Entities;
using ConfessCorner.Core.Domain.RepositoryContracts;
using ConfessCorner.Core.DTO;
using ConfessCorner.Core.ServiceContracts;
using ConfessCorner.Core.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfessCorner.Core.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly IConfessionsRepository _confessions;
        private readonly ICommentsRepository _comments;

        public CommentsService(IConfessionsRepository confessionsRepository, ICommentsRepository commentsRepository)
        {
            _confessions = confessionsRepository;
            _comments = commentsRepository;
        }

        public async Task<IEnumerable<CommentResponse>> GetCommentsforConfession(Guid? confessionId)
        {
            if(confessionId == null) throw new ArgumentNullException(nameof(confessionId));

            if (_confessions.GetConfessionById(confessionId.Value) == null) throw new ArgumentException("Post not found");

            IEnumerable<Comment> comments = await _comments.GetCommentsforConfession(confessionId.Value);

            return comments.Select(comm => comm.ToCommentResponse());
        }

        public async Task<int> GetCommentsAmountforConfession(Guid? confessionId)
        {
            if(confessionId == null) throw new ArgumentNullException(nameof(confessionId));

            if (_confessions.GetConfessionById(confessionId.Value) == null) throw new ArgumentException("Post not found");

            return await _comments.GetCommentsAmountForConfession(confessionId.Value);
        }

        public async Task<CommentResponse> PostComment(CommentAddRequest commentAddRequest)
        {
            Validation.Validate(commentAddRequest);

            Comment addedComment = await _comments.PostComment(commentAddRequest.ToComment());

            return addedComment.ToCommentResponse();
        }
    }
}
