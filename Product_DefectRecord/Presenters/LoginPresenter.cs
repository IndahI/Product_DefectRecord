using Product_DefectRecord._Repositories;
using Product_DefectRecord.Models;
using Product_DefectRecord.Views;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_DefectRecord.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly ILoginRepository _userRepository;

        public LoginPresenter(ILoginView view, ILoginRepository userRepository)
        {
            _view = view;
            _userRepository = userRepository;
            _view.Login += async (s, e) => await LoginAsync();
        }

        private async Task LoginAsync()
        {
            string nik = _view.Nik;
            string password = _view.Password;

            LoginModel user = _userRepository.GetUserByUsername(nik);

            if (user == null)  // Check Nik first for efficiency
            {
                MessageBox.Show("NIK tidak ditemukan. Harap periksa kembali NIK Anda.", "Kesalahan Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (user.Password != password)  // Check password only if Nik matches
            {
                MessageBox.Show("NIK dan Password tidak cocok. Harap periksa kembali kredensial Anda.", "Kesalahan Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (user.Nik != nik)
            {
                MessageBox.Show("NIK tidak ditemukan. Harap periksa kembali NIK Anda.", "Kesalahan Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else  // Login successful
            {
                Console.WriteLine($"Login successful for user: {user.Name}");
                IDefectListView defectListView = new DefectListView();
                IDefectRepository defectRepository = new DefectRepository();
                IModelNumberRepository modelNumberRepository = new ModelNumberRepository();
                DefectListDataPresenter presenterData = new DefectListDataPresenter(defectListView, defectRepository, modelNumberRepository, user);

                DefectListPresenter presenter = new DefectListPresenter(presenterData);
                _view.HideView();
            }
        }
    }
}
