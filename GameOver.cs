using NAudio.Wave;
using System.Linq;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public partial class GameOver : Form
    {
        private AudioManager audioManager;
        public GameOver()
        {
            InitializeComponent();
            LoadData();
            StartPosition = FormStartPosition.CenterScreen;
            string audioFilePath = @"../../../audios/goodbye-old-punter-2008.mp3";
            audioManager = new AudioManager(audioFilePath);
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
            audioManager.Stop();
        }
    }
}
