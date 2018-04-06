using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kapiszewski.HoneyCatalog.Core;

namespace Kapiszewski.HoneyCatalog.Interfaces
{
    public interface IHoney
    {
        IPlantation Plantation { get; set; }
        Honey HoneyType { get; set; }
        string Species { get; set; }
        int ProductionYear { get; set; }

    }
}
