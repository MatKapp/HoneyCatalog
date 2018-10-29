using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Kapiszewski.HoneyCatalog.Interfaces;
using Kapiszewski.HoneyCatalog.DAOMock;
using System.Runtime;
using System.Runtime.Remoting.Channels;

namespace Kapiszewski.HoneyCatalog.BLC
{
    public class DataProvider
    {
        public IDAO DAO { get; set; }
        public IEnumerable<IHoney> Honey
        {
            get { return DAO.GetAllHoney(); }
        }

        private static string preaparePathToDll(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\" + localPath + @"\bin\Debug\" + localPath + ".dll")));
            return directory.ToString();
        }

        public IEnumerable<IPlantation> Plantations
        {
            get { return DAO.GetAllPlantations(); }
        }

        public DataProvider(string DllName)
        {
            String PathToLibrary = preaparePathToDll(DllName);
            Assembly a = Assembly.UnsafeLoadFrom(PathToLibrary);
            Type daoType = null;
            
            foreach (var type in a.GetTypes())
            {
                if (type.GetInterface("IDAO") != null)
                {
                    daoType = type;
                }
            }
            ConstructorInfo DAOConstructor = daoType.GetConstructor(new Type[] { });
            DAO = (IDAO)DAOConstructor.Invoke(new object[] { });
        }
    }
}
