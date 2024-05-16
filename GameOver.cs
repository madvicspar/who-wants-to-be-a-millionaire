using NAudio.Wave;
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
            StartPosition = FormStartPosition.CenterScreen;
            string audioFilePath = @"../../../audios/goodbye-old-punter-2008.mp3";
            outputDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(audioFilePath);
            outputDevice.Init(audioFile);
            outputDevice.Volume = 0.01f;
            outputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;
            outputDevice.Play();
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
                var playersList = dbContext.Players.OrderByDescending(x => x.score).Take(10).ToList();
                dataGridView1.DataSource = playersList;
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private void GameOver_FormClosing(object sender, FormClosingEventArgs e)
        {
            outputDevice.Stop();
            audioFile.Dispose();
            outputDevice.Dispose();
        }
    }
}
