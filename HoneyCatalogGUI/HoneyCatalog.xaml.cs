using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HoneyCatalogGUI.Properties;
using Kapiszewski.HoneyCatalog.BLC;
using Kapiszewski.HoneyCatalog.Interfaces;

namespace Kapiszewski.HoneyCatalog.HoneyCatalogGUI
{
    /// <summary>
    /// Interaction logic for HoneyCatalog.xaml
    /// </summary>
    public partial class HoneyCatalog : Window
    {
        //private ObservableCollection<Interfaces.IHoney> _honeyCollection;

        //public ObservableCollection<Interfaces.IHoney> HoneyCollection
        //{
        //    get { return _honeyCollection; }
        //    set { _honeyCollection = value; }
        //}


        public HoneyCatalog()
        {
            //Properties.Settings settings = new Properties.Settings();
            //Kapiszewski.HoneyCatalog.BLC.DataProvider dataProvider = new BLC.DataProvider(settings.DataBase);
            //HoneyCollection = new ObservableCollection<IHoney>(dataProvider.Honey);
            InitializeComponent();
        }
    }
}
