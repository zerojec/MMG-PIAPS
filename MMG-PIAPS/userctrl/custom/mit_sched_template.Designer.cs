namespace MMG_PIAPS.userctrl.custom
{
    partial class mit_sched_template
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chk = new System.Windows.Forms.CheckBox();
            this.cbo = new System.Windows.Forms.ComboBox();
            this.lblamin = new System.Windows.Forms.Label();
            this.lblamout = new System.Windows.Forms.Label();
            this.lblpmin = new System.Windows.Forms.Label();
            this.lblpmout = new System.Windows.Forms.Label();
            this.lblhour = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.chk, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblamin, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblamout, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblpmin, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblpmout, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblhour, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(567, 36);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chk
            // 
            this.chk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chk.AutoSize = true;
            this.chk.Checked = true;
            this.chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk.Location = new System.Drawing.Point(3, 11);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(15, 14);
            this.chk.TabIndex = 0;
            this.chk.UseVisualStyleBackColor = true;
            this.chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // cbo
            // 
            this.cbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo.Enabled = false;
            this.cbo.FormattingEnabled = true;
            this.cbo.Location = new System.Drawing.Point(24, 7);
            this.cbo.Name = "cbo";
            this.cbo.Size = new System.Drawing.Size(194, 23);
            this.cbo.TabIndex = 1;
            this.cbo.SelectedIndexChanged += new System.EventHandler(this.cbo_SelectedIndexChanged);
            this.cbo.TextChanged += new System.EventHandler(this.cbo_TextChanged);
            this.cbo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_KeyPress);
            // 
            // lblamin
            // 
            this.lblamin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblamin.AutoSize = true;
            this.lblamin.Location = new System.Drawing.Point(236, 10);
            this.lblamin.Name = "lblamin";
            this.lblamin.Size = new System.Drawing.Size(51, 15);
            this.lblamin.TabIndex = 2;
            this.lblamin.Text = "AM_IN :";
            // 
            // lblamout
            // 
            this.lblamout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblamout.AutoSize = true;
            this.lblamout.Location = new System.Drawing.Point(293, 10);
            this.lblamout.Name = "lblamout";
            this.lblamout.Size = new System.Drawing.Size(63, 15);
            this.lblamout.TabIndex = 3;
            this.lblamout.Text = "AM_OUT :";
            // 
            // lblpmin
            // 
            this.lblpmin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblpmin.AutoSize = true;
            this.lblpmin.Location = new System.Drawing.Point(375, 10);
            this.lblpmin.Name = "lblpmin";
            this.lblpmin.Size = new System.Drawing.Size(50, 15);
            this.lblpmin.TabIndex = 4;
            this.lblpmin.Text = "PM_IN :";
            // 
            // lblpmout
            // 
            this.lblpmout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblpmout.AutoSize = true;
            this.lblpmout.Location = new System.Drawing.Point(432, 10);
            this.lblpmout.Name = "lblpmout";
            this.lblpmout.Size = new System.Drawing.Size(62, 15);
            this.lblpmout.TabIndex = 5;
            this.lblpmout.Text = "PM_OUT :";
            // 
            // lblhour
            // 
            this.lblhour.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblhour.AutoSize = true;
            this.lblhour.Location = new System.Drawing.Point(510, 10);
            this.lblhour.Name = "lblhour";
            this.lblhour.Size = new System.Drawing.Size(54, 15);
            this.lblhour.TabIndex = 6;
            this.lblhour.Text = "HOURS :";
            // 
            // mit_sched_template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "mit_sched_template";
            this.Size = new System.Drawing.Size(567, 36);
            this.Load += new System.EventHandler(this.mit_sched_template_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chk;
        private System.Windows.Forms.ComboBox cbo;
        private System.Windows.Forms.Label lblamin;
        private System.Windows.Forms.Label lblamout;
        private System.Windows.Forms.Label lblpmin;
        private System.Windows.Forms.Label lblpmout;
        private System.Windows.Forms.Label lblhour;
    }
}
