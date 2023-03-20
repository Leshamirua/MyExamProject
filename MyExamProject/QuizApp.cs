using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExamProject
{
    class QuizApp
    {
        private XmlDataManager xmlDataManager = new XmlDataManager();


        public void Login()
        {
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            User user = xmlDataManager.GetUser(login);

            if (user == null)
            {
                Console.WriteLine("Пользователь с таким логином не зарегистрирован.");
                Console.ReadKey();
                Program.UserMenu();
                return;
            }

            if (user.Password != password)
            {  
                Console.WriteLine("Неверный пароль.");
                Console.ReadKey();
                Program.UserMenu();
                return;
            }
            Console.WriteLine("Вход выполнен успешно!");
            Console.ReadKey();
            Program.MainMenu();
        }
        public void Register()
        {
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            if (xmlDataManager.GetUser(login) != null)
            {
                Console.WriteLine("Пользователь с таким логином уже существует.");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            Console.Write("Введите дату рождения (dd.MM.yyyy): ");
            string birthDateStr = Console.ReadLine();
            DateTime birthDate;
            if (!DateTime.TryParseExact(birthDateStr, "dd.MM.yyyy", null, DateTimeStyles.None, out birthDate))
            {
                Console.WriteLine("Неверный формат даты. Введите дату в формате dd.MM.yyyy");
                Console.ReadKey();
                return;
            }

            User user = new User(login, password, birthDate);
            xmlDataManager.AddUser(user);

            Console.WriteLine("Регистрация прошла успешно!");
            Console.ReadKey();
        }
    }
}
