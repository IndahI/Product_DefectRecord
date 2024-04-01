namespace Product_DefectRecord.Views
{
    partial class EditDefectView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textPartName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textDefectId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textDefectName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part Name";
            // 
            // textPartName
            // 
            this.textPartName.Location = new System.Drawing.Point(37, 142);
            this.textPartName.Name = "textPartName";
            this.textPartName.Size = new System.Drawing.Size(100, 26);
            this.textPartName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Defect Id";
            // 
            // textDefectId
            // 
            this.textDefectId.Location = new System.Drawing.Point(37, 65);
            this.textDefectId.Name = "textDefectId";
            this.textDefectId.Size = new System.Drawing.Size(100, 26);
            this.textDefectId.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Defect Name";
            // 
            // textDefectName
            // 
            this.textDefectName.Location = new System.Drawing.Point(37, 231);
            this.textDefectName.Name = "textDefectName";
            this.textDefectName.Size = new System.Drawing.Size(100, 26);
            this.textDefectName.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(37, 302);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 43);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(164, 302);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(100, 43);
            this.btnCancle.TabIndex = 2;
            this.btnCancle.Text = "Cancle";
            this.btnCancle.UseVisualStyleBackColor = true;
            // 
            // EditDefectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textDefectId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDefectName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textPartName);
            this.Controls.Add(this.label1);
            this.Name = "EditDefectView";
            this.Text = "EditDefectName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPartName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textDefectId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textDefectName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancle;
    }
}