using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kapiszewski.HoneyCatalog.Properties;

namespace Kapiszewski.HoneyCatalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Kapiszewski.HoneyCatalog.BLC.DataProvider dataProvider = new BLC.DataProvider(new Settings().DataBase);
            foreach (var p in dataProvider.Plantations)
            {
                Console.WriteLine($"{p.Name} in {p.City}");
            }

            foreach (var h in dataProvider.Honey)
            {
                Console.WriteLine($"{h.HoneyType} type {h.Plantation.City} plantation city {h.Species} species {h.ProductionYear} production year");
            }
            Console.ReadKey();
        }
    }
}
