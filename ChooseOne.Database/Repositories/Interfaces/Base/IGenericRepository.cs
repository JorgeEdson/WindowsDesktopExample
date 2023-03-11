using ChooseOne.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseOne.Database.Repositories.Interfaces.Base
{
    public interface IGenericRepository<T> : IDisposable where T : Entity
    {
        Task AddAsync(T obj);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task UpdateAsync(T obj);
        Task RemoveAsync(T obj);
        Task RemoveByIdAsync(int id);
    }
}
