using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyExamProject
{
    public class QuizManager
    {
        private List<Quiz> quizzes;
        public string fileName = "quizzes.xml";
        public QuizManager()
        {
            quizzes = new List<Quiz>();
        }

        public void LoadQuizzes(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));
                using (StreamReader reader = new StreamReader(filePath))
                {
                    quizzes = (List<Quiz>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while loading quizzes from {filePath}: {ex.Message}");
            }
        }

        public void SaveQuizzes(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, quizzes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving quizzes to {filePath}: {ex.Message}");
            }
        }

        //public Quiz CreateQuiz(string name)
        //{
        //    Quiz quiz = new Quiz(name);
        //    quizzes.Add(quiz);
        //    return quiz;
        //}
        public void CreateQuiz()
        {
            Console.WriteLine("Создание новой викторины");
            
            Console.WriteLine("Введите название викторины:");
            string name = Console.ReadLine();
           
            List<Question> questions = new List<Question>();

            while (true)
            {
                Console.WriteLine("Добавить вопрос? ( Y/N)");
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y")
                {
                    Console.WriteLine("Введите вопрос:");
                    string questionText = Console.ReadLine();

                    List<Answer> answers = new List<Answer>();
                    bool isCorrect = false;

                    while (true)
                    {
                        Console.WriteLine("Введите ответ:");
                        string answerText = Console.ReadLine();

                        Console.WriteLine("Это правильный ответ? (Y/N)");
                        string correctAnswer = Console.ReadLine().ToUpper();

                        isCorrect = (correctAnswer == "Y");

                        answers.Add(new Answer(answerText, isCorrect));

                        Console.WriteLine("Добавить еще ответ? (Y/N)");
                        string addAnswer = Console.ReadLine().ToUpper();

                        if (addAnswer == "N")
                        {
                            break;
                        }
                    }

                    questions.Add(new Question(questionText, answers));
                }
                else if (answer == "N")
                {
                    break;
                }
            }

            Quiz quiz = new Quiz(name, questions);
            quizzes.Add(quiz);

            SaveQuizzes(fileName);

            Console.WriteLine("Викторина успешно создана и сохранена!");
        }
        public Quiz GetQuizByName(string name)
        {
            return quizzes.FirstOrDefault(q => q.Name == name);
        }

        public List<Quiz> GetAllQuizzes()
        {
            return quizzes;
        }

        public void AddQuizResult(Quiz quiz, string playerName, int score)
        {
            QuizResult result = new QuizResult(quiz.Name, playerName, score);
            quiz.Results.Add(result);
        }

        public void ShowQuizResults(Quiz quiz)
        {
            Console.WriteLine($"Результаты викторины \"{quiz.Name}\":");
            Console.WriteLine();
            if (quiz.Results.Count > 0)
            {
                foreach (QuizResult result in quiz.Results)
                {
                    Console.WriteLine($"{result.UserName} - {result.Score}");
                }
            }
            else
            {
                Console.WriteLine("Результатов пока нет.");
            }
            Console.WriteLine();
        }

        public void ShowQuizTop20(Quiz quiz)
        {
            Console.WriteLine($"Топ-20 викторины \"{quiz.Name}\":");
            Console.WriteLine();
            if (quiz.Results.Count > 0)
            {
                var top20 = quiz.Results.OrderByDescending(r => r.Score).Take(20);
                int i = 1;
                foreach (QuizResult result in top20)
                {
                    Console.WriteLine($"{i}. {result.UserName} - {result.Score}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Результатов пока нет.");
            }
            Console.WriteLine();
        }
        //public void StartQuiz()
        //{
        //    
        //    Console.WriteLine("Выберите викторину:");
        //    var quizzes = GetAllQuizzes();
        //    for (int i = 0; i < quizzes.Count; i++)
        //    {
        //        Console.WriteLine($"{i + 1}. {quizzes[i].Name}");
        //    }

        //    
        //    int quizNumber;
        //    do
        //    {
        //        Console.Write("Введите номер викторины: ");
        //    } while (!int.TryParse(Console.ReadLine(), out quizNumber) || quizNumber < 1 || quizNumber > quizzes.Count);
        //    var selectedQuiz = quizzes[quizNumber - 1];

        //    
        //    Console.WriteLine($"Вы выбрали викторину \"{selectedQuiz.Name}\".");
        //    var questions = selectedQuiz.GetQuestions();
        //    var quizResult = new QuizResult(selectedQuiz.Name);

        //    foreach (var question in questions)
        //    {
        //        Console.WriteLine(question.Text);
        //        var answers = question.GetAnswers();
        //        for (int i = 0; i < answers.Count; i++)
        //        {
        //            Console.WriteLine($"{i + 1}. {answers[i].Text}");
        //        }

        //        int userAnswer;
        //        do
        //        {
        //            Console.Write("Введите номер ответа: ");
        //        } while (!int.TryParse(Console.ReadLine(), out userAnswer) || userAnswer < 1 || userAnswer > answers.Count);

        //        var selectedAnswer = answers[userAnswer - 1];
        //        var isCorrect = selectedAnswer.IsCorrect;
        //        Console.WriteLine(isCorrect ? "Вы ответили верно!" : "Вы ответили неверно.");

        //        quizResult.AddResult(question, selectedAnswer, isCorrect);
        //    }

        //    
        //    quizManager.AddQuizResult(quizResult);

        //    Console.WriteLine($"Поздравляем, вы завершили викторину \"{selectedQuiz.Name}\"!");
        //}




    }
}

