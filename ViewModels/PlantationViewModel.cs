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
    public class PlantationViewModel : ViewModelBase
    {
        private IPlantation _plantation;
        private string _name;
        private string _city;
        public PlantationViewModel(IPlantation plantation)
        {
            _plantation = plantation;
        }

        [Required(ErrorMessage = "Miasto jest wymagane")]
        public string City
        {
            get => _plantation.City;
            set => _plantation.City = value;
        }


        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Name
        {
            get => _plantation.Name;
            set => _plantation.Name = value;
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
