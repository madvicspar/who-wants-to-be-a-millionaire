using System;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public partial class CallFriend : Form
    {
        int time = 80;
        private Random rnd = new Random();
        public CallFriend()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            timer1.Interval = time;
            label2.Text = time.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.friensNumbers.Contains(maskedTextBox1.Text))
            {
                MessageBox.Show("Я думаю, что правильный ответ - ", Form1.currentQuestion.Answers[rnd.Next(0, 3)]);
            }
            else
            {
                MessageBox.Show("Абонент не отвечает");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            label2.Text = time.ToString();

            if (time < 0)
            {
                timer1.Stop(); // Останавливаем таймер, если время истекло

                if (Form1.friensNumbers.Contains(maskedTextBox1.Text))
                {
                    MessageBox.Show("Я думаю, что правильный ответ - ", Form1.currentQuestion.Answers[rnd.Next(0, 3)]);
                }
                else
                {
                    MessageBox.Show("Время вышло, абонент не ответил");
                }
            }
        }
    }
}
