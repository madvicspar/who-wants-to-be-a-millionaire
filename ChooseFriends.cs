using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public partial class ChooseFriends : Form
    {
        public ChooseFriends()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var textboxes = new MaskedTextBox[] { maskedTextBox1, maskedTextBox2, maskedTextBox3, maskedTextBox4, maskedTextBox5 };

            //foreach (var textbox in textboxes)
            //{
            //    if (!textbox.MaskCompleted)
            //    {
            //        MessageBox.Show("Введите все номера телефонов полностью");
            //        return;
            //    }
            //}
            List<string> friensNumbers = new List<string>();
            foreach (var textbox in textboxes)
            {
                friensNumbers.Add(textbox.Text);
            }
            this.Hide();
            Form1.friensNumbers = friensNumbers;
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    }
}
