using System.ComponentModel.DataAnnotations.Schema;

namespace WhoWantsToBeAMillionaire
{
    public class Question
    {
        public string QuestionText { get; private set; }
        public string Answer1 { get; private set; }
        public string Answer2 { get; private set; }
        public string Answer3 { get; private set; }
        public string Answer4 { get; private set; }
        [NotMapped]
        public string[] Answers { get; set; }
        public int RightAnswer { get; private set; }
        public int Level { get; private set; }

        public Question() { }
    }
}
