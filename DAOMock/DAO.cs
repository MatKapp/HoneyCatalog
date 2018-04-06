using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kapiszewski.HoneyCatalog.Interfaces;

namespace Kapiszewski.HoneyCatalog.DAOMock
{
    public class DAO : IDAO
    {
        private List<IHoney> honey;
        private List<IPlantation> plantations;

        public DAO()
        {
            plantations = new List<IPlantation>()
            {
                new Kapiszewski.HoneyCatalog.DAOMock.BO.Plantation{City="Broczyno", Name="rapeseed"},
                new Kapiszewski.HoneyCatalog.DAOMock.BO.Plantation{City="Czaplinek", Name="buckwheat"},
                new Kapiszewski.HoneyCatalog.DAOMock.BO.Plantation{City="Wałcz", Name="lime"},

            };

            honey = new List<IHoney>()
            {
                new Kapiszewski.HoneyCatalog.DAOMock.BO.Honey{HoneyType=Kapiszewski.HoneyCatalog.Core.Honey.nectar, Plantation=plantations[0], ProductionYear=2018,Species="rapeseed" },
                new Kapiszewski.HoneyCatalog.DAOMock.BO.Honey{HoneyType=Kapiszewski.HoneyCatalog.Core.Honey.nectar, Plantation=plantations[1], ProductionYear=2018,Species="buckwheat" },
                new Kapiszewski.HoneyCatalog.DAOMock.BO.Honey{HoneyType=Kapiszewski.HoneyCatalog.Core.Honey.mead, Plantation=plantations[2], ProductionYear=2017,Species="lime" },
            };
        }

        public IEnumerable<IPlantation> GetAllPlantations()
        {
            return plantations;
        }
        public IEnumerable<IHoney> GetAllHoney()
        {
            return honey;
        }
    }
}
