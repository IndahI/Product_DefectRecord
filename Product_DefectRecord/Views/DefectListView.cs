using Product_DefectRecord._Repositories;
using Product_DefectRecord.Models;
using Product_DefectRecord.Presenters;
using Product_DefectRecord.Views;
using System;
using System.Configuration;
using System.Windows.Forms;
using static Product_DefectRecord.Presenters.DefectListPresenter;

namespace Product_DefectRecord.Views
{
    public partial class DefectListView : Form, IDefectListView
    {
        private TcpServerWrapper serverWrapper;
        private string inspectorId;
        public DefectListView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();

        }

        //event
        public event EventHandler<ModelEventArgs> SearchModelNumber;
        public event EventHandler ClearEvent;
        public event TopDefectEventHandler DefectFilterEvent;
        public event EventHandler EditButtonClicked;
        public event EventHandler CellClicked;

        //properties
        public string SerialNumber
        {
            get { return textBoxSerial.Text; }
            set { textBoxSerial.Text = value; }
        }
        public string ModelNumber
        {
            get { return textBoxModel.Text; }
            set { textBoxModel.Text = value; }
        }
        public string ModelCode
        {
            get { return textBoxCode.Text; }
            set { textBoxCode.Text = value; }
        }
        public string InspectorId
        {
            get { return inspectorId; }
            set { inspectorId = value; }
        }
        public string Inspector
        {
            get { return textBoxInspector.Text; }
            set { textBoxInspector.Text = value; }
        }

        public string StatusText
        {
            get { return btnStatus.Text; }
            set { btnStatus.Text = value; }
        }

        // Call this method when you need to perform a model search
        private void PerformModelSearch()
        {
            // Raise the event with the data from the view
            SearchModelNumber?.Invoke(this, new ModelEventArgs(SerialNumber));
        }


        private void UpdateSerialBox(string message)
        {
            // Invoke UI updates on the UI thread
            if (textBoxSerial.InvokeRequired)
            {
                textBoxSerial.Invoke((MethodInvoker)(() => UpdateSerialBox(message)));
            }
            else
            {
                textBoxSerial.Text = message;
            }
            
        }

        private void UpdateCodeBox(string message)
        {
            // Invoke UI updates on the UI thread
            if (textBoxCode.InvokeRequired)
            {
                textBoxCode.Invoke((MethodInvoker)(() => UpdateCodeBox(message)));
            }
            else
            {
                textBoxCode.Text = message;
            }
            PerformModelSearch();
        }


        private async void DefectView_Load(object sender, EventArgs e)
        {
            serverWrapper = new TcpServerWrapper(1234, UpdateCodeBox, UpdateSerialBox); // Passing both update methods
            await serverWrapper.StartServerAsync();
        }

        //Methods
        private void AssociateAndRaiseViewEvents()
        {
            //Clear
            btnClear.Click += delegate
            {
                ClearEvent?.Invoke(this, EventArgs.Empty);
            };

            btnTop.Click += delegate
            {
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnTop.Tag.ToString()));
            };

            btnPulsator.Click += delegate
            {
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnPulsator.Tag.ToString()));
            };
            btnDll.Click += delegate
            {
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnDll.Tag.ToString()));
            };

            btnMotorSpin.Click += delegate
            {
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnMotorSpin.Tag.ToString()));
            };

            btnTubA.Click += delegate
            {
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnTubA.Tag.ToString()));
            };

            textBoxSerial.TextChanged += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(textBoxSerial.Text))
                {
                    btnStatus.Text = "Save And Print";
                }
            };

            btnLogout.Click += delegate
            {
                Application.Exit();
            };

            dataGridView1.CellContentClick += (sender, e) =>
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    EditButtonClicked?.Invoke(this, new EventArgs());
                }
                else
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    var selectedPerson = selectedRow.DataBoundItem as DefectModel;
                    CellClicked?.Invoke(this, EventArgs.Empty);
                    btnStatus.Text = "Save And Print";
                    //textBoxDefectName.Text = selectedPerson.DefectName1;
                }
            };


            btnSetting.Click += delegate
            {
                string sqlConnectionString = ConfigurationManager.ConnectionStrings["LSBUDBConnection"].ConnectionString;
                ISettingView settingView = SettingView.GetInstance();
                SettingPresenter settingPresenter = new SettingPresenter(settingView, new SettingModel(new SettingRepository(sqlConnectionString)));
                (settingView as Form)?.Show();
            };
        }

        public void SetDefectListBindingSource(BindingSource defectList)
        {
            dataGridView1.DataSource = defectList;
        }

        public void FilterByPartId(int partId)
        {
            throw new NotImplementedException();
        }

        public void ShowPopupForm()
        {
            DetailDefectView popupForm = new DetailDefectView();
            popupForm.ShowDialog();
        }
    }
}
