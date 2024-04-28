namespace WhoWantsToBeAMillionaire
{
    partial class StartGame
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
            chbxHelps = new System.Windows.Forms.CheckedListBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            cmbxSums = new System.Windows.Forms.ComboBox();
            btnApply = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            txtbxName = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // chbxHelps
            // 
            chbxHelps.CheckOnClick = true;
            chbxHelps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            chbxHelps.FormattingEnabled = true;
            chbxHelps.Items.AddRange(new object[] { "50 на 50", "Замена вопроса", "Звонок другу", "Помощь зала", "Право на ошибку" });
            chbxHelps.Location = new System.Drawing.Point(45, 109);
            chbxHelps.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            chbxHelps.Name = "chbxHelps";
            chbxHelps.Size = new System.Drawing.Size(308, 158);
            chbxHelps.TabIndex = 0;
            chbxHelps.ItemCheck += checkedListBox1_ItemCheck;
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            label1.Location = new System.Drawing.Point(41, 77);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(308, 29);
            label1.TabIndex = 2;
            label1.Text = "Выберите только 3 подсказки:";
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            label2.Location = new System.Drawing.Point(41, 14);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(308, 29);
            label2.TabIndex = 3;
            label2.Text = "Введите ваше имя:";
            // 
            // cmbxSums
            // 
            cmbxSums.FormattingEnabled = true;
            cmbxSums.Items.AddRange(new object[] { "3 000 000", "1 500 000", "800 000", "400 000", "200 000", "100 000", "50 000", "25 000", "15 000", "10 000", "5 000", "3 000", "2 000", "1 000", "500" });
            cmbxSums.Location = new System.Drawing.Point(45, 314);
            cmbxSums.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cmbxSums.Name = "cmbxSums";
            cmbxSums.Size = new System.Drawing.Size(308, 28);
            cmbxSums.TabIndex = 9;
            // 
            // btnApply
            // 
            btnApply.Location = new System.Drawing.Point(45, 351);
            btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnApply.Name = "btnApply";
            btnApply.Size = new System.Drawing.Size(308, 38);
            btnApply.TabIndex = 8;
            btnApply.Text = "Готово";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            label3.Location = new System.Drawing.Point(41, 277);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(330, 34);
            label3.TabIndex = 7;
            label3.Text = "Выберите несгораемую сумму:";
            // 
            // txtbxName
            // 
            txtbxName.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtbxName.Location = new System.Drawing.Point(45, 37);
            txtbxName.Name = "txtbxName";
            txtbxName.Size = new System.Drawing.Size(308, 30);
            txtbxName.TabIndex = 10;
            // 
            // StartGame
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(398, 406);
            Controls.Add(txtbxName);
            Controls.Add(cmbxSums);
            Controls.Add(btnApply);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(chbxHelps);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "StartGame";
            Text = "Кто хочет стать миллионером?";
            Load += StartGame_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckedListBox chbxHelps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbxSums;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbxName;
    }
}