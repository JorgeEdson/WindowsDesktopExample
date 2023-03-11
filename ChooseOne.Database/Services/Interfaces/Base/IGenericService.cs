using ChooseOne.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseOne.Database.Services.Interfaces.Base
{
    public interface IGenericService<T> : IDisposable where T : Entity
    {
        Task AddAsync(T obj);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T obj);
        Task RemoveAsync(T obj);        
    }
}
