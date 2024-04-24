using NAudio.Wave;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public partial class GameOver : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        public GameOver()
        {
            InitializeComponent();
            LoadData();
            string audioFilePath = @"../../../audios/goodbye-old-punter-2008.mp3";
            outputDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(audioFilePath);
            outputDevice.Init(audioFile);
            outputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;
        }

        private void OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (e.Exception == null) // Проверка на завершение воспроизведения без ошибок
            {
                audioFile.Position = 0; // Сброс позиции аудиофайла на начало
                outputDevice.Play(); // Начать воспроизведение заново
            }
        }

        public void LoadData()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var playersList = dbContext.Players.ToList();
                dataGridView1.DataSource = playersList;
            }
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            outputDevice.Play();
        }

        private void GameOver_FormClosing(object sender, FormClosingEventArgs e)
        {
            outputDevice.Stop();
            audioFile.Dispose();
            outputDevice.Dispose();
        }
    }
}
