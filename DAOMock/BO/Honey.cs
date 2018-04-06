using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kapiszewski.HoneyCatalog.Interfaces;

namespace Kapiszewski.HoneyCatalog.DAOMock.BO
{
    public class Honey : IHoney
    {
        public IPlantation Plantation { get; set; }
        public Kapiszewski.HoneyCatalog.Core.Honey HoneyType { get; set; }
        public string Species { get; set; }
        public int ProductionYear { get; set; }
    }
}
