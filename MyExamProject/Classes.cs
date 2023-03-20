using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExamProject
{
    class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public List<QuizResult> QuizResults;
        public User() { }
        public User(string login, string password, DateTime birthDate)
        {
            Login = login;
            Password = password;
            BirthDate = birthDate;
        }
    }
    //public class Question
    //{
    //    public string Text { get; set; }
    //    public List<string> Answers { get; set; }
    //    public List<int> CorrectAnswers { get; set; }

    //    public Question(string text, List<string> answers, List<int> correctAnswers)
    //    {
    //        Text = text;
    //        Answers = answers;
    //        CorrectAnswers = correctAnswers;
    //    }
    //}
    //public class Quiz
    //{
    //    public string Name { get; set; }
    //    public List<Question> Questions { get; set; }
    //    public Quiz(string name)
    //    {
    //        Name = name;
    //    }
    //    public Quiz(string name, List<Question> questions)
    //    {
    //        Name = name;
    //        Questions = questions;
    //    }
    //}
    public class Quiz
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public List<QuizResult> Results { get; set; }
        public Quiz() { }
        public Quiz(string name, List<Question> questions)
        {
            Name = name;
        }
    }

    public class Question
    {
        private string questionText;

        public Question(string questionText, List<Answer> answers)
        {
            this.questionText = questionText;
            Answers = answers;
        }

        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }
    }

    public class Answer
    {
        private string answerText;
        private bool isCorrect;

        public Answer(string answerText, bool isCorrect)
        {
            this.answerText = answerText;
            this.isCorrect = isCorrect;
        }

        public string Text { get; set; }
    }
    public class QuizResult
    {
        public string QuizName { get; set; }
        public string UserName { get; set; }
        public int Score { get; set; }

        public QuizResult(string quizName, string userName, int score)
        {
            QuizName = quizName;
            UserName = userName;
            Score = score;
        }

        public QuizResult()
        {
        }
    }
}
