using Certificit.DAL.Entities;
using Certificit.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.BLL.Repostiories
{
    public class GenaricRepository<TEntity> : IGenaricInterface<TEntity> where TEntity : class
    {
        public RSCContext _RSCContext { get; }

        public GenaricRepository(RSCContext RSCContext)
        {
            this._RSCContext = RSCContext;
        }


        public async Task<int> AddAsync(TEntity obj)
        {
            await _RSCContext.Set<TEntity>().AddAsync(obj);
            return await _RSCContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(TEntity obj)
        {
             _RSCContext.Set<TEntity>().Remove(obj);
            return await _RSCContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        => await _RSCContext.Set<TEntity>().ToListAsync();

        public async Task<int> UpdateAsync(TEntity obj)
        {
             _RSCContext.Set<TEntity>().Update(obj);
            return await _RSCContext.SaveChangesAsync();
        }

        public async Task<TEntity?> GetById(int Id)
        {
           return await _RSCContext.Set<TEntity>().FindAsync(Id);
        }

  
        public async Task<int> AddRangeAsync(List<TEntity> obj)
        {
            await _RSCContext.Set<TEntity>().AddRangeAsync(obj);
            return await _RSCContext.SaveChangesAsync();
        }

        public async Task<int> DeleteRangeAsync(List<TEntity> obj)
        {
             _RSCContext.Set<TEntity>().RemoveRange(obj);
            return await _RSCContext.SaveChangesAsync();
        }

    }
}
