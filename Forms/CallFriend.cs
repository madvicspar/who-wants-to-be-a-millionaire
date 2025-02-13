﻿using System;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public partial class CallFriend : Form
    {
        int time = 80;
        private Random rnd = new Random();
        private AudioManager audioManager;
        public CallFriend()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            timer1.Interval = time;
            label2.Text = time.ToString();
            string audioFilePath = @"../../../audios/khsm_phone_countdown.mp3";
            audioManager = new AudioManager(audioFilePath);
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
                MessageBox.Show("Неправильно введен номер.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = time.ToString() + " сек.";

            if (time == 0)
            {
                timer1.Stop(); // Останавливаем таймер, если время истекло

                maskedTextBox1.Enabled = false;
                button1.Enabled = false;

                if (Form1.friensNumbers.Contains(maskedTextBox1.Text))
                {
                    MessageBox.Show("Мне кажется, что ответ - " + Form1.currentQuestion.Answers[rnd.Next(0, 3)]);
                }
                else
                {
                    MessageBox.Show("Время вышло, вы не успели правильно набрать номер.");
                }
            }

            time--;
        }

        private void CallFriend_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            audioManager.Stop();
        }
    }
}
