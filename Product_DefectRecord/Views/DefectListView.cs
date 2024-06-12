using Product_DefectRecord._Repositories;
using Product_DefectRecord.Models;
using Product_DefectRecord.Presenters;
using Product_DefectRecord.Views;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using static Product_DefectRecord.Presenters.DefectListPresenter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Product_DefectRecord.Views
{
    public partial class DefectListView : Form, IDefectListView
    {
        private TcpClientWrapper clientWrapper;
        private string inspectorId;
        private PrintManualPresenter printManualPresenter;
        private BindingSource defectsBindingSource = new BindingSource();
        private bool showNoData = true;
        private string latestReceivedData;
        public LoginModel _user;
        public DefectListView(LoginModel user)
        {
            InitializeComponent();
            _user = user;
            AssociateAndRaiseViewEvents();
            printManualPresenter = new PrintManualPresenter(this);
            InitializeTabControl();
        }

        //event
        public event EventHandler<ModelEventArgs> SearchModelNumber;
        public event EventHandler ClearEvent;
        public event TopDefectEventHandler DefectFilterEvent;
        public event EventHandler EditButtonClicked;
        public event EventHandler CellClicked;
        public event KeyEventHandler KeyDownEvent;

        private void AssociateAndRaiseViewEvents()
        {
            throw new NotImplementedException();
        }


        private void InitializeTabControl()
        {
            PrintRecord printRecord = new PrintRecord();
            DefectListDataPresenter presenterData = new DefectListDataPresenter(printRecord, new DefectRepository(), new ModelNumberRepository(), _user);
        }
        // Call this method when you need to perform a model search
        private void PerformModelSearch()
        {
            // Raise the event with the data from the view
            //SearchModelNumber?.Invoke(this, new ModelEventArgs(SerialNumber));
        }


        private async void DefectView_Load(object sender, EventArgs e)
        {
            timer1.Start();
            //clientWrapper = new TcpClientWrapper(UpdateCodeBox, UpdateSerialBox); // Passing both update methods
            await clientWrapper.ConnectToServerAsync();
        }

        public void SetDefectListBindingSource(BindingSource defectList)
        {
            //dataGridView1.DataSource = defectList;
        }

        //public void ShowPopupForm()
        //{
        //    DetailDefectView popupForm = new DetailDefectView();
        //    popupForm.ShowDialog();
        //}

        //public void AddNoData()
        //{
        //    // Clear existing data source
        //    dataGridView1.DataSource = null;

        //    // Bersihkan semua baris yang ada di DataGridView
        //    dataGridView1.Rows.Clear();

        //    dataGridView1.Columns[0].HeaderText = "No Data";
        //    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //}

        //public void RemoveNoData(BindingSource defectList)
        //{
        //    // Bersihkan semua baris yang ada di DataGridView
        //    dataGridView1.Rows.Clear();
        //    dataGridView1.RowPostPaint += (sender, e) =>
        //    {
        //        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
        //            row.Cells["No"].Value = (e.RowIndex + 1).ToString();
        //            row.Cells["No"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    };
        //    dataGridView1.Columns[0].HeaderText = "No";
        //    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //    // Set nilai DataSource menjadi null untuk menghapus sumber data
        //    SetDefectListBindingSource(defectList);

        //}

        private void DefectListView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
