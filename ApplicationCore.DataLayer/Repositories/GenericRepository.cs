﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.DataLayer.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.DataLayer.Repositories
{
    public class GenericRepository<T> : RepositoryBase, IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationCoreContext pContext) : base(pContext)
        {
            this._dbSet = _dbContext.Set<T>();
        }

        #region Add
        public async Task AddAsync(T entity)
        {
            var DateProperty = entity.GetType().GetProperty("CreateDate");
            if (DateProperty != null)
                DateProperty.SetValue(entity, DateTime.Now);
            await _dbSet.AddAsync(entity);
        }

        public async Task AddIfNotExists(Expression<Func<T, bool>> predicate, T entity)
        {
            await AddIfNotExists(predicate, () => entity);
        }

        public async Task AddIfNotExists(Expression<Func<T, bool>> predicate, Func<T> entity)
        {
            if (await GetAsync(predicate) == null)
                await AddAsync(entity.Invoke());
        }
        #endregion

        #region Update
        public void Update(T entity)
        {
            var DateProperty = entity.GetType().GetProperty("UpdateDate");
            if (DateProperty != null)
                DateProperty.SetValue(entity, DateTime.Now);

            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        #endregion

        #region Delete
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task Delete(int id)
        {
            _dbSet.Remove(await FindAsync(id));
        }
        #endregion

        #region Get
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).SingleOrDefaultAsync();
        }

        public async Task<T> FindAsync(params object[] keyValue)
        {
            return await _dbSet.FindAsync(keyValue);
        }
        #endregion

        #region GetAll
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        #endregion
    }
}
