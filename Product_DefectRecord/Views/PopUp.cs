using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_DefectRecord.Views
{
    public partial class PopUp : Form, IPopUp
    {
        public PopUp()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        public string SerialNumber
        {
            get { return textSerial.Text; }
            set { textSerial.Text = value; }
        }
        public string ModelNumber
        {
            get { return textModel.Text; }
            set { textModel.Text = value; }
        }
        public string DefectName
        {
            get { return textDefect.Text; }
            set { textDefect.Text = value; }
        }
        public string Inspector
        {
            get { return textInspec.Text; }
            set { textInspec.Text = value; }
        }
        public string currentDate = DateTime.Now.ToString("dd/MM/yyyy");

        public event EventHandler SaveDefect;

        private void AssociateAndRaiseViewEvents()
        {
            btnOk.Click += delegate
            {
                //btnOk.Visible = false;

                PrintDocument pd = new PrintDocument();

                pd.PrintPage += printDocument1_PrintPage_1;

                pd.PrintPage += (s, ev) => PrintInformation(ev);

                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = pd;
                printPreviewDialog.ShowDialog();

                SaveDefect?.Invoke(this, EventArgs.Empty);

                btnOk.Visible = true;

            };

            btnCancle.Click += delegate
            {
                this.Close();
            };
        }

        private void PrintInformation(PrintPageEventArgs e)
        {

            // Batas margin
            int marginTop = 390;

            // Tentukan posisi awal cetak
            int yPos = marginTop;
            int xPos = 75;

            // Set font yang akan digunakan
            Font head = new Font("Arial", 10, FontStyle.Bold);
            Font fs1 = new Font("Arial", 8);
            Font fs2 = new Font("Arial", 6);


            e.Graphics.DrawString("PRODUK TIDAK LULUS INSPEKSI", head, Brushes.Black, new PointF(90, yPos + 75));
            yPos += 30;

            // Gambar informasi model
            e.Graphics.DrawString("Model", fs1, Brushes.Black, new PointF(xPos, yPos + 63));
            yPos += 20;
            e.Graphics.DrawString(":" + ModelNumber, fs1, Brushes.Black, new PointF(xPos + 75, yPos + 43));

            // Data dalam tabel
            string[,] tableChecked = new string[2, 2] {
                {"Reconfrim","Checked" },
                {"Leader", "Repairman"},
            };

            int Width = 40;
            int Height = 15;
            int Height2 = 20;
            int X = 245;
            int Y = yPos + 43;

            // Gambar garis vertikal
            for (int i = 0; i <= 2; i++)
            {
                e.Graphics.DrawLine(Pens.Black, X + i * Width, Y, X + i * Width, Y + Height * 2 + Height2);
            }

            // Gambar garis horizontal
            for (int i = 0; i <= 2; i++)
            {
                int currentHeight = (i == 1) ? Height2 : Height;
                e.Graphics.DrawLine(Pens.Black, X, Y + i * currentHeight, X + Width * 2, Y + i * currentHeight);
            }

            // Gambar data tabel
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    float x = X + col * Width;
                    float y = Y + row * Height;

                    if (row == 1)
                    {
                        y += Height; // Menambahkan tinggi baris pertama untuk mendapatkan posisi Y yang benar untuk baris kedua
                    }

                    float textX = x + 7;
                    float textY = y;

                    float textHeight = (row == 1) ? Height2 : Height;
                    textX += (Width - e.Graphics.MeasureString(tableChecked[row, col], fs1).Width) / 2;
                    textY += (textHeight - e.Graphics.MeasureString(tableChecked[row, col], fs1).Height) / 2;

                    if (col == 1)
                    {
                        e.Graphics.DrawString(tableChecked[row, col], fs2, Brushes.Black, new PointF(textX + 2, textY));

                    }
                    else
                    {
                        e.Graphics.DrawString(tableChecked[row, col], fs2, Brushes.Black, new PointF(textX, textY));
                    }

                }
            }

            e.Graphics.DrawString("Tanggal             ", fs1, Brushes.Black, new PointF(xPos, yPos + 55));
            e.Graphics.DrawString(":" + currentDate, fs1, Brushes.Black, new PointF(xPos + 75, yPos + 55));

            // Gambar informasi serial number
            e.Graphics.DrawString("Serial Number", fs1, Brushes.Black, new PointF(xPos, yPos + 65));
            yPos += 20;
            e.Graphics.DrawString(":" + SerialNumber, fs1, Brushes.Black, new PointF(xPos + 75, yPos + 45));


            // Gambar informasi inspeksi
            e.Graphics.DrawString("Inspection         ", fs1, Brushes.Black, new PointF(xPos, yPos + 56));
            e.Graphics.DrawString(":" + Inspector, fs1, Brushes.Black, new PointF(xPos + 75, yPos + 55));

            // Data dalam tabel
            string[,] tableData = new string[3, 2] {
                {"Item Masalah", DefectName },
                {"Analisa", "Data 2"},
                {"Action", "Data3" },
            };

            int cellWidth = 125;
            int cellWidth0 = 50;
            int cellHeight = 20;
            int startX = 80;
            int startY = yPos + 70;

            // Gambar garis vertikal
            for (int i = 0; i <= 2; i++)
            {
                e.Graphics.DrawLine(Pens.Black, startX + i * (i == 0 ? cellWidth0 : cellWidth), startY, startX + i * (i == 0 ? cellWidth0 : cellWidth), startY + cellHeight * 3);
            }

            // Gambar garis horizontal
            for (int i = 0; i <= 3; i++)
            {
                e.Graphics.DrawLine(Pens.Black, startX, startY + i * cellHeight, startX + cellWidth * 2, startY + i * cellHeight);
            }

            // Gambar data tabel
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    float x = startX + col * (col == 0 ? cellWidth0 : cellWidth);
                    float y = startY + row * cellHeight;

                    float textX = x;
                    float textY = y;

                    //membuat tulisan center
                    if (col == 0)
                    {
                        textX += (cellWidth - e.Graphics.MeasureString(tableData[row, col], fs1).Width) / 2;
                        textY += (cellHeight - e.Graphics.MeasureString(tableData[row, col], fs1).Height) / 2;
                    }

                    e.Graphics.DrawString(tableData[row, col], fs1, Brushes.Black, new PointF(textX, textY));
                }
            }
        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            PaperSize customPaperSize = new PaperSize("Custom", 297, 110); // Ukuran A7 dalam satuan mm
            printDocument1.DefaultPageSettings.PaperSize = customPaperSize;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }
    }
}
