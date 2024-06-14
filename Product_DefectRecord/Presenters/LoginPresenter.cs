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
        private readonly ILoginView _loginView;
        private readonly ILoginRepository _userRepository;
        private LoginModel _user;
        public LoginModel User => _user;

        public LoginPresenter(ILoginView view, ILoginRepository userRepository)
        {
            _loginView = view;
            _userRepository = userRepository;
            _loginView.Login += async (s, e) => await LoginAsync();
        }

        private async Task LoginAsync()
        {
            string nik = _loginView.Nik;
            string password = _loginView.Password;

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
                _user = user;

                Console.WriteLine(user.Name);
                _loginView.HideView();
                IMainFormView defectListView = MainForm.GetInstance(user);
                defectListView.Show();
            }
        }
    }
}
