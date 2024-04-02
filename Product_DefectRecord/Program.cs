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
            // Create instances of login view, repository, and presenter
            ILoginView loginView = new LoginView();
            ILoginRepository loginRepository = new LoginRepository(sqlConnectionString);
            LoginPresenter loginPresenter = new LoginPresenter(loginView, loginRepository);

            Application.Run((Form)loginView);

            // After the login form is closed, check if login was successful
            if (loginView.IsLoginSuccessful)
            {
                // If login is successful, proceed to open the main application form
                IDefectListView view = new DefectListView();
                IDefectRepository repository = new DefectRepository(sqlConnectionString);
                IModelNumberRepository repository2 = new ModelNumberRepository(sqlConnectionString);
                new DefectListPresenter(view, repository, repository2); // Provide repository2 to the constructor
                Application.Run((Form)view);
            }
            else
            {
                // If login is unsuccessful, exit the application
                Application.Exit();
            }

            //ILoginRepository login = new LoginView();
            //IDefectListView view = new DefectListView();
            //IDefectRepository repository = new DefectRepository(sqlConnectionString);
            //IModelNumberRepository repository2 = new ModelNumberRepository(sqlConnectionString);
            //new DefectListPresenter(login, view, repository, repository2); // Provide repository2 to the constructor
            //Application.Run((Form)view);
        }
    }
}
