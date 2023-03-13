using System.Runtime.InteropServices.JavaScript;
using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Domain.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CMSPlus.Domain.Repositories;

public class Repository<T> : IRepository<T> where T: BaseEntity
{
    public readonly ApplicationDbContext _context;
    protected IQueryable<T> _dbSet => _context.Set<T>();
    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity == null)
        {
            throw new ArgumentException();
        }
        return entity;
    }

    public async Task Create(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        entity.UpdatedOnUtc = DateTime.UtcNow;
        // _context.Update(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entityToRemove = await GetById(id);
        _context.Set<T>().Remove(entityToRemove);
        await _context.SaveChangesAsync();
    }
}