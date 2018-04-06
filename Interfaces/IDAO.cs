using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapiszewski.HoneyCatalog.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IHoney> GetAllHoney();
        IEnumerable<IPlantation> GetAllPlantations();
    }
}
