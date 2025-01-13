namespace ImportNBIot
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSave = new Button();
            txtFile = new TextBox();
            lblFile = new Label();
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(108, 90);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "导入";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtFile
            // 
            txtFile.Location = new Point(108, 39);
            txtFile.Name = "txtFile";
            txtFile.Size = new Size(347, 23);
            txtFile.TabIndex = 1;
            txtFile.Click += txtFile_Click;
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.Location = new Point(24, 43);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(80, 17);
            lblFile.TabIndex = 2;
            lblFile.Text = "请选择文件：";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(108, 39);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(347, 23);
            progressBar.TabIndex = 3;
            progressBar.Visible = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 125);
            Controls.Add(progressBar);
            Controls.Add(lblFile);
            Controls.Add(txtFile);
            Controls.Add(btnSave);
            Name = "frmMain";
            Text = "批量导入";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private TextBox txtFile;
        private Label lblFile;
        private ProgressBar progressBar;
    }
}
