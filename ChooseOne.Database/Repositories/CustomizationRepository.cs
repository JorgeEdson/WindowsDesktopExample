using ChooseOne.Core.Domain.Entities;
using ChooseOne.Database.Repositories.Base;
using ChooseOne.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseOne.Database.Repositories
{
    public class CustomizationRepository : GenericRepository<Customization>, ICustomizationRepository
    {
        public async Task<ObservableCollection<Customization>> GetAllInObsCollectionAsync()
        {
            var list = await _dbSet.ToListAsync();
            var collection = new ObservableCollection<Customization>(list);
            return collection;
        }

        public async Task<ObservableCollection<Customization>> GetLast3InObsCollectionAsync()
        {
            var list = _dbSet.OrderByDescending(x => x.CreationDate).Take(3);
            var collection = new ObservableCollection<Customization>(list);
            return collection;
        }
    }
}
