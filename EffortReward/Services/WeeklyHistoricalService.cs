using EffortReward.Data.Entities;
using EffortReward.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<List<WeeklyHistory>> All()
        {
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

        public async Task<ActionResult<int>> Store(WeeklyHistory history)
        {

            this._context.Add(history);
            return await this._context.SaveChangesAsync();

        }

        public async Task<ActionResult<int>> Update(WeeklyHistory history)
        {
            this._context.Entry(history).State= EntityState.Modified;
            return await this._context.SaveChangesAsync();
        }

        public bool IsHistoryExisting(int id)
        {
            return (this._context.WeeklyHistory?.Any(item => item.Id == id)).GetValueOrDefault();
        }
    }
}
