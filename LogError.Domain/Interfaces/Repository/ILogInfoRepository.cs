using LogError.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogError.Domain.Interfaces.Repository
{
    public interface ILogInfoRepository
    {
        Task<LogInfo> SaveAsync(LogInfo logInfo);
        Task<LogInfo> GetLogInfoAsync(Guid guid);
        Task DeleteAsync(LogInfo logInfo);
        Task<List<LogInfo>> LogInfosAsync();
    }
}
