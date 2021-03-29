
using System;

namespace Vending_Machine
{
    partial class VendingMachine
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CardIDDropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CashInput = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.BuyButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ChangeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CardIDDropdown
            // 
            this.CardIDDropdown.FormattingEnabled = true;
            this.CardIDDropdown.Items.AddRange(new object[] {
            "Card ID 1",
            "Card ID 2",
            "Card ID 3",
            "Card ID 4"});
            this.CardIDDropdown.Location = new System.Drawing.Point(470, 14);
            this.CardIDDropdown.Name = "CardIDDropdown";
            this.CardIDDropdown.Size = new System.Drawing.Size(121, 23);
            this.CardIDDropdown.TabIndex = 1;
            this.CardIDDropdown.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(406, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "CardID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 45);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pipsi\r\n£2.00\r\nA1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 45);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cola\r\n£1.70\r\nA2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 45);
            this.label4.TabIndex = 10;
            this.label4.Text = "Diet Pipsi\r\n£2.20\r\nA3";
            // 
            // CashInput
            // 
            this.CashInput.Location = new System.Drawing.Point(295, 14);
            this.CashInput.Name = "CashInput";
            this.CashInput.Size = new System.Drawing.Size(100, 23);
            this.CashInput.TabIndex = 14;
            this.CashInput.TextChanged += new System.EventHandler(this.CashInput_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(238, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 21);
            this.label8.TabIndex = 15;
            this.label8.Text = "Cash";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 45);
            this.label5.TabIndex = 18;
            this.label5.Text = "Diet Dr. Cola\r\n£1.70\r\nB3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(111, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 45);
            this.label6.TabIndex = 17;
            this.label6.Text = "Diet Cola\r\n£2.00\r\nB2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 45);
            this.label7.TabIndex = 16;
            this.label7.Text = "Dr. Cola\r\n£1.50\r\nB1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(190, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 45);
            this.label9.TabIndex = 21;
            this.label9.Text = "Diet Power\r\n£3.40\r\nC3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(111, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 45);
            this.label10.TabIndex = 20;
            this.label10.Text = "Max Power\r\n£3.00\r\nC2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 45);
            this.label11.TabIndex = 19;
            this.label11.Text = "Power Thirst\r\n£3.40\r\nC1";
            // 
            // textBox2
            // 
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Location = new System.Drawing.Point(404, 181);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 22;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // BuyButton
            // 
            this.BuyButton.Location = new System.Drawing.Point(417, 229);
            this.BuyButton.Name = "BuyButton";
            this.BuyButton.Size = new System.Drawing.Size(75, 23);
            this.BuyButton.TabIndex = 23;
            this.BuyButton.Text = "Buy";
            this.BuyButton.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(415, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 15);
            this.label12.TabIndex = 24;
            this.label12.Text = "Enter Drink ID";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(238, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 21);
            this.label13.TabIndex = 25;
            this.label13.Text = "Change:";
            // 
            // ChangeLabel
            // 
            this.ChangeLabel.AutoSize = true;
            this.ChangeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChangeLabel.Location = new System.Drawing.Point(318, 48);
            this.ChangeLabel.Name = "ChangeLabel";
            this.ChangeLabel.Size = new System.Drawing.Size(49, 21);
            this.ChangeLabel.TabIndex = 26;
            this.ChangeLabel.Text = "£0.00";
            // 
            // VendingMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 344);
            this.Controls.Add(this.ChangeLabel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.BuyButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CashInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CardIDDropdown);
            this.Name = "VendingMachine";
            this.Text = "Vending Machine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.ComboBox CardIDDropdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CashInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button BuyButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label ChangeLabel;
    }
}

