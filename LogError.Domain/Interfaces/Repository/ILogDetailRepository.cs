using LogError.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogError.Domain.Interfaces.Repository
{
    public interface ILogDetailRepository
    {
        Task<LogDetail> SaveAsync(LogDetail logDetail);
        Task<LogDetail> GetLogDetailAsync(Guid logDetailId);
        Task<List<LogDetail>> LogDetailsAsync(Guid logInfoId);
        Task DeleteAsync(LogDetail logDetail);
    }
}
