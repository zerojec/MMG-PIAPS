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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblaction = new System.Windows.Forms.Label();
            this.lblnamepos = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbschedule = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbattendance = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbltotalabsemt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbltotalpassslip = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbltotalleave = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbltotallate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bgwattendance = new System.ComponentModel.BackgroundWorker();
            this.bgwschedule = new System.ComponentModel.BackgroundWorker();
            this.bgwcutoffdetails = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmpPic)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pbEmpPic, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pb, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(849, 303);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pbEmpPic
            // 
            this.pbEmpPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbEmpPic.Location = new System.Drawing.Point(0, 30);
            this.pbEmpPic.Margin = new System.Windows.Forms.Padding(0);
            this.pbEmpPic.Name = "pbEmpPic";
            this.pbEmpPic.Size = new System.Drawing.Size(222, 260);
            this.pbEmpPic.TabIndex = 1;
            this.pbEmpPic.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lblaction, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblnamepos, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(849, 30);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // lblaction
            // 
            this.lblaction.AutoSize = true;
            this.lblaction.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblaction.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblaction.ForeColor = System.Drawing.Color.White;
            this.lblaction.Location = new System.Drawing.Point(424, 0);
            this.lblaction.Margin = new System.Windows.Forms.Padding(0);
            this.lblaction.Name = "lblaction";
            this.lblaction.Size = new System.Drawing.Size(425, 30);
            this.lblaction.TabIndex = 2;
            this.lblaction.Text = "...";
            this.lblaction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblnamepos
            // 
            this.lblnamepos.AutoSize = true;
            this.lblnamepos.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblnamepos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblnamepos.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnamepos.ForeColor = System.Drawing.Color.White;
            this.lblnamepos.Location = new System.Drawing.Point(0, 0);
            this.lblnamepos.Margin = new System.Windows.Forms.Padding(0);
            this.lblnamepos.Name = "lblnamepos";
            this.lblnamepos.Size = new System.Drawing.Size(424, 30);
            this.lblnamepos.TabIndex = 1;
            this.lblnamepos.Text = "...";
            this.lblnamepos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pb
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pb, 2);
            this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb.Location = new System.Drawing.Point(0, 290);
            this.pb.Margin = new System.Windows.Forms.Padding(0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(849, 13);
            this.pb.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(225, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(621, 254);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbschedule);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(613, 224);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Schedule";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbschedule
            // 
            this.lbschedule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbschedule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lbschedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbschedule.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbschedule.FullRowSelect = true;
            this.lbschedule.GridLines = true;
            this.lbschedule.Location = new System.Drawing.Point(3, 3);
            this.lbschedule.MultiSelect = false;
            this.lbschedule.Name = "lbschedule";
            this.lbschedule.Size = new System.Drawing.Size(607, 218);
            this.lbschedule.TabIndex = 0;
            this.lbschedule.UseCompatibleStateImageBehavior = false;
            this.lbschedule.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Day";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Schedule";
            this.columnHeader2.Width = 200;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(619, 230);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Attendance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lbattendance, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(613, 224);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // lbattendance
            // 
            this.lbattendance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbattendance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lbattendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbattendance.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbattendance.FullRowSelect = true;
            this.lbattendance.GridLines = true;
            this.lbattendance.Location = new System.Drawing.Point(3, 3);
            this.lbattendance.MultiSelect = false;
            this.lbattendance.Name = "lbattendance";
            this.lbattendance.Size = new System.Drawing.Size(607, 224);
            this.lbattendance.TabIndex = 6;
            this.lbattendance.UseCompatibleStateImageBehavior = false;
            this.lbattendance.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "No.";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date";
            this.columnHeader4.Width = 175;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Time-Attendance";
            this.columnHeader5.Width = 230;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "AM_LATE";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "PM_LATE";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader7.Width = 80;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel4);
            this.tabPage3.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(619, 230);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Summary";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.lbltotalabsemt, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.lbltotalpassslip, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.lbltotalleave, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lbltotallate, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(613, 224);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // lbltotalabsemt
            // 
            this.lbltotalabsemt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltotalabsemt.AutoSize = true;
            this.lbltotalabsemt.Location = new System.Drawing.Point(183, 95);
            this.lbltotalabsemt.Name = "lbltotalabsemt";
            this.lbltotalabsemt.Size = new System.Drawing.Size(21, 19);
            this.lbltotalabsemt.TabIndex = 7;
            this.lbltotalabsemt.Text = "...";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Absent :";
            // 
            // lbltotalpassslip
            // 
            this.lbltotalpassslip.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltotalpassslip.AutoSize = true;
            this.lbltotalpassslip.Location = new System.Drawing.Point(183, 65);
            this.lbltotalpassslip.Name = "lbltotalpassslip";
            this.lbltotalpassslip.Size = new System.Drawing.Size(21, 19);
            this.lbltotalpassslip.TabIndex = 5;
            this.lbltotalpassslip.Text = "...";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pass Slip :";
            // 
            // lbltotalleave
            // 
            this.lbltotalleave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltotalleave.AutoSize = true;
            this.lbltotalleave.Location = new System.Drawing.Point(183, 35);
            this.lbltotalleave.Name = "lbltotalleave";
            this.lbltotalleave.Size = new System.Drawing.Size(21, 19);
            this.lbltotalleave.TabIndex = 3;
            this.lbltotalleave.Text = "...";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Leave :";
            // 
            // lbltotallate
            // 
            this.lbltotallate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltotallate.AutoSize = true;
            this.lbltotallate.Location = new System.Drawing.Point(183, 5);
            this.lbltotallate.Name = "lbltotallate";
            this.lbltotallate.Size = new System.Drawing.Size(21, 19);
            this.lbltotallate.TabIndex = 1;
            this.lbltotallate.Text = "...";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Late :";
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
            // bgwschedule
            // 
            this.bgwschedule.WorkerReportsProgress = true;
            this.bgwschedule.WorkerSupportsCancellation = true;
            // 
            // bgwcutoffdetails
            // 
            this.bgwcutoffdetails.WorkerReportsProgress = true;
            this.bgwcutoffdetails.WorkerSupportsCancellation = true;
            // 
            // emp_payroll_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.Name = "emp_payroll_new";
            this.Size = new System.Drawing.Size(849, 303);
            this.Load += new System.EventHandler(this.emp_payroll_new_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEmpPic)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
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
        private System.ComponentModel.BackgroundWorker bgwattendance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblaction;
        private System.ComponentModel.BackgroundWorker bgwschedule;
        private System.ComponentModel.BackgroundWorker bgwcutoffdetails;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbltotallate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbltotalleave;
        private System.Windows.Forms.Label lbltotalpassslip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbltotalabsemt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lbschedule;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lbattendance;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}
