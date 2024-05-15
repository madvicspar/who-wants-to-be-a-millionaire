using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public partial class ChooseFriends : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        bool isStopped = false;
        public ChooseFriends()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            string audioFilePath = @"../../../audios/hello-new-punter-2008-long.mp3";

            outputDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(audioFilePath);
            outputDevice.Init(audioFile);
            outputDevice.Volume = 0.01f;
            outputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;
            outputDevice.Play();
        }

        private void OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (e.Exception == null && !isStopped) // Проверка на завершение воспроизведения без ошибок
            {
                audioFile.Position = 0; // Сброс позиции аудиофайла на начало
                outputDevice.Play(); // Начать воспроизведение заново
            }
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
            isStopped = true;
            outputDevice.Stop();
            audioFile.Dispose();
            outputDevice.Dispose();
            Form1.friensNumbers = friendsNumbers;
            Form1 form1 = new Form1();
            form1.ShowDialog();
            Close();
        }
    }
}
