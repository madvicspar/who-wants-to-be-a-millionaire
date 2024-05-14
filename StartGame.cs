﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public partial class StartGame : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private bool IsStopped = false;
        public StartGame()
        {
            InitializeComponent();
            string audioFilePath = @"../../../audios/hello-new-punter-2008-long.mp3";

            outputDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(audioFilePath);
            outputDevice.Init(audioFile);
            outputDevice.Volume = 0.01f;
            outputDevice.PlaybackStopped += start_OutputDevice_PlaybackStopped;
            outputDevice.Play();
        }

        private void start_OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (e.Exception == null && !IsStopped) // Проверка на завершение воспроизведения без ошибок
            {
                audioFile.Position = 0; // Сброс позиции аудиофайла на начало
                outputDevice.Play(); // Начать воспроизведение заново
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 2 && e.CurrentValue == CheckState.Unchecked)
                MessageBox.Show("При активации подсказки будет необходимо по памяти набрать набранных вами далее 5 номеров");

            CheckedListBox checkedListBox = (CheckedListBox)sender;

            if (checkedListBox.CheckedItems.Count >= 3 && e.NewValue == CheckState.Checked)
            {
                e.NewValue = CheckState.Unchecked;
                MessageBox.Show("Можно выбрать только 3 подсказки!");
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbxName.Text))
            {
                Form1.userName = txtbxName.Text;
                Form1.fireproofAmountLevel = cmbxSums.Items.Count - cmbxSums.SelectedIndex - 1;
                if (chbxHelps.CheckedItems.Count == 3)
                {
                    ContinueGame();
                }
                else
                    MessageBox.Show("Нужно выбрать 3 подсказки");
            }
            else
                MessageBox.Show("Введите имя пользователя");
        }

        public List<Helps> GetHelps()
        {
            List<Helps> helps = new List<Helps>();
            foreach (var help in chbxHelps.CheckedIndices)
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
            return helps;
        }

        public void ContinueGame()
        {
            List<Helps> helps = GetHelps();
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
    }
}
