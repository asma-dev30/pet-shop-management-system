namespace Online_Pet_Shop_Management_System
{
    partial class Manage_Customers
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
            this.Feedback = new System.Windows.Forms.Button();
            this.V_D_Cutomer = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Feedback
            // 
            this.Feedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Feedback.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Feedback.Location = new System.Drawing.Point(203, 194);
            this.Feedback.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Feedback.Name = "Feedback";
            this.Feedback.Size = new System.Drawing.Size(397, 58);
            this.Feedback.TabIndex = 6;
            this.Feedback.Text = "View Feedbacks";
            this.Feedback.UseVisualStyleBackColor = true;
            this.Feedback.Click += new System.EventHandler(this.Feedback_Click);
            // 
            // V_D_Cutomer
            // 
            this.V_D_Cutomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.V_D_Cutomer.ForeColor = System.Drawing.SystemColors.Highlight;
            this.V_D_Cutomer.Location = new System.Drawing.Point(203, 92);
            this.V_D_Cutomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.V_D_Cutomer.Name = "V_D_Cutomer";
            this.V_D_Cutomer.Size = new System.Drawing.Size(397, 58);
            this.V_D_Cutomer.TabIndex = 5;
            this.V_D_Cutomer.Text = "View And Delete Customers";
            this.V_D_Cutomer.UseVisualStyleBackColor = true;
            this.V_D_Cutomer.Click += new System.EventHandler(this.V_D_Cutomer_Click);
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Location = new System.Drawing.Point(697, 395);
            this.Exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(77, 28);
            this.Exit.TabIndex = 34;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.button3.Location = new System.Drawing.Point(323, 290);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 39);
            this.button3.TabIndex = 35;
            this.button3.Text = "Dashboard";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Manage_Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Feedback);
            this.Controls.Add(this.V_D_Cutomer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Manage_Customers";
            this.Text = "Manage_Customers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Feedback;
        private System.Windows.Forms.Button V_D_Cutomer;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button button3;
    }
}