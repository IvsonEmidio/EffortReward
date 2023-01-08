using EffortReward.Data.Entities;
using EffortReward.Models;
using Microsoft.EntityFrameworkCore;


namespace EffortReward.Services;

public class EffortService
{
    private readonly DatabaseContext _context;

    public EffortService(DatabaseContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<List<Effort>> FindAll()
    {
        return await _context.Effort.Where(effort => effort.Status == Effort.EffortStatus.ENABLED).ToListAsync();
    }

    public async Task<Effort?> FindOne(int id)
    {
        return await _context.Effort.FindAsync(id);
    }

    public async Task<bool> StoreOne(Effort effort)
    {
        _context.Add(effort);

        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> UpdateOne(Effort effort)
    {
        _context.Effort.Entry(effort).State = EntityState.Modified;
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> DeleteOne(Effort effort)
    {
        _context.Remove(effort);
        return await _context.SaveChangesAsync() == 1;
    }

    public bool IsEffortExisting(int id)
    {
        return (_context.Effort?.Any(item => item.Id == id)).GetValueOrDefault();
    }
}