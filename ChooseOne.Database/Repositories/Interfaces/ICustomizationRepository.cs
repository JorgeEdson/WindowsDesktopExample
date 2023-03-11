using ChooseOne.Core.Domain.Entities;
using ChooseOne.Database.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseOne.Database.Repositories.Interfaces
{
    public interface ICustomizationRepository : IGenericRepository<Customization>
    {
        Task<ObservableCollection<Customization>> GetAllInObsCollectionAsync();

        Task<ObservableCollection<Customization>> GetLast3InObsCollectionAsync();
    }
}
