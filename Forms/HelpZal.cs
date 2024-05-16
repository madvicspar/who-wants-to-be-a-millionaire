using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WhoWantsToBeAMillionaire.Models;

namespace WhoWantsToBeAMillionaire
{
    public partial class HelpZal : Form
    {
        public Question currentQuestion;
        private Random rnd = new Random();

        public HelpZal()
        {
            InitializeComponent();
        }

        public void GetProbability()
        {
            List<int> answersProbability = new List<int>(4) { 0, 0, 0, 0 };
            int rightProbability = rnd.Next(40, 71); // generate a random number between 40 and 70 inclusive
            answersProbability[currentQuestion.RightAnswer - 1] = rightProbability;
            int remainingProbability = 100 - rightProbability;
            for (int i = 0; i < answersProbability.Count; i++)
            {
                if (i != currentQuestion.RightAnswer - 1)
                {
                    var temp = rnd.Next(0, remainingProbability + 1); // generate a random number between 0 and the remaining probability inclusive
                    answersProbability[i] = temp;
                    remainingProbability -= temp;
                }
            }

            GetChart(answersProbability);
        }

        private void GetChart(List<int> answersProbability)
        {
            StartPosition = FormStartPosition.CenterScreen;

            var answers = new[] { "Ответ A", "Ответ B", "Ответ C", "Ответ D" };
            var probabilities = answersProbability;


            chart1.Legends.Clear();
            chart1.Legends.Add(new Legend("1")); // Add legend
            chart1.Legends[0].Docking = Docking.Bottom; // Dock legend to bottom
            chart1.Legends[0].Alignment = StringAlignment.Center; // Center legend text

            chart1.Series.Clear();
            for (int i = 0; i < answers.Length; i++)
            {
                chart1.Series.Add(answers[i]);
                chart1.Series[answers[i]].Points.AddY(probabilities[i]);
            }

            label1.Text = currentQuestion.QuestionText;
        }
    }
}
