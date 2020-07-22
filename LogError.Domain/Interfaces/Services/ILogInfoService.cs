using LogError.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LogError.Domain.Interfaces.Services
{
    public interface ILogInfoService : IServiceBase
    {
        LogInfo Save(LogInfo logInfo);
        LogInfo GetLogInfo(Guid GetLogInfoId);
        void Delete(LogInfo logInfo);
        List<LogInfo> LogInfos();
    }
}
