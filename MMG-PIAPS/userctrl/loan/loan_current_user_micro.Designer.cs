namespace MMG_PIAPS.userctrl.loan
{
    partial class loan_current_user_micro
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
            this.txtprincipal = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnsave = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblmemdata2 = new System.Windows.Forms.Label();
            this.lblmemdata = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nmamortperiod = new System.Windows.Forms.NumericUpDown();
            this.txtinterest = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtprincipal_amort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtinterest_amort = new System.Windows.Forms.TextBox();
            this.txttotal_amort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtfilingdate = new System.Windows.Forms.DateTimePicker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmamortperiod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtprincipal
            // 
            this.txtprincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtprincipal.Location = new System.Drawing.Point(171, 5);
            this.txtprincipal.Name = "txtprincipal";
            this.txtprincipal.Size = new System.Drawing.Size(118, 22);
            this.txtprincipal.TabIndex = 36;
            this.txtprincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(591, 306);
            this.tableLayoutPanel1.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.btnsave);
            this.panel2.Controls.Add(this.btncancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 265);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(591, 40);
            this.panel2.TabIndex = 2;
            // 
            // btnsave
            // 
            this.btnsave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnsave.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(472, 0);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(119, 40);
            this.btnsave.TabIndex = 2;
            this.btnsave.Text = "&Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btncancel
            // 
            this.btncancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btncancel.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(0, 0);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(119, 40);
            this.btncancel.TabIndex = 1;
            this.btncancel.Text = "&Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 35);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(33, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adding New Micro Loan";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtprincipal, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblmemdata, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblmemdata2, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.nmamortperiod, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtinterest, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtprincipal_amort, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.txtinterest_amort, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.txttotal_amort, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.dtfilingdate, 1, 6);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(585, 224);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // lblmemdata2
            // 
            this.lblmemdata2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblmemdata2.AutoSize = true;
            this.lblmemdata2.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmemdata2.Location = new System.Drawing.Point(296, 37);
            this.lblmemdata2.Name = "lblmemdata2";
            this.lblmemdata2.Size = new System.Drawing.Size(285, 19);
            this.lblmemdata2.TabIndex = 4;
            this.lblmemdata2.Text = "PAID-UP-CAPITAL : ";
            // 
            // lblmemdata
            // 
            this.lblmemdata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblmemdata.AutoSize = true;
            this.lblmemdata.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmemdata.Location = new System.Drawing.Point(296, 6);
            this.lblmemdata.Name = "lblmemdata";
            this.lblmemdata.Size = new System.Drawing.Size(285, 19);
            this.lblmemdata.TabIndex = 3;
            this.lblmemdata.Text = "...";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "Principal:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 15);
            this.label5.TabIndex = 29;
            this.label5.Text = "Amortization Period :";
            // 
            // nmamortperiod
            // 
            this.nmamortperiod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nmamortperiod.Location = new System.Drawing.Point(171, 36);
            this.nmamortperiod.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nmamortperiod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmamortperiod.Name = "nmamortperiod";
            this.nmamortperiod.Size = new System.Drawing.Size(118, 22);
            this.nmamortperiod.TabIndex = 41;
            this.nmamortperiod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nmamortperiod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtinterest
            // 
            this.txtinterest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtinterest.Enabled = false;
            this.txtinterest.Location = new System.Drawing.Point(171, 66);
            this.txtinterest.Name = "txtinterest";
            this.txtinterest.Size = new System.Drawing.Size(118, 22);
            this.txtinterest.TabIndex = 37;
            this.txtinterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 30;
            this.label6.Text = "Interest :";
            // 
            // txtprincipal_amort
            // 
            this.txtprincipal_amort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtprincipal_amort.Enabled = false;
            this.txtprincipal_amort.Location = new System.Drawing.Point(171, 97);
            this.txtprincipal_amort.Name = "txtprincipal_amort";
            this.txtprincipal_amort.Size = new System.Drawing.Size(118, 22);
            this.txtprincipal_amort.TabIndex = 38;
            this.txtprincipal_amort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 15);
            this.label9.TabIndex = 30;
            this.label9.Text = "Amortization on Principal :";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 15);
            this.label10.TabIndex = 31;
            this.label10.Text = "Amortization on Interest :";
            // 
            // txtinterest_amort
            // 
            this.txtinterest_amort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtinterest_amort.Enabled = false;
            this.txtinterest_amort.Location = new System.Drawing.Point(171, 129);
            this.txtinterest_amort.Name = "txtinterest_amort";
            this.txtinterest_amort.Size = new System.Drawing.Size(118, 22);
            this.txtinterest_amort.TabIndex = 38;
            this.txtinterest_amort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txttotal_amort
            // 
            this.txttotal_amort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotal_amort.Enabled = false;
            this.txttotal_amort.Location = new System.Drawing.Point(171, 160);
            this.txttotal_amort.Name = "txttotal_amort";
            this.txttotal_amort.Size = new System.Drawing.Size(118, 22);
            this.txttotal_amort.TabIndex = 38;
            this.txttotal_amort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 15);
            this.label8.TabIndex = 39;
            this.label8.Text = "Total Amortization :";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(95, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 34;
            this.label7.Text = "Date Filed :";
            // 
            // dtfilingdate
            // 
            this.dtfilingdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtfilingdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfilingdate.Location = new System.Drawing.Point(171, 191);
            this.dtfilingdate.Name = "dtfilingdate";
            this.dtfilingdate.Size = new System.Drawing.Size(118, 22);
            this.dtfilingdate.TabIndex = 31;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MMG_PIAPS.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(11, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // loan_current_user_micro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "loan_current_user_micro";
            this.Size = new System.Drawing.Size(591, 306);
            this.Load += new System.EventHandler(this.loan_current_user_micro_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmamortperiod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtprincipal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblmemdata2;
        private System.Windows.Forms.Label lblmemdata;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nmamortperiod;
        private System.Windows.Forms.TextBox txtinterest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtprincipal_amort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtinterest_amort;
        private System.Windows.Forms.TextBox txttotal_amort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtfilingdate;
        private System.Windows.Forms.Timer timer1;
    }
}
