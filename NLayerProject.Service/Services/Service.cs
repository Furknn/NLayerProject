using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.Service;
using NLayerProject.Core.UnitOfWorks;

namespace NLayerProject.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        public readonly IUnitOfWork UnitOfWork;

        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            UnitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.Where(predicate);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await UnitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);
            await UnitOfWork.CommitAsync();
            return entities;
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            UnitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            UnitOfWork.Commit();
        }

        public TEntity Update(TEntity entity)
        {
            var updateEntity = _repository.Update(entity);
            UnitOfWork.Commit();
            return updateEntity;
        }
    }
}