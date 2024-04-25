using NAudio.Wave;
using System;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public partial class CallFriend : Form
    {
        int time = 80;
        private Random rnd = new Random();
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        bool isStopped = false;
        public CallFriend()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            timer1.Interval = time;
            label2.Text = time.ToString();
            string audioFilePath = @"../../../audios/khsm_phone_countdown.mp3";

            outputDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(audioFilePath);
            outputDevice.Init(audioFile);
            outputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;
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
            if (Form1.friensNumbers.Contains(maskedTextBox1.Text))
            {
                MessageBox.Show("Я думаю, что правильный ответ - " + Form1.currentQuestion.Answers[rnd.Next(0, 3)]);
                timer1.Stop();
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Абонент не отвечает");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = time.ToString();

            if (time == 0)
            {
                timer1.Stop(); // Останавливаем таймер, если время истекло

                if (Form1.friensNumbers.Contains(maskedTextBox1.Text))
                {
                    MessageBox.Show("Я думаю, что правильный ответ - " + Form1.currentQuestion.Answers[rnd.Next(0, 3)]);
                }
                else
                {
                    MessageBox.Show("Время вышло, абонент не ответил");
                }
            }

            time--;
        }

        private void CallFriend_Load(object sender, EventArgs e)
        {
            outputDevice.Play();
        }

        private void CallFriend_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            isStopped = true;
            outputDevice.Stop();
            audioFile.Dispose();
            outputDevice.Dispose();
        }
    }
}
