namespace WindowsFormsApplication1
{
    partial class Dashboard
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
            this.button1 = new System.Windows.Forms.Button();
            this.Testlabel = new System.Windows.Forms.Label();
            this.Querytext = new System.Windows.Forms.TextBox();
            this.Carfoundlistbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Testlabel
            // 
            this.Testlabel.AutoSize = true;
            this.Testlabel.Location = new System.Drawing.Point(134, 15);
            this.Testlabel.Name = "Testlabel";
            this.Testlabel.Size = new System.Drawing.Size(28, 13);
            this.Testlabel.TabIndex = 6;
            this.Testlabel.Text = "Test";
            // 
            // Querytext
            // 
            this.Querytext.Location = new System.Drawing.Point(168, 12);
            this.Querytext.Name = "Querytext";
            this.Querytext.Size = new System.Drawing.Size(100, 20);
            this.Querytext.TabIndex = 5;
            // 
            // Carfoundlistbox
            // 
            this.Carfoundlistbox.FormattingEnabled = true;
            this.Carfoundlistbox.Location = new System.Drawing.Point(16, 92);
            this.Carfoundlistbox.Name = "Carfoundlistbox";
            this.Carfoundlistbox.Size = new System.Drawing.Size(252, 225);
            this.Carfoundlistbox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 329);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Testlabel);
            this.Controls.Add(this.Querytext);
            this.Controls.Add(this.Carfoundlistbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Testlabel;
        private System.Windows.Forms.TextBox Querytext;
        private System.Windows.Forms.ListBox Carfoundlistbox;
    }
}

