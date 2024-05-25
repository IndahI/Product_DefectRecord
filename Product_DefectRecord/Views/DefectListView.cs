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
        public DefectListView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            printManualPresenter = new PrintManualPresenter(this);
        }

        //event
        public event EventHandler<ModelEventArgs> SearchModelNumber;
        public event EventHandler ClearEvent;
        public event TopDefectEventHandler DefectFilterEvent;
        public event EventHandler EditButtonClicked;
        public event EventHandler CellClicked;
        public event KeyEventHandler KeyDownEvent;

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

        public bool IsKeyboardEnabled 
        { 
            get { return true; }
            set {  }
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
            timer1.Start();
            clientWrapper = new TcpClientWrapper(UpdateCodeBox, UpdateSerialBox); // Passing both update methods
            await clientWrapper.ConnectToServerAsync();
        }

        private void DefectListView_keyDown(object sender, KeyEventArgs e)
        {
            KeyDownEvent?.Invoke(sender, e);
        }

        //Methods
        private void AssociateAndRaiseViewEvents()
        {
            //Clear
            btnClear.Click += delegate
            {
                ClearEvent?.Invoke(this, EventArgs.Empty);
            };

            btnA.Click += delegate
            {
                ChangeColorButton(btnA, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnA.Tag.ToString()));
            };

            btnB.Click += delegate
            {
                ChangeColorButton(btnB, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnB.Tag.ToString()));
            };

            btnC.Click += delegate
            {
                ChangeColorButton(btnC, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnC.Tag.ToString()));
            };

            btnD.Click += delegate
            {
                ChangeColorButton(btnD, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnD.Tag.ToString()));
            };

            btnE.Click += delegate
            {
                ChangeColorButton(btnE, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnE.Tag.ToString()));
            };

            btnF.Click += delegate
            {
                ChangeColorButton(btnF, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnF.Tag.ToString()));
            };

            btnG.Click += delegate
            {
                ChangeColorButton(btnG, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnG.Tag.ToString()));
            };

            btnH.Click += delegate
            {
                ChangeColorButton(btnH, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnH.Tag.ToString()));
            };

            btnI.Click += delegate
            {
                ChangeColorButton(btnI, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnI.Tag.ToString()));
            };

            btnJ.Click += delegate
            {
                ChangeColorButton(btnJ, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnJ.Tag.ToString()));
            };

            btnK.Click += delegate
            {
                ChangeColorButton(btnK, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnK.Tag.ToString()));
            };

            btnL.Click += delegate
            {
                ChangeColorButton(btnL, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnL.Tag.ToString()));
            };

            btnM.Click += delegate
            {
                ChangeColorButton(btnM, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnM.Tag.ToString()));
            };

            btnN.Click += delegate
            {
                ChangeColorButton(btnN, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnN.Tag.ToString()));
            };

            btnO.Click += delegate
            {
                ChangeColorButton(btnO, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnO.Tag.ToString()));
            };

            btnP.Click += delegate
            {
                ChangeColorButton(btnP, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnP.Tag.ToString()));
            };

            btnQ.Click += delegate
            {
                ChangeColorButton(btnQ, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnQ.Tag.ToString()));
            };

            btnR.Click += delegate
            {
                ChangeColorButton(btnR, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnR.Tag.ToString()));
            };

            btnS.Click += delegate
            {
                ChangeColorButton(btnS, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnS.Tag.ToString()));
            };

            btnT.Click += delegate
            {
                ChangeColorButton(btnT, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnT.Tag.ToString()));
            };

            btnU.Click += delegate
            {
                ChangeColorButton(btnU, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnU.Tag.ToString()));
            };

            btnV.Click += delegate
            {
                ChangeColorButton(btnV, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnV.Tag.ToString()));
            };

            btnW.Click += delegate
            {
                ChangeColorButton(btnW, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnW.Tag.ToString()));
            };

            btnX.Click += delegate
            {
                ChangeColorButton(btnX, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnX.Tag.ToString()));
            };

            btnY.Click += delegate
            {
                ChangeColorButton(btnY, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnY.Tag.ToString()));
            };

            btnZ.Click += delegate
            {
                ChangeColorButton(btnZ, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnZ.Tag.ToString()));
            };

            textBoxSerial.TextChanged += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(textBoxSerial.Text))
                {
                    btnStatus.Text = "...";
                }
            };

            btnLogout.Click += delegate
            {
                ILoginView loginView = new LoginView();
                LoginPresenter loginPresenter = new LoginPresenter(loginView, new LoginRepository());
                (loginView as Form)?.Show();
                //Application.Exit();
                this.Hide();
            };

            dataGridView1.CellContentClick += (sender, e) =>
            {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    var selectedPerson = selectedRow.DataBoundItem as DefectModel;
                    CellClicked?.Invoke(this, EventArgs.Empty);
                    btnStatus.Text = "Save And Print";
                    //textBoxDefectName.Text = selectedPerson.DefectName1;
            };

            dataGridView1.RowPostPaint += (sender, e) =>
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                row.Cells["No"].Value = (e.RowIndex + 1).ToString();
                row.Cells["No"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            };

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 16);
            dataGridView1.RowTemplate.Height = 50;

            btnSetting.Click += delegate
            {
                ISettingView settingView = SettingView.GetInstance();
                SettingPresenter settingPresenter = new SettingPresenter(settingView, new SettingModel(new SettingRepository()));
                (settingView as Form)?.Show();
            };

            btnPrintManual.Click += delegate
            {
                textBoxSerial.ReadOnly = !textBoxSerial.ReadOnly;
                textBoxSerial.Focus();
            };

            timer1.Tick += delegate 
            {
                Date.Text = DateTime.Now.ToLongDateString();
                Time.Text = DateTime.Now.ToLongTimeString();    
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
        private void ChangeColorButton(object sender, EventArgs e)
        {
            foreach (Control c in Panel3.Controls)
            {
                c.BackColor = Color.FromArgb(0, 173, 181);
            }
            Control click = (Control)sender;
            click.BackColor = Color.FromArgb(0, 133, 181);
        }

        public void AddNoData()
        {
            // Clear existing data source
            dataGridView1.DataSource = null;

            // Bersihkan semua baris yang ada di DataGridView
            dataGridView1.Rows.Clear();

            dataGridView1.Columns[0].HeaderText = "No Data";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView1.Rows.Add(w);
        }

        public void RemoveNoData(BindingSource defectList)
        {
            // Bersihkan semua baris yang ada di DataGridView
            dataGridView1.Rows.Clear();
            dataGridView1.RowPostPaint += (sender, e) =>
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    row.Cells["No"].Value = (e.RowIndex + 1).ToString();
                    row.Cells["No"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            };
            dataGridView1.Columns[0].HeaderText = "No";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            // Set nilai DataSource menjadi null untuk menghapus sumber data
            SetDefectListBindingSource(defectList);

        }

        private void textBoxSerial_KeyDown(object sender, KeyEventArgs e)
        {
            // Jika tombol "Enter" ditekan
            if (e.KeyCode == Keys.Enter)
            {
                // Jika enter ditekan, kirim Keys.Enter
                KeyDownEvent?.Invoke(this, new KeyEventArgs(Keys.Enter));
            }
            else
            {
                // Jika bukan tombol "Enter", maka pasti karakter yang dimasukkan
                // Jika yang dimasukkan adalah angka, kirim Keys.None
                if (int.TryParse(textBoxSerial.Text, out int _))
                {
                    KeyDownEvent?.Invoke(this, new KeyEventArgs(Keys.None));
                }
            }
        }

        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            PerformModelSearch();
        }

        private void DefectListView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
