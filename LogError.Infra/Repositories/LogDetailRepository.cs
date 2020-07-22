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
    public class LogDetailRepository : ILogDetailRepository
    {
        private readonly LogErrorContext _context;

        public LogDetailRepository(LogErrorContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(LogDetail logDetail)
        {
            return Task.FromResult(_context.LogDetails.Remove(logDetail));
        }

        public async Task<LogDetail> GetLogDetailAsync(Guid logDetailId)
        {
            return await _context.LogDetails
                .Where(x => x.Id == logDetailId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<LogDetail>> LogDetailsAsync(Guid logInfoId)
        {
            return await _context.LogDetails
                .Where(x => x.LogInfo.Id == logInfoId)
                .ToListAsync();
        }

        public async Task<LogDetail> SaveAsync(LogDetail logDetail)
        {
            var _logDetail = await _context.LogDetails
                .AddAsync(logDetail);

            if (_logDetail.State.Equals(EntityState.Added))
                _context.SaveChangesAsync().Wait();

            return _logDetail.Entity;
        }
    }
}
