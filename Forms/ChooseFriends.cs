using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public partial class ChooseFriends : Form
    {
        private AudioManager audioManager;
        public ChooseFriends()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            string audioFilePath = @"../../../audios/hello-new-punter-2008-long.mp3";
            audioManager = new AudioManager(audioFilePath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var textboxes = new MaskedTextBox[] { maskedTextBox1, maskedTextBox2, maskedTextBox3, maskedTextBox4, maskedTextBox5 };

            foreach (var textbox in textboxes)
            {
                if (!textbox.MaskCompleted)
                {
                    MessageBox.Show("Введите все номера телефонов полностью");
                    return;
                }
            }

            List<string> friendsNumbers = new List<string>();
            foreach (var textbox in textboxes)
            {
                friendsNumbers.Add(textbox.Text);
            }

            ContinueGame(friendsNumbers);
        }

        public void ContinueGame(List<string> friendsNumbers)
        {
            Hide();
            audioManager.Stop();
            Form1.friensNumbers = friendsNumbers;
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
    }
}
