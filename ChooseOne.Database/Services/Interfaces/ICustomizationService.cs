using ChooseOne.Core.Domain.Entities;
using ChooseOne.Database.Services.Interfaces.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ChooseOne.Database.Services.Interfaces
{
    public interface ICustomizationService : IGenericService<Customization>
    {
        Task<ObservableCollection<Customization>> GetAllInObsCollectionAsync();

        Task<ObservableCollection<Customization>> GetLast3Async();

    }
}
