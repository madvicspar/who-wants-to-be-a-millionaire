using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

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
            string audioFilePath = @"../../audios/goodbye-old-punter-2008.mp3";

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
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = @"Data Source=../WhoWantsToBeAMillionaire.db;Version=3";

            cn.Open();

            var cmd = new SQLiteCommand($@"SELECT username, score FROM Players ORDER BY score DESC LIMIT 10", cn);

            var dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            dataGridView1.DataSource = dt;
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
