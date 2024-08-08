namespace QuizApp
{
    internal class Quizz
    {
        private readonly Question[] _questions;
        public Quizz(Question[] questions)
        {
            _questions = questions;
        }
        public static int TotalPoints = 0;
        public void StartQuiz()
        {
            for (int i = 0; i < _questions.Length; i++)
            {
                Console.WriteLine("Question N.{0}", i + 1);
                displayQuestions(_questions[i]);

            }
            Console.WriteLine("Total Points are: {0}", TotalPoints);
            if (TotalPoints == 3)
                Console.WriteLine("You are  a winner dude");
            else if (TotalPoints == 2)
                Console.WriteLine("Average Guyt");
            else
                Console.WriteLine("Looser, you suck!");
        }

        private void displayQuestions(Question question)
        {
            int choosen = 0;
            while (choosen == 0)
            {
                for (int j = 0; j < question.Answers.Length; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" {0}. ", j + 1);
                    Console.ResetColor();
                    Console.Write(" {0}", question.Answers[j]);
                }
                Console.Write("\nEnter Your answer in numbers: ");
                choosen = GetUserChoice(Console.ReadLine());
            }
            bool isCorrect = CheckForCorectness(choosen, question.CorrectAnswer);

            if (isCorrect)
                Console.WriteLine("Boom that's correct");
            else
                Console.WriteLine("Yikes, you missed");
        }

        private int GetUserChoice(string choice)
        {
            bool parse = int.TryParse(choice, out int result);
            if (parse)
                return result;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter in numbers!!!!!");
            Console.ResetColor();
            return 0;
        }
        private bool CheckForCorectness(int choosenNumber, int correctAnswer)
        {
            if (choosenNumber == correctAnswer)
            {
                TotalPoints++;
                return true;
            }
            return false;
        }
    }
}
