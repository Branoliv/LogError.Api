using LogError.Domain.Entities;
using LogError.Domain.Interfaces.Repository;
using LogError.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogError.Infra.Repositories
{
    public class LogInfoRepository : ILogInfoRepository
    {
        private readonly LogErrorContext _context;

        public LogInfoRepository(LogErrorContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(LogInfo logInfo)
        {
            return Task.FromResult(_context.LogInfos.Remove(logInfo));
        }

        public async Task<LogInfo> GetLogInfoAsync(Guid guid)
        {
            return await _context.LogInfos
                .Include(x => x.LogDetails)
                .Where(x => x.Id == guid)
                .FirstOrDefaultAsync();
        }

        public async Task<List<LogInfo>> LogInfosAsync()
        {
            return await _context.LogInfos
                .Include(x => x.LogDetails)
                .ToListAsync();
        }

        public async Task<LogInfo> SaveAsync(LogInfo logInfo)
        {
            var _logInfo = await _context.LogInfos.AddAsync(logInfo);

            if (_logInfo.State.Equals(EntityState.Added))
                _context.SaveChangesAsync().Wait();

            return _logInfo.Entity;
        }
    }
}
