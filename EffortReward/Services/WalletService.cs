using EffortReward.Data;
using EffortReward.Data.Dto.incoming;
using EffortReward.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EffortReward.Services;

public class WalletService
{
    private readonly DatabaseContext _dbContext;

    public WalletService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Wallet[]> FindAll()
    {
        return await _dbContext.Wallet.ToArrayAsync();
    }

    public async Task<Wallet?> FindOne(int id)
    {
        return await _dbContext.Wallet.FindAsync(id);
    }
    
    public async Task<int> StoreOne(CreateWalletDto walletDto)
    {
        var walletEntity = new Wallet(walletDto.Points, walletDto.UserId, DateTime.UtcNow);
        _dbContext.Add(walletEntity);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateOne(Wallet wallet)
    {
        wallet.LastUpdate = DateTime.UtcNow;
        _dbContext.Wallet.Entry(wallet).State = EntityState.Modified;

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DestroyOne(Wallet wallet)
    {
        _dbContext.Remove(wallet);

        return await _dbContext.SaveChangesAsync();
    }

    public bool IsWalletExisting(int id)
    {
        return _dbContext.Wallet.Any(item => item.Id == id);
    }

}