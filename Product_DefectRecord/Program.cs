using Product_DefectRecord._Repositories;
using Product_DefectRecord.Models;
using Product_DefectRecord.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Product_DefectRecord.Presenters;

namespace Product_DefectRecord
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["LSBUDBConnection"].ConnectionString;
            ILoginView view = new LoginView();
            ILoginRepository repository = new LoginRepository(sqlConnectionString);
            new LoginPresenter(view, repository);

            Application.Run((Form)view);

            //ILoginRepository login = new LoginView();
            //IDefectListView view = new DefectListView();
            //IDefectRepository repository = new DefectRepository(sqlConnectionString);
            //IModelNumberRepository repository2 = new ModelNumberRepository(sqlConnectionString);
            //new DefectListPresenter(login, view, repository, repository2); // Provide repository2 to the constructor
            //Application.Run((Form)view);
        }
    }
}
