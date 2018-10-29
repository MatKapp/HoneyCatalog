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
    public class HoneyListViewModel : ViewModelBase
    {
        public ObservableCollection<HoneyViewModel> Honey { get; set; } = new ObservableCollection<HoneyViewModel>();

        private ListCollectionView _view;

        private HoneyViewModel _editedHoney;

        private HoneyViewModel _selectedHoney;

        public HoneyViewModel SelectedHoney
        {
            get => _selectedHoney;
            set
            {
                _selectedHoney = value;
                EditedHoney = value;
                OnPropertyChanged(nameof(EditedHoney));
            }
        }
        public string FilterValue { get; set; }

        public HoneyListViewModel()
        {
            OnPropertyChanged("Honey");
            GetAllHoney();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Honey);
            _filterDataCommand = new RelayCommand(param => this.FilterData());
            _addNewHoneyCommand = new RelayCommand(param => this.AddNewHoney(),
                                                param => this.CanAddNewHoney());
            _saveHoneyCommand = new RelayCommand(param => this.SaveHoney(),
                                                param => this.CanSaveHoney());
            _deleteHoneyCommand = new RelayCommand(param => this.DeleteHoney());
        }

        private void DeleteHoney()
        {
            Honey.Remove(Honey.Where(x => x.Equals(SelectedHoney)).Single());
            //EditedHoney = new HoneyViewModel(new Kapiszewski.HoneyCatalog.DAOMock.BO.Honey());
        }

        private void GetAllHoney()
        {
            Kapiszewski.HoneyCatalog.BLC.DataProvider dataProvider = new Kapiszewski.HoneyCatalog.BLC.DataProvider(new Settings().DataBase);
            foreach (var honey in dataProvider.Honey)
            {
                Honey.Add(new HoneyViewModel(honey));
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
                _view.Filter = (c) => ((HoneyViewModel)c).Species.Contains(FilterValue);
            }
        }

        public HoneyViewModel EditedHoney
        {
            get => _editedHoney;
            set
            {
                _editedHoney= value;
                OnPropertyChanged(nameof(EditedHoney));
            }
        }

        private void AddNewHoney()
        {
            EditedHoney= new HoneyViewModel(new Kapiszewski.HoneyCatalog.DAOMock.BO.Honey())
            {
                Species = "",
                ProductionYear = 9999
            };
        }

        private RelayCommand _saveHoneyCommand;

        public RelayCommand SaveHoneyCommand
        {
            get => _saveHoneyCommand;
        }

        public RelayCommand DeleteHoneyCommand
        {
            get => _deleteHoneyCommand;
        }

        private void SaveHoney()
        {
            EditedHoney.Validate();

            if (!Honey.Contains(EditedHoney))
            {
                Honey.Add(EditedHoney);
            }
        }

        private bool CanSaveHoney()
        {
            if ((EditedHoney != null) && !EditedHoney.HasErrors)
            {
                return true;
            }
            return false;
        }

        private bool CanAddNewHoney()
        {
            if (EditedHoney != null)
            {
                return false;
            }
            return true;
        }

        public bool IsDirty
        {
            get; set;
        }

        private RelayCommand _addNewHoneyCommand;


        private RelayCommand _deleteHoneyCommand;

        public RelayCommand AddNewHoneyCommand
        {
            get => _addNewHoneyCommand;
        }

        private RelayCommand _filterDataCommand;
        public RelayCommand FilterDataCommand { get => _filterDataCommand; }

    }
}
