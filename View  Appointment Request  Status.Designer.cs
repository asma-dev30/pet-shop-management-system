namespace Online_Pet_Shop_Management_System
{
    partial class View__Appointment_Request__Status
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.sf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.btnconfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sf,
            this.Column1,
            this.Column2});
            this.dgv.Location = new System.Drawing.Point(86, 12);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(430, 331);
            this.dgv.TabIndex = 1;
            // 
            // sf
            // 
            this.sf.HeaderText = "Customer ID";
            this.sf.MinimumWidth = 6;
            this.sf.Name = "sf";
            this.sf.Width = 125;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Appointment Date";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Request";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // DB
            // 
            this.DB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DB.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.DB.Location = new System.Drawing.Point(176, 366);
            this.DB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DB.Name = "DB";
            this.DB.Size = new System.Drawing.Size(139, 63);
            this.DB.TabIndex = 41;
            this.DB.Text = "Dashboard";
            this.DB.UseVisualStyleBackColor = true;
            this.DB.Click += new System.EventHandler(this.DB_Click);
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Location = new System.Drawing.Point(391, 383);
            this.Exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(77, 46);
            this.Exit.TabIndex = 40;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // btnconfirm
            // 
            this.btnconfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconfirm.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btnconfirm.Location = new System.Drawing.Point(564, 99);
            this.btnconfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(139, 63);
            this.btnconfirm.TabIndex = 42;
            this.btnconfirm.Text = "Confirmed";
            this.btnconfirm.UseVisualStyleBackColor = true;
            this.btnconfirm.Click += new System.EventHandler(this.btnconfirm_Click);
            // 
            // View__Appointment_Request__Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnconfirm);
            this.Controls.Add(this.DB);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.dgv);
            this.Name = "View__Appointment_Request__Status";
            this.Text = "View__Appointment_Request__Status";
            this.Load += new System.EventHandler(this.View__Appointment_Request__Status_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn sf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button DB;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button btnconfirm;
    }
}