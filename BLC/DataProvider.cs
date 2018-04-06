using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kapiszewski.HoneyCatalog.Interfaces;
using Kapiszewski.HoneyCatalog.DAOMock;

namespace Kapiszewski.HoneyCatalog.BLC
{
    public class DataProvider
    {
        public IDAO DAO { get; set; }
        public IEnumerable<IHoney> Honey
        {
            get { return DAO.GetAllHoney(); }
        }
        public IEnumerable<IPlantation> Plantations
        {
            get { return DAO.GetAllPlantations(); }
        }

        public DataProvider()
        {
            DAO = new DAOMock.DAO();
        }
    }
}
