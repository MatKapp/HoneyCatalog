using Kapiszewski.HoneyCatalog.Interfaces;
using Kapiszewski.HoneyCatalog.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapiszewski.HoneyCatalog.ViewModels
{
    public class HoneyViewModel : ViewModelBase
    {
        private IHoney _honey;
        private int _productionYear;
        private ObservableCollection<IPlantation> _plantations;

        public HoneyViewModel(IHoney honey)
        {
            _honey = honey;
            BLC.DataProvider dataProvider = new BLC.DataProvider(new Settings().DataBase);
            _plantations = new ObservableCollection<IPlantation>(dataProvider.Plantations); 
        }

        public IPlantation Plantation
        {
            get => _honey.Plantation;
            set => _honey.Plantation = value;
        }

        [Required(ErrorMessage = "Typ miodu jest wymagany")]
        public Core.Honey HoneyType
        {
            get => _honey.HoneyType;
            set => _honey.HoneyType = value;
        }

        [Required(ErrorMessage = "Gatunek jest wymagany")]
        public string Species
        {
            get => _honey.Species;
            set => _honey.Species = value;
        }

        [Required(ErrorMessage = "Rok produkcji jest wymagany")]
        [Range(2016, 2018, ErrorMessage = "Błędna data")]
        public int ProductionYear
        {
            get => _honey.ProductionYear;
            set => _honey.ProductionYear = value;
        }

        public ObservableCollection<IPlantation> Plantations
        {
            get => _plantations;
        }

        public void Validate()
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this, validationContext, validationResults, true);

            foreach (var keyVal in _errors.ToList())
            {
                if (validationResults.All(result => result.MemberNames.All(member => member != keyVal.Key)))
                {
                    _errors.Remove(keyVal.Key);
                    RaiseErrorChanged(keyVal.Key);
                }
            }
            var q = from result in validationResults
                    from member in result.MemberNames
                    group result by member into g
                    select g;

            foreach (var prop in q)
            {
                var messages = prop.Select(result => result.ErrorMessage).ToList();

                if (_errors.ContainsKey(prop.Key))
                {
                    _errors.Remove(prop.Key);
                }
                _errors.Add(prop.Key, messages);
                RaiseErrorChanged(prop.Key);
            }
        }
    }
}
