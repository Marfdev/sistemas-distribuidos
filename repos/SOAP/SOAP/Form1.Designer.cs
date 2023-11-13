namespace SOAP
{
    partial class Form1
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
            this.substractbtn = new System.Windows.Forms.Button();
            this.multiplybtn = new System.Windows.Forms.Button();
            this.numonetxtbox = new System.Windows.Forms.TextBox();
            this.resulttxtbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // substractbtn
            // 
            this.substractbtn.Location = new System.Drawing.Point(9, 36);
            this.substractbtn.Name = "substractbtn";
            this.substractbtn.Size = new System.Drawing.Size(102, 23);
            this.substractbtn.TabIndex = 0;
            this.substractbtn.Text = "substract";
            this.substractbtn.UseVisualStyleBackColor = true;
            // 
            // multiplybtn
            // 
            this.multiplybtn.Location = new System.Drawing.Point(9, 68);
            this.multiplybtn.Name = "multiplybtn";
            this.multiplybtn.Size = new System.Drawing.Size(102, 23);
            this.multiplybtn.TabIndex = 0;
            this.multiplybtn.Text = "multiply";
            this.multiplybtn.UseVisualStyleBackColor = true;
            // 
            // numonetxtbox
            // 
            this.numonetxtbox.Location = new System.Drawing.Point(10, 10);
            this.numonetxtbox.Name = "numonetxtbox";
            this.numonetxtbox.Size = new System.Drawing.Size(100, 20);
            this.numonetxtbox.TabIndex = 1;
            // 
            // resulttxtbox
            // 
            this.resulttxtbox.Location = new System.Drawing.Point(10, 97);
            this.resulttxtbox.Name = "resulttxtbox";
            this.resulttxtbox.ReadOnly = true;
            this.resulttxtbox.Size = new System.Drawing.Size(100, 20);
            this.resulttxtbox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 135);
            this.Controls.Add(this.resulttxtbox);
            this.Controls.Add(this.numonetxtbox);
            this.Controls.Add(this.multiplybtn);
            this.Controls.Add(this.substractbtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button substractbtn;
        private System.Windows.Forms.Button multiplybtn;
        private System.Windows.Forms.TextBox numonetxtbox;
        private System.Windows.Forms.TextBox resulttxtbox;
    }
}

