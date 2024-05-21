﻿using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ItemsService.ItemsServiceInfrastructure.Repositories;

public class WeaponsItemsRepository(ItemsDbContext dbContext) : IGenericItemsRepository<Weapon>
{
    public async Task<IEnumerable<Weapon>> GetAllAsync()
    {
        var weapons = await dbContext.Weapons
            .Include(w => w.SpecialEffects)
            .ToListAsync();

        return weapons;
    }

    public async Task<IEnumerable<Weapon>> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber)
    {
        var lowerSearchPhrase = searchPhrase?.ToLower();

        var weapons = await dbContext.Weapons
            .Include(w => w.SpecialEffects)
            .Where(w => lowerSearchPhrase == null || (w.Name.ToLower().Contains(lowerSearchPhrase) ||
                                                      w.WeaponType.ToLower().Contains(lowerSearchPhrase)))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return weapons;
    }

    public async Task<Weapon?> GetByIdAsync(int id)
    {
        var weapon = await dbContext.Weapons
            .Include(w => w.SpecialEffects)
            .FirstOrDefaultAsync(w => w.Id == id);

        return weapon;
    }

    public async Task<int> CreateAsync(Weapon entity)
    {
        dbContext.Weapons.Add(entity);
        await dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public Task DeleteAsync(Weapon entity)
    {
        dbContext.Remove(entity);
        return dbContext.SaveChangesAsync();
    }


    public Task SaveChangesAsync()
    {
        return dbContext.SaveChangesAsync();
    }
}