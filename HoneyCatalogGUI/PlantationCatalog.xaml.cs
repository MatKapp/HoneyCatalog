﻿using System;
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
using Kapiszewski.HoneyCatalog.Interfaces;
using Kapiszewski.HoneyCatalog.BLC;

namespace Kapiszewski.HoneyCatalog.HoneyCatalogGUI
{
    /// <summary>
    /// Interaction logic for PlantationCatalog.xaml
    /// </summary>
    public partial class PlantationCatalog : Window
    {

        //private ObservableCollection<Interfaces.IPlantation> _plantationCollection;

        //public ObservableCollection<Interfaces.IPlantation> PlantationCollection
        //{
        //    get { return _plantationCollection; }
        //    set { _plantationCollection = value; }
        //}

        public PlantationCatalog()
        {
            //    Properties.Settings settings = new Properties.Settings();
            //    Kapiszewski.HoneyCatalog.BLC.DataProvider dataProvider = new BLC.DataProvider(settings.DataBase);
            //PlantationCollection = new ObservableCollection<IPlantation>(dataProvider.Plantations);
            InitializeComponent();
        }
    }
}
