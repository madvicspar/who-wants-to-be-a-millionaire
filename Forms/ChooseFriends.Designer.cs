namespace WhoWantsToBeAMillionaire
{
    partial class ChooseFriends
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
            maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            maskedTextBox4 = new System.Windows.Forms.MaskedTextBox();
            maskedTextBox5 = new System.Windows.Forms.MaskedTextBox();
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            maskedTextBox1.Location = new System.Drawing.Point(46, 44);
            maskedTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            maskedTextBox1.Mask = "+7 (000) 000-00-00";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new System.Drawing.Size(297, 27);
            maskedTextBox1.TabIndex = 0;
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            maskedTextBox2.Location = new System.Drawing.Point(46, 209);
            maskedTextBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            maskedTextBox2.Mask = "+7 (000) 000-00-00";
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new System.Drawing.Size(297, 27);
            maskedTextBox2.TabIndex = 4;
            // 
            // maskedTextBox3
            // 
            maskedTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            maskedTextBox3.Location = new System.Drawing.Point(46, 168);
            maskedTextBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            maskedTextBox3.Mask = "+7 (000) 000-00-00";
            maskedTextBox3.Name = "maskedTextBox3";
            maskedTextBox3.Size = new System.Drawing.Size(297, 27);
            maskedTextBox3.TabIndex = 3;
            // 
            // maskedTextBox4
            // 
            maskedTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            maskedTextBox4.Location = new System.Drawing.Point(46, 127);
            maskedTextBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            maskedTextBox4.Mask = "+7 (000) 000-00-00";
            maskedTextBox4.Name = "maskedTextBox4";
            maskedTextBox4.Size = new System.Drawing.Size(297, 27);
            maskedTextBox4.TabIndex = 2;
            // 
            // maskedTextBox5
            // 
            maskedTextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            maskedTextBox5.Location = new System.Drawing.Point(46, 85);
            maskedTextBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            maskedTextBox5.Mask = "+7 (000) 000-00-00";
            maskedTextBox5.Name = "maskedTextBox5";
            maskedTextBox5.Size = new System.Drawing.Size(297, 27);
            maskedTextBox5.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            button1.Location = new System.Drawing.Point(46, 251);
            button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(297, 45);
            button1.TabIndex = 5;
            button1.Text = "Готово";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            label1.Location = new System.Drawing.Point(41, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(215, 29);
            label1.TabIndex = 6;
            label1.Text = "Введите номера друзей";
            // 
            // ChooseFriends
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(387, 311);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(maskedTextBox5);
            Controls.Add(maskedTextBox4);
            Controls.Add(maskedTextBox3);
            Controls.Add(maskedTextBox2);
            Controls.Add(maskedTextBox1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "ChooseFriends";
            Text = "Кто хочет стать миллионером?";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}