using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kapiszewski.HoneyCatalog.Interfaces;

namespace Kapiszewski.HoneyCatalog.DAOMock.BO
{
    public class Plantation : IPlantation
    {
        public string Name { get; set; }
        public string City { get; set; }
    }
}
