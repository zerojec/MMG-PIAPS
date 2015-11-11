namespace MMG_PIAPS.userctrl.payroll_generator
{
    partial class emp_payroll_new
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbEmpPic = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.lblnamepos = new System.Windows.Forms.Label();
            this.lblaction = new System.Windows.Forms.Label();
            this.lbattendance = new System.Windows.Forms.ListBox();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bgwattendance = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmpPic)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pbEmpPic, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(757, 142);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pbEmpPic
            // 
            this.pbEmpPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbEmpPic.Location = new System.Drawing.Point(3, 3);
            this.pbEmpPic.Name = "pbEmpPic";
            this.pbEmpPic.Size = new System.Drawing.Size(134, 136);
            this.pbEmpPic.TabIndex = 1;
            this.pbEmpPic.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel2.Controls.Add(this.lblnamepos, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbattendance, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(140, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(617, 142);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.Margin = new System.Windows.Forms.Padding(0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(308, 20);
            this.pb.TabIndex = 0;
            // 
            // lblnamepos
            // 
            this.lblnamepos.AutoSize = true;
            this.lblnamepos.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanel2.SetColumnSpan(this.lblnamepos, 3);
            this.lblnamepos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblnamepos.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnamepos.ForeColor = System.Drawing.Color.White;
            this.lblnamepos.Location = new System.Drawing.Point(0, 20);
            this.lblnamepos.Margin = new System.Windows.Forms.Padding(0);
            this.lblnamepos.Name = "lblnamepos";
            this.lblnamepos.Size = new System.Drawing.Size(617, 23);
            this.lblnamepos.TabIndex = 1;
            this.lblnamepos.Text = "...";
            this.lblnamepos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblaction
            // 
            this.lblaction.AutoSize = true;
            this.lblaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblaction.Location = new System.Drawing.Point(308, 0);
            this.lblaction.Margin = new System.Windows.Forms.Padding(0);
            this.lblaction.Name = "lblaction";
            this.lblaction.Size = new System.Drawing.Size(309, 20);
            this.lblaction.TabIndex = 2;
            this.lblaction.Text = "...";
            this.lblaction.Click += new System.EventHandler(this.lblaction_Click);
            // 
            // lbattendance
            // 
            this.lbattendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbattendance.FormattingEnabled = true;
            this.lbattendance.ItemHeight = 15;
            this.lbattendance.Location = new System.Drawing.Point(0, 43);
            this.lbattendance.Margin = new System.Windows.Forms.Padding(0);
            this.lbattendance.Name = "lbattendance";
            this.lbattendance.Size = new System.Drawing.Size(203, 99);
            this.lbattendance.TabIndex = 3;
            // 
            // bgw
            // 
            this.bgw.WorkerReportsProgress = true;
            this.bgw.WorkerSupportsCancellation = true;
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bgwattendance
            // 
            this.bgwattendance.WorkerReportsProgress = true;
            this.bgwattendance.WorkerSupportsCancellation = true;
            this.bgwattendance.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwattendance_DoWork);
            this.bgwattendance.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwattendance_RunWorkerCompleted);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 3);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.pb, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblaction, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(617, 20);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // emp_payroll_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "emp_payroll_new";
            this.Size = new System.Drawing.Size(757, 142);
            this.Load += new System.EventHandler(this.emp_payroll_new_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEmpPic)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.PictureBox pbEmpPic;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblnamepos;
        private System.Windows.Forms.Label lblaction;
        private System.Windows.Forms.ListBox lbattendance;
        private System.ComponentModel.BackgroundWorker bgwattendance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}
