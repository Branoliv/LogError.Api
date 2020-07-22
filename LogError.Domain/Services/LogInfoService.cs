using LogError.Domain.Entities;
using LogError.Domain.Interfaces.Repository;
using LogError.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace LogError.Domain.Services
{
    public class LogInfoService : ILogInfoService
    {
        private readonly ILogInfoRepository _logInfoRepository;
        private readonly ILogDetailRepository _logDetailRepository;

        public LogInfoService(ILogInfoRepository logInfoRepository, ILogDetailRepository logDetailRepository)
        {
            _logInfoRepository = logInfoRepository;
            _logDetailRepository = logDetailRepository;
        }

        public void Delete(LogInfo logInfo)
        {
            var _logInfo = _logInfoRepository.GetLogInfoAsync(logInfo.Id).Result;

             _logInfoRepository.DeleteAsync(_logInfo);
        }

        public  LogInfo GetLogInfo(Guid GetLogInfoId)
        {
            if (GetLogInfoId == null)
            {
                return null;
            }

            return  _logInfoRepository.GetLogInfoAsync(GetLogInfoId).Result;
        }

        public List<LogInfo> LogInfos()
        {
            return _logInfoRepository.LogInfosAsync().Result;
        }

        public LogInfo Save(LogInfo logInfo)
        {
            if (logInfo == null)
            {
                return null;
            }

            var _logInfo = new LogInfo(

                title: logInfo.Title,
                level: logInfo.Level,
                tokenSource: logInfo.TokenSource,
                source: logInfo.Source);

            var respLogInfo = _logInfoRepository.SaveAsync(_logInfo).Result;

            var respLogDetail = new List<LogDetail>();
            
            foreach (var detail in logInfo.LogDetails)
            {
                var _logDetail = new LogDetail(detail.Detail, _logInfo);


               respLogDetail.Add( _logDetailRepository.SaveAsync(_logDetail).Result);
            }

            respLogInfo.LogDetails = respLogDetail;

            return respLogInfo;
        }
    }
}
