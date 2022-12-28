using EffortReward.Data.Entities;
using EffortReward.Models;
using Microsoft.EntityFrameworkCore;

namespace EffortReward.Services
{
    public class WeeklyHistoricalService
    {
        private readonly WeeklyHistoryContext _context;
        public WeeklyHistoricalService(WeeklyHistoryContext context)
        {
            _context = context;
        }
        public async Task<List<WeeklyHistory>> All() { 
            return await this._context.WeeklyHistory.ToListAsync();
        }

        public async Task<WeeklyHistory?> FindOne(int id)
        {
            var history = await this._context.WeeklyHistory.FindAsync(id);
            
            if (history == null)
            {
                return null;
            }

            return history;
        }
    }
}
