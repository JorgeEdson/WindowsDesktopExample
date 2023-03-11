using ChooseOne.Core.Domain.Entities;
using ChooseOne.Core.Domain.Entities.Enuns;
using ChooseOne.Database.Repositories.Interfaces;
using ChooseOne.Database.Services.Base;
using ChooseOne.Database.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseOne.Database.Services
{
    public class CustomizationService : GenericService<Customization>, ICustomizationService
    {
        private readonly ICustomizationRepository _repository;

        public CustomizationService(ICustomizationRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task AddAsync(Customization customization) 
        {
            try
            {
                bool canAdd = false;
                canAdd = customization.Name == null ? false : true; 
                canAdd = customization.Content  == null ? false : true;
                if (customization.ChooseComponent == ChooseComponent.Slider) 
                { 
                    canAdd = customization.MinValue == null ? false : true;
                    canAdd = customization.MaxValue == null ? false : true;
                }

                if (customization.ChooseComponent == ChooseComponent.Dialog) 
                {
                    canAdd = customization.DialogButton1 == null ? false : true;
                }                

                if (!canAdd)
                    throw new Exception("Some required property was not filled");
                
                await _repository.AddAsync(customization);
            }
            catch (Exception ex) 
            {
                throw new Exception("Some required property was not filled", ex);
            }
        }        

        public override async Task UpdateAsync(Customization customization) 
        {
            try
            {
                bool canUpdate = false;
                canUpdate = customization.Name == null ? false : true;
                canUpdate = customization.Content == null ? false : true;
                if (customization.ChooseComponent == ChooseComponent.Slider)
                {
                    canUpdate = customization.MinValue == null ? false : true;
                    canUpdate = customization.MaxValue == null ? false : true;
                }

                if (customization.ChooseComponent == ChooseComponent.Dialog)
                {
                    canUpdate = customization.DialogButton1 == null ? false : true;
                }

                if (!canUpdate)
                    throw new Exception("Some required property was not filled");

                await _repository.UpdateAsync(customization);
            }
            catch (Exception ex)
            {
                throw new Exception("Some required property was not filled", ex);
            }
        }

        public async Task<ObservableCollection<Customization>> GetAllInObsCollectionAsync()
        {
            return await _repository.GetAllInObsCollectionAsync();
        }

        public async Task<ObservableCollection<Customization>> GetLast3Async()
        {
            return await _repository.GetLast3InObsCollectionAsync();
        }
    }
}
