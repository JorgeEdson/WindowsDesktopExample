using ChooseOne.Core.Domain.Base;
using ChooseOne.Database.Repositories.Interfaces.Base;
using ChooseOne.Database.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseOne.Database.Services.Base
{
    public abstract class GenericService<T> : IGenericService<T> where T : Entity
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task AddAsync(T obj)
        {
            await _repository.AddAsync(obj);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task UpdateAsync(T obj)
        {
            await _repository.UpdateAsync(obj);
        }

        public async Task RemoveAsync(T obj)
        {
            await _repository.RemoveAsync(obj);
        }        

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
