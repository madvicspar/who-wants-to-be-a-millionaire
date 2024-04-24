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
    public partial class StartGame : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        bool isStopped = false;
        public StartGame()
        {
            InitializeComponent();
            MessageBox.Show("При выборе подсказки 'Звонок другу' вам будет нужно набрать номера телефонов 5 друзей. При активации подсказки будет необходимо по памяти набрать один из этих 5 номеров");
            StartPosition = FormStartPosition.CenterScreen;
            string audioFilePath = @"../../../audios/hello-new-punter-2008-long.mp3";

            outputDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(audioFilePath);
            outputDevice.Init(audioFile);
            outputDevice.PlaybackStopped += start_OutputDevice_PlaybackStopped;
        }

        private void start_OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (e.Exception == null && !isStopped) // Проверка на завершение воспроизведения без ошибок
            {
                audioFile.Position = 0; // Сброс позиции аудиофайла на начало
                outputDevice.Play(); // Начать воспроизведение заново
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 3)
            {
                List<Helps> helps = new List<Helps>();
                foreach (var help in checkedListBox1.CheckedIndices)
                {
                    var help_index = (int)help;
                    switch (help_index)
                    {
                        case 0:
                            helps.Add(Helps.fifty);
                            break;
                        case 1:
                            helps.Add(Helps.changeQuestion);
                            break;
                        case 2:
                            helps.Add(Helps.callFriend);
                            break;
                        case 3:
                            helps.Add(Helps.helpZal);
                            break;
                        case 4:
                            helps.Add(Helps.mayBeWrong);
                            break;
                    }
                }
                this.Hide();
                isStopped = true;
                outputDevice.Stop();
                audioFile.Dispose();
                outputDevice.Dispose();
                if (helps.Contains(Helps.callFriend))
                {
                    Form1.helps = helps;
                    ChooseFriends chooseFriends = new ChooseFriends();
                    chooseFriends.ShowDialog();
                }
                else
                {
                    Form1.helps = helps;
                    Form1 chooseFriends = new Form1();
                    chooseFriends.ShowDialog();
                }
                this.Close();
            }
            else
                MessageBox.Show("Нужно выбрать 3 элемента");
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox checkedListBox = (CheckedListBox)sender;

            if (checkedListBox.CheckedItems.Count >= 3 && e.NewValue == CheckState.Checked)
            {
                e.NewValue = CheckState.Unchecked;
                MessageBox.Show("Можно выбрать только 3 подсказки!");
            }
        }

        private void StartGame_Load(object sender, EventArgs e)
        {
            outputDevice.Play();
        }
    }
}
