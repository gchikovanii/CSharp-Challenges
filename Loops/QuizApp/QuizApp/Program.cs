using QuizApp;

Question[] questions =
{
    new Question("What is the capital of Georgia",new string[]{"Tbilisi","Gori","Chkorotsku","Senaki"},1),
    new Question("What is the capital of France",new string[]{"Tbilisi","Gori","Paris", "kutaisi"},3),
    new Question("What is the capital of Germany",new string[]{"Tbilisi","Gori","Chkorotsku", " Berlin"},4)
};

Quizz quiz = new Quizz(questions);
quiz.StartQuiz();
Console.ReadLine();