using Fridge.Repository.Context;
using Fridge.Service.Interfaces;
using Fridge.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fridge.Repository.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly FridgeDbContext Database;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(FridgeDbContext database)
        {
            Database = database;
            DbSet = database.Set<TEntity>();
        }

        public async Task<int> SaveChanges()
        {
            return await Database.SaveChangesAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChanges();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            Database?.Dispose();
        }
    }
}
