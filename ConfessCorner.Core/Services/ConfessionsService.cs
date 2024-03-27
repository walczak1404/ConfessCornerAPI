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
    public class ConfessionsService : IConfessionsService
    {
        private readonly IConfessionsRepository _confessions;

        public ConfessionsService(IConfessionsRepository confessionsRepository)
        {
            _confessions = confessionsRepository;
        }

        public async Task<IEnumerable<ConfessionResponse>> GetConfessions(int pageNumber)
        {
            IEnumerable<Confession> confessions = await _confessions.GetConfessions(pageNumber);

            return confessions.Select(c => c.ToConfessionResponse()).ToList();
        }

        public async Task<ConfessionResponse> GetConfessionById(Guid? confessionId)
        {
            if(confessionId == null) throw new ArgumentNullException(nameof(confessionId));

            Confession? confession = await _confessions.GetConfessionById(confessionId.Value);

            if (confession == null) throw new ArgumentException("Post not found");

            return confession.ToConfessionResponse();
        }

        public async Task<ConfessionResponse> PostConfession(ConfessionAddRequest confessionAddRequest)
        {
            Validation.Validate(confessionAddRequest);

            Confession postedConfession = await _confessions.PostConfession(confessionAddRequest.ToConfession());

            return postedConfession.ToConfessionResponse();
        }
    }
}
