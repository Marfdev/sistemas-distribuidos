namespace Calculator
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
            this.ResultsBox = new System.Windows.Forms.TextBox();
            this.n1 = new System.Windows.Forms.Button();
            this.n2 = new System.Windows.Forms.Button();
            this.n3 = new System.Windows.Forms.Button();
            this.n4 = new System.Windows.Forms.Button();
            this.n5 = new System.Windows.Forms.Button();
            this.n6 = new System.Windows.Forms.Button();
            this.n7 = new System.Windows.Forms.Button();
            this.n8 = new System.Windows.Forms.Button();
            this.n9 = new System.Windows.Forms.Button();
            this.n0 = new System.Windows.Forms.Button();
            this.signChange = new System.Windows.Forms.Button();
            this.dotBtn = new System.Windows.Forms.Button();
            this.equalsButton = new System.Windows.Forms.Button();
            this.plusButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.multButton = new System.Windows.Forms.Button();
            this.divButton = new System.Windows.Forms.Button();
            this.backSpace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ResultsBox
            // 
            this.ResultsBox.BackColor = System.Drawing.Color.White;
            this.ResultsBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultsBox.Location = new System.Drawing.Point(4, 4);
            this.ResultsBox.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.ResultsBox.Multiline = true;
            this.ResultsBox.Name = "ResultsBox";
            this.ResultsBox.ReadOnly = true;
            this.ResultsBox.Size = new System.Drawing.Size(460, 74);
            this.ResultsBox.TabIndex = 0;
            this.ResultsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ResultsBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // n1
            // 
            this.n1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.n1.Location = new System.Drawing.Point(0, 484);
            this.n1.Name = "n1";
            this.n1.Size = new System.Drawing.Size(75, 75);
            this.n1.TabIndex = 1;
            this.n1.Text = "1";
            this.n1.UseVisualStyleBackColor = true;
            this.n1.Click += new System.EventHandler(this.n1_Click);
            // 
            // n2
            // 
            this.n2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.n2.Location = new System.Drawing.Point(81, 484);
            this.n2.Name = "n2";
            this.n2.Size = new System.Drawing.Size(75, 75);
            this.n2.TabIndex = 2;
            this.n2.Text = "2";
            this.n2.UseVisualStyleBackColor = true;
            this.n2.Click += new System.EventHandler(this.n2_Click);
            // 
            // n3
            // 
            this.n3.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.n3.Location = new System.Drawing.Point(162, 484);
            this.n3.Name = "n3";
            this.n3.Size = new System.Drawing.Size(75, 75);
            this.n3.TabIndex = 3;
            this.n3.Text = "3";
            this.n3.UseVisualStyleBackColor = true;
            this.n3.Click += new System.EventHandler(this.n3_Click);
            // 
            // n4
            // 
            this.n4.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.n4.Location = new System.Drawing.Point(0, 403);
            this.n4.Name = "n4";
            this.n4.Size = new System.Drawing.Size(75, 75);
            this.n4.TabIndex = 4;
            this.n4.Text = "4";
            this.n4.UseVisualStyleBackColor = true;
            this.n4.Click += new System.EventHandler(this.n4_Click);
            // 
            // n5
            // 
            this.n5.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.n5.Location = new System.Drawing.Point(81, 403);
            this.n5.Name = "n5";
            this.n5.Size = new System.Drawing.Size(75, 75);
            this.n5.TabIndex = 7;
            this.n5.Text = "5";
            this.n5.UseVisualStyleBackColor = true;
            this.n5.Click += new System.EventHandler(this.n5_Click);
            // 
            // n6
            // 
            this.n6.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.n6.Location = new System.Drawing.Point(162, 403);
            this.n6.Name = "n6";
            this.n6.Size = new System.Drawing.Size(75, 75);
            this.n6.TabIndex = 6;
            this.n6.Text = "6";
            this.n6.UseVisualStyleBackColor = true;
            this.n6.Click += new System.EventHandler(this.n6_Click);
            // 
            // n7
            // 
            this.n7.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.n7.Location = new System.Drawing.Point(0, 322);
            this.n7.Name = "n7";
            this.n7.Size = new System.Drawing.Size(75, 75);
            this.n7.TabIndex = 5;
            this.n7.Text = "7";
            this.n7.UseVisualStyleBackColor = true;
            this.n7.Click += new System.EventHandler(this.n7_Click);
            // 
            // n8
            // 
            this.n8.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.n8.Location = new System.Drawing.Point(81, 322);
            this.n8.Name = "n8";
            this.n8.Size = new System.Drawing.Size(75, 75);
            this.n8.TabIndex = 10;
            this.n8.Text = "8";
            this.n8.UseVisualStyleBackColor = true;
            this.n8.Click += new System.EventHandler(this.n8_Click);
            // 
            // n9
            // 
            this.n9.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.n9.Location = new System.Drawing.Point(162, 322);
            this.n9.Name = "n9";
            this.n9.Size = new System.Drawing.Size(75, 75);
            this.n9.TabIndex = 9;
            this.n9.Text = "9";
            this.n9.UseVisualStyleBackColor = true;
            this.n9.Click += new System.EventHandler(this.n9_Click);
            // 
            // n0
            // 
            this.n0.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.n0.Location = new System.Drawing.Point(81, 565);
            this.n0.Name = "n0";
            this.n0.Size = new System.Drawing.Size(75, 75);
            this.n0.TabIndex = 8;
            this.n0.Text = "0";
            this.n0.UseVisualStyleBackColor = true;
            this.n0.Click += new System.EventHandler(this.n0_Click);
            // 
            // signChange
            // 
            this.signChange.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.signChange.Location = new System.Drawing.Point(0, 565);
            this.signChange.Name = "signChange";
            this.signChange.Size = new System.Drawing.Size(75, 75);
            this.signChange.TabIndex = 11;
            this.signChange.Text = "+/-";
            this.signChange.UseVisualStyleBackColor = true;
            // 
            // dotBtn
            // 
            this.dotBtn.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.dotBtn.Location = new System.Drawing.Point(162, 565);
            this.dotBtn.Name = "dotBtn";
            this.dotBtn.Size = new System.Drawing.Size(75, 75);
            this.dotBtn.TabIndex = 12;
            this.dotBtn.Text = ".";
            this.dotBtn.UseVisualStyleBackColor = true;
            // 
            // equalsButton
            // 
            this.equalsButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.equalsButton.Location = new System.Drawing.Point(243, 565);
            this.equalsButton.Name = "equalsButton";
            this.equalsButton.Size = new System.Drawing.Size(75, 75);
            this.equalsButton.TabIndex = 13;
            this.equalsButton.Text = "=";
            this.equalsButton.UseVisualStyleBackColor = true;
            this.equalsButton.Click += new System.EventHandler(this.processCalculations);
            // 
            // plusButton
            // 
            this.plusButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.plusButton.Location = new System.Drawing.Point(243, 484);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(75, 75);
            this.plusButton.TabIndex = 14;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            // 
            // minusButton
            // 
            this.minusButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.minusButton.Location = new System.Drawing.Point(243, 403);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(75, 75);
            this.minusButton.TabIndex = 15;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.minusButton_Click);
            // 
            // multButton
            // 
            this.multButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.multButton.Location = new System.Drawing.Point(243, 322);
            this.multButton.Name = "multButton";
            this.multButton.Size = new System.Drawing.Size(75, 75);
            this.multButton.TabIndex = 16;
            this.multButton.Text = "×";
            this.multButton.UseVisualStyleBackColor = true;
            this.multButton.Click += new System.EventHandler(this.multButton_Click);
            // 
            // divButton
            // 
            this.divButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.divButton.Location = new System.Drawing.Point(243, 241);
            this.divButton.Name = "divButton";
            this.divButton.Size = new System.Drawing.Size(75, 75);
            this.divButton.TabIndex = 17;
            this.divButton.Text = "÷";
            this.divButton.UseVisualStyleBackColor = true;
            this.divButton.Click += new System.EventHandler(this.divButton_Click);
            // 
            // backSpace
            // 
            this.backSpace.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.backSpace.Location = new System.Drawing.Point(243, 160);
            this.backSpace.Name = "backSpace";
            this.backSpace.Size = new System.Drawing.Size(75, 75);
            this.backSpace.TabIndex = 18;
            this.backSpace.Text = "🔙";
            this.backSpace.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 640);
            this.Controls.Add(this.backSpace);
            this.Controls.Add(this.divButton);
            this.Controls.Add(this.multButton);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.equalsButton);
            this.Controls.Add(this.dotBtn);
            this.Controls.Add(this.signChange);
            this.Controls.Add(this.n8);
            this.Controls.Add(this.n9);
            this.Controls.Add(this.n0);
            this.Controls.Add(this.n5);
            this.Controls.Add(this.n6);
            this.Controls.Add(this.n7);
            this.Controls.Add(this.n4);
            this.Controls.Add(this.n3);
            this.Controls.Add(this.n2);
            this.Controls.Add(this.n1);
            this.Controls.Add(this.ResultsBox);
            this.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ResultsBox;
        private System.Windows.Forms.Button n1;
        private System.Windows.Forms.Button n2;
        private System.Windows.Forms.Button n3;
        private System.Windows.Forms.Button n4;
        private System.Windows.Forms.Button n5;
        private System.Windows.Forms.Button n6;
        private System.Windows.Forms.Button n7;
        private System.Windows.Forms.Button n8;
        private System.Windows.Forms.Button n9;
        private System.Windows.Forms.Button n0;
        private System.Windows.Forms.Button signChange;
        private System.Windows.Forms.Button dotBtn;
        private System.Windows.Forms.Button equalsButton;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button multButton;
        private System.Windows.Forms.Button divButton;
        private System.Windows.Forms.Button backSpace;
    }
}

