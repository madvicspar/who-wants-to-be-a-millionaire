﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public enum Helps
    {
        fifty, changeQuestion, mayBeWrong, callFriend, helpZal
    }
    public partial class Form1 : Form
    {
        public static string userName;
        public static List<Helps> helps = new List<Helps>();
        public static List<string> friensNumbers = new List<string>();
        List<Question> questions = new List<Question>();
        private Random rnd = new Random();
        int level = 0;
        public static Question currentQuestion;
        bool isMayBeWrong = false;
        public static int fireproofAmountLevel = 2;
        List<int> summas = new List<int>() { 3_000_000, 1_500_000, 800_000, 400_000, 200_000, 100_000, 50_000, 25_000, 15_000, 10_000, 5_000, 3_000, 2_000, 1_000, 500 } ;

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        bool isStopped = false;
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            startGame();
            GetQuestion(level);
            CheckHelps();
            string audioFilePath = @"../../../audios/q1-5-bed-2008.mp3";

            outputDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(audioFilePath);
            outputDevice.Init(audioFile);
            outputDevice.Volume = 0.01f;
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

        public void CheckHelps()
        {
            btnFifty.Enabled = false;
            btnChangeQuestion.Enabled = false;
            btnCallFriend.Enabled = false;
            btnHelpZal.Enabled = false;
            btnWrongRight.Enabled = false;
            foreach (var help in helps)
            {
                switch (help)
                {
                    case Helps.fifty:
                        btnFifty.Enabled = true;
                        break;
                    case Helps.changeQuestion: 
                        btnChangeQuestion.Enabled = true;
                        break;
                    case Helps.callFriend:
                        btnCallFriend.Enabled = true;
                        break;
                    case Helps.helpZal:
                        btnHelpZal.Enabled = true;
                        break;
                    case Helps.mayBeWrong:
                        btnWrongRight.Enabled = true;
                        break;
                }
            }
        }

        private void ShowQuestion(Question q)
        {
            lblQuestion.Text = q.QuestionText;
            btnAnswerA.Text = "A. " + q.Answers[0];
            btnAnswerB.Text = "B. " + q.Answers[1];
            btnAnswerC.Text = "C. " + q.Answers[2];
            btnAnswerD.Text = "D. " + q.Answers[3];
        }

        private Question GetQuestion(int level)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var playersList = dbContext.Questions.ToList();
                foreach (var question in playersList)
                {
                    question.Answers = new string[] { question.Answer1, question.Answer2, question.Answer3, question.Answer4 };
                }
                questions = playersList;
            }
            return questions[rnd.Next(0, questions.Count - 1)];
        }



        private void NextStep()
        {
            if (level == 14)
                FinishGame();
            Button[] btns = new Button[] { btnAnswerA, btnAnswerB,
btnAnswerC, btnAnswerD };

            foreach (Button btn in btns)
                btn.Enabled = true;

            level++;
            currentQuestion = GetQuestion(level);
            ShowQuestion(currentQuestion);
            lstLevel.SelectedIndex = lstLevel.Items.Count - level;
        }

        private void FinishGame()
        {
            AddNote();
            this.Hide();
            isStopped = true;
            outputDevice.Stop();
            audioFile.Dispose();
            outputDevice.Dispose();
            GameOver gameOver = new GameOver();
            gameOver.ShowDialog();
            this.Close();
        }

        private void AddNote()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                if (level != 0)
                    dbContext.Players.Add(new Player() { username = userName, score = summas[summas.Count - level - 1] } );
                else
                    dbContext.Players.Add(new Player() { username = userName, score = 0 });
                dbContext.SaveChanges();
            }
        }

        private void startGame()
        {
            level = 0;
            NextStep();
        }

        private void btnFifty_Click(object sender, EventArgs e)
        {
            btnFifty.Enabled = false;

            // Получаем все кнопки с вариантами ответов
            Button[] btns = new Button[] { btnAnswerA, btnAnswerB, btnAnswerC, btnAnswerD };

            // Определяем кол-во доступных кнопок ответов
            var btnsEnabled = btns.Count(btn => btn.Enabled);

            // Получаем индексы кнопок с неправильными ответами
            List<int> wrongAnswerIndices = Enumerable.Range(0, btns.Length)
                                                    .Where(i => btns[i].Enabled && i + 1 != currentQuestion.RightAnswer) // currentQuestion.RightAnswer - индекс правильного ответа
                                                    .ToList();

            // Отключаем две случайные кнопки с неправильными ответами
            for (int i = 0; i < btnsEnabled / 2 && wrongAnswerIndices.Count > 0; i++)
            {
                int randomIndex = rnd.Next(0, wrongAnswerIndices.Count);
                int buttonIndexToDisable = wrongAnswerIndices[randomIndex];

                // Отключаем кнопку
                btns[buttonIndexToDisable].Enabled = false;

                wrongAnswerIndices.RemoveAt(randomIndex);
            }
        }

        private void btnChangeQuestion_Click(object sender, EventArgs e)
        {
            btnChangeQuestion.Enabled = false;
            Button[] btns = new Button[] { btnAnswerA, btnAnswerB, btnAnswerC, btnAnswerD };

            foreach (Button btn in btns)
                btn.Enabled = true;

            currentQuestion = questions[rnd.Next(0, questions.Count - 1)]; ;
            ShowQuestion(currentQuestion);
        }

        private void btnWrongRight_Click(object sender, EventArgs e)
        {
            btnWrongRight.Enabled = false;
            isMayBeWrong = true;
        }

        private void btnCallFriend_Click(object sender, EventArgs e)
        {
            btnCallFriend.Enabled = false;
            isStopped = true;
            outputDevice.Stop();
            CallFriend callFriend = new CallFriend();
            callFriend.FormClosed += (s, args) =>
            {
                outputDevice.Play();
                isStopped = false;
            };
            callFriend.ShowDialog();
        }

        private void btnHelpZal_Click(object sender, EventArgs e)
        {
            btnHelpZal.Enabled = false;
            HelpZal form = new HelpZal();
            form.currentQuestion = currentQuestion;
            form.GetProbability();
            form.Show();
        }

        private void btnAnswerA_Click(object sender, EventArgs e)
        {
            if (currentQuestion.RightAnswer == 1)
            {
                if (isMayBeWrong)
                {
                    isMayBeWrong = false;
                }
                NextStep();
                return;
            }
            else
            {
                if (isMayBeWrong)
                {
                    isMayBeWrong = false;
                    btnAnswerA.Enabled = false;
                }
                else
                {
                    if (level >= fireproofAmountLevel)
                    {
                        if (level != 14)
                            level = fireproofAmountLevel;
                    }
                    else
                        level = 0;
                    FinishGame();
                }
            }
        }

        private void btnAnswerB_Click(object sender, EventArgs e)
        {
            if (currentQuestion.RightAnswer == 2)
            {
                if (isMayBeWrong)
                {
                    isMayBeWrong = false;
                }
                NextStep();
                return;
            }
            else
            {
                if (isMayBeWrong)
                {
                    btnAnswerB.Enabled = false;
                    isMayBeWrong = false;
                }
                else
                {
                    if (level >= fireproofAmountLevel)
                    {
                        if (level != 14)
                            level = fireproofAmountLevel;
                    }
                    else
                        level = 0;
                    FinishGame();
                }
            }
        }

        private void btnAnswerC_Click(object sender, EventArgs e)
        {
            if (currentQuestion.RightAnswer == 3)
            {
                if (isMayBeWrong)
                {
                    isMayBeWrong = false;
                }
                NextStep();
                return;
            }
            else
            {
                if (isMayBeWrong)
                {
                    isMayBeWrong = false;
                    btnAnswerC.Enabled = false;
                }
                else
                {
                    if (level >= fireproofAmountLevel)
                    {
                        if (level != 14)
                            level = fireproofAmountLevel;
                    }
                    else
                        level = 0;
                    FinishGame();
                }
            }
        }

        private void btnAnswerD_Click(object sender, EventArgs e)
        {
            if (currentQuestion.RightAnswer == 4)
            {
                if (isMayBeWrong)
                {
                    isMayBeWrong = false;
                }
                NextStep();
                return;
            }
            else
            {
                if (isMayBeWrong)
                {
                    isMayBeWrong = false;
                    btnAnswerD.Enabled = false;
                }
                else
                {
                    if (level >= fireproofAmountLevel)
                    {
                        if (level != 14)
                            level = fireproofAmountLevel;
                    }
                    else
                        level = 0;
                    FinishGame();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            outputDevice.Play();
        }
    }
}
