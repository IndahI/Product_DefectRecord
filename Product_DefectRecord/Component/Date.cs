using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_DefectRecord.Component
{
    internal class Date : DateTimePicker
    {
        //Fields
        //Aperance
        private Color skinColor = Color.MediumSlateBlue;
        private Color textColor = Color.White;
        private Color borderColor = Color.White;
        private int borderSize = 0;

        //properties
        public Color SkinColor 
        {
            get 
            { 
                return SkinColor; 
            }
            set 
            {
                skinColor = value; 
                this.Invalidate();
            } 
        }
        public Color TextColor 
        {
            get { return textColor; }
            set { textColor = value; this.Invalidate(); }
        }
        public int BorderSize 
        {
            get { return borderSize; }
            set { borderSize = value; this.Invalidate(); } 
        }

        //constructor
        public Date()
        {
            this.SetStyle(ControlStyles.UserPaint,true);
            this.MinimumSize = new Size(0, 35);
            this.Font = new Font(this.Font.Name, 9.5F);
        }

        //oversidenMethods
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics graphics = this.CreateGraphics())
            using (Pen penBorder = new Pen(borderColor, BorderSize))
            using (SolidBrush skinBrush = new SolidBrush(skinColor))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (StringFormat textFormat = new StringFormat()) 
            {
                RectangleF clientArea = new RectangleF(0, 0, this.Width - 0.5F, this.Height - 0.5F);
                penBorder.Alignment = PenAlignment.Inset;
                textFormat.LineAlignment = StringAlignment.Center;

                //draw surface
                graphics.FillRectangle(skinBrush, clientArea);
                //draw text 
                graphics.DrawString(" " + this.Text, this.Font, textBrush, clientArea, textFormat);
                //drawborder
                if(borderSize >= 1) graphics.DrawRectangle(penBorder, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);

            }
        }
    }
}
