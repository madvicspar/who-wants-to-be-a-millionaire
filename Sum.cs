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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WhoWantsToBeAMillionaire
{
    public partial class Sum : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        bool isStopped = false;
        public Sum()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            StartPosition = FormStartPosition.CenterScreen;
            string audioFilePath = @"../../audios/hello-new-punter-2008-long.mp3";

            outputDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(audioFilePath);
            outputDevice.Init(audioFile);
            outputDevice.PlaybackStopped += sum_OutputDevice_PlaybackStopped;
        }

        private void sum_OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (e.Exception == null && !isStopped) // Проверка на завершение воспроизведения без ошибок
            {
                audioFile.Position = 0; // Сброс позиции аудиофайла на начало
                outputDevice.Play(); // Начать воспроизведение заново
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.fireproofAmountLevel = comboBox1.Items.Count - comboBox1.SelectedIndex;
            this.Hide();
            isStopped = true;
            outputDevice.Stop();
            audioFile.Dispose();
            outputDevice.Dispose();
            StartGame chooseFriends = new StartGame();
            chooseFriends.ShowDialog();
            this.Close();
        }

        private void Sum_Load(object sender, EventArgs e)
        {
            outputDevice.Play();
        }
    }
}
