namespace WhoWantsToBeAMillionaire
{
    partial class CallFriend
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
            components = new System.ComponentModel.Container();
            label1 = new System.Windows.Forms.Label();
            maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            button1 = new System.Windows.Forms.Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label2 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(48, 44);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(284, 29);
            label1.TabIndex = 1;
            label1.Text = "Введите правильный номер. Осталось:";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            maskedTextBox1.Location = new System.Drawing.Point(51, 76);
            maskedTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            maskedTextBox1.Mask = "+7 (000) 000-00-00";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new System.Drawing.Size(352, 27);
            maskedTextBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(51, 118);
            button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(352, 31);
            button1.TabIndex = 3;
            button1.Text = "Готово";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // label2
            // 
            label2.BackColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(338, 44);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 29);
            label2.TabIndex = 4;
            // 
            // CallFriend
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(451, 176);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(maskedTextBox1);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "CallFriend";
            Text = "Кто хочет стать миллионером?";
            FormClosing += CallFriend_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
    }
}