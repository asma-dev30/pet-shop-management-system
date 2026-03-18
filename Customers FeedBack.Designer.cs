namespace Online_Pet_Shop_Management_System
{
    partial class Customers_FeedBack
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
            this.label1 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.TextBox();
            this.Messagetb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Readed = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.DB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sf,
            this.Column1});
            this.dgv.Location = new System.Drawing.Point(191, 24);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(453, 164);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
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
            this.Column1.HeaderText = "FeedBack";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(203, 215);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(100, 22);
            this.ID.TabIndex = 2;
            // 
            // Messagetb
            // 
            this.Messagetb.Location = new System.Drawing.Point(203, 271);
            this.Messagetb.Multiline = true;
            this.Messagetb.Name = "Messagetb";
            this.Messagetb.Size = new System.Drawing.Size(564, 156);
            this.Messagetb.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Message";
            // 
            // Readed
            // 
            this.Readed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Readed.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Readed.Location = new System.Drawing.Point(863, 242);
            this.Readed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Readed.Name = "Readed";
            this.Readed.Size = new System.Drawing.Size(101, 38);
            this.Readed.TabIndex = 37;
            this.Readed.Text = "Readed";
            this.Readed.UseVisualStyleBackColor = true;
            this.Readed.Click += new System.EventHandler(this.Readed_Click);
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Location = new System.Drawing.Point(873, 348);
            this.Exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(77, 28);
            this.Exit.TabIndex = 38;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // DB
            // 
            this.DB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DB.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.DB.Location = new System.Drawing.Point(846, 294);
            this.DB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DB.Name = "DB";
            this.DB.Size = new System.Drawing.Size(139, 39);
            this.DB.TabIndex = 39;
            this.DB.Text = "Dashboard";
            this.DB.UseVisualStyleBackColor = true;
            this.DB.Click += new System.EventHandler(this.DB_Click);
            // 
            // Customers_FeedBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 470);
            this.Controls.Add(this.DB);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Readed);
            this.Controls.Add(this.Messagetb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.Name = "Customers_FeedBack";
            this.Text = "Customers_FeedBack";
            this.Load += new System.EventHandler(this.Customers_FeedBack_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.TextBox Messagetb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button Readed;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button DB;
    }
}