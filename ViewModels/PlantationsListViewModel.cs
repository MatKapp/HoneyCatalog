using Kapiszewski.HoneyCatalog.DAOMock.BO;
using Kapiszewski.HoneyCatalog.Interfaces;
using Kapiszewski.HoneyCatalog.Properties;
using Kapiszewski.HoneyCatalog.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Data;

namespace ViewModels
{
    public class PlantationsListViewModel : ViewModelBase
    {
        public ObservableCollection<PlantationViewModel> Plantations { get; set; } = new ObservableCollection<PlantationViewModel>();

        private ListCollectionView _view;

        private PlantationViewModel _editedPlantation;

        private PlantationViewModel _selectedPlantation;

        public PlantationViewModel SelectedPlantation
        {
            get => _selectedPlantation;
            set
            {
                _selectedPlantation = value;
                EditedPlantation = value;
                OnPropertyChanged(nameof(EditedPlantation));
            }
        }
        public string FilterValue { get; set; }

        public PlantationsListViewModel()
        {
            OnPropertyChanged("Plantations");
            GetAllPlantations();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Plantations);
            _filterDataCommand = new RelayCommand(param => this.FilterData());
            _addNewPlantationCommand = new RelayCommand(param => this.AddNewPlantation(),
                                                param => this.CanAddNewPlantation());
            _savePlantationCommand = new RelayCommand(param => this.SavePlantation(),
                                                param => this.CanSavePlantation());
            _deletePlantationCommand = new RelayCommand(param => this.DeletePlantation());
        }

        private void DeletePlantation()
        {
            Plantations.Remove(Plantations.Where(x => x.Equals(SelectedPlantation)).Single());
        }

        private void GetAllPlantations()
        {
            Kapiszewski.HoneyCatalog.BLC.DataProvider dataProvider = new Kapiszewski.HoneyCatalog.BLC.DataProvider(new Settings().DataBase);
            foreach (var plantation in dataProvider.Plantations)
            {
                Plantations.Add(new PlantationViewModel(plantation));
            }
        }

        private void FilterData()
        {
            if (string.IsNullOrEmpty(FilterValue))
            {
                _view.Filter = null;
            }
            else
            {
                _view.Filter = (c) => ((PlantationViewModel)c).City.Contains(FilterValue);
            }
        }

        public PlantationViewModel EditedPlantation
        {
            get => _editedPlantation;
            set
            {
                _editedPlantation = value;
                OnPropertyChanged(nameof(EditedPlantation));
            }
        }

        private void AddNewPlantation()
        {
            EditedPlantation = new PlantationViewModel(new Kapiszewski.HoneyCatalog.DAOMock.BO.Plantation())
            {
                City = "",
                Name = ""
            };
        }

        private RelayCommand _savePlantationCommand;

        public RelayCommand SavePlantationCommand
        {
            get => _savePlantationCommand;
        }

        public RelayCommand DeletePlantationCommand
        {
            get => _deletePlantationCommand;
        }

        private void SavePlantation()
        {
            EditedPlantation.Validate();

            if (!Plantations.Contains(EditedPlantation))
            {
                Plantations.Add(EditedPlantation);
            }
        }

        private bool CanSavePlantation()
        {
            if ((EditedPlantation != null) && !EditedPlantation.HasErrors)
            {
                return true;
            }
            return false;
        }

        private bool CanAddNewPlantation()
        {
            if (EditedPlantation != null)
            {
                return false;
            }
            return true;
        }

        public bool IsDirty
        {
            get; set;
        }

        private RelayCommand _addNewPlantationCommand;


        private RelayCommand _deletePlantationCommand;

        public RelayCommand AddNewPlantationCommand
        {
            get => _addNewPlantationCommand;
        }

        private RelayCommand _filterDataCommand;
        public RelayCommand FilterDataCommand { get => _filterDataCommand; }

    }
}
