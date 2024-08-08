namespace QuizApp
{
    internal class Question
    {
        public Question(string questions, string[] answers, int correctAnswer)
        {
            CurrentQuestion = questions;
            CorrectAnswer = correctAnswer;
            Answers = answers;
        }
        public string CurrentQuestion { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswer { get; set; }
    }
}
