using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public partial class Name : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        bool isStopped = false;
        public Name()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            string audioFilePath = @"../../../audios/hello-new-punter-2008-long.mp3";

            outputDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(audioFilePath);
            outputDevice.Init(audioFile);
            outputDevice.PlaybackStopped += Name_OutputDevice_PlaybackStopped;
        }

        private void Name_OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (e.Exception == null && !isStopped) // Проверка на завершение воспроизведения без ошибок
            {
                audioFile.Position = 0; // Сброс позиции аудиофайла на начало
                outputDevice.Play(); // Начать воспроизведение заново
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                Form1.userName = textBox1.Text;
                this.Hide();
                Sum chooseFriends = new Sum();
                isStopped = true;
                outputDevice.Stop();
                audioFile.Dispose();
                outputDevice.Dispose();
                chooseFriends.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Введите имя пользователя");
        }

        private void Name_Load(object sender, EventArgs e)
        {
            outputDevice.Play();
        }
    }
}
