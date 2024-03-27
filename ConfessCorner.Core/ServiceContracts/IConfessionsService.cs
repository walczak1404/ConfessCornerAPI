using ConfessCorner.Core.Domain.Entities;
using ConfessCorner.Core.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfessCorner.Core.ServiceContracts
{
    public interface IConfessionsService
    {
        Task<IEnumerable<ConfessionResponse>> GetConfessions(int pageNumber);

        Task<ConfessionResponse> GetConfessionById(Guid? confessionId);

        Task<ConfessionResponse> PostConfession(ConfessionAddRequest confessionAddRequest);
    }
}
