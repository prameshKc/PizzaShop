﻿using Application.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Infrastructure.Persistence
{
    public class EfCoreGenericRepository<TEntity>:IEfCoreGeneric<TEntity> where TEntity : class
    {
        private readonly AppDbContext _dbContext;

        public EfCoreGenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }
        public async Task<TEntity> GetById(int id)
        {
            return  await _dbContext.Set<TEntity>()
                        .FindAsync(id);
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<IEnumerable<TEntity>> Filter(Func<TEntity, bool> predicate)
        {
            return Task.FromResult(_dbContext.Set<TEntity>().Where(predicate));
        }
    }
}
