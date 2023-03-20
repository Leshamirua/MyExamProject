using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static MyExamProject.Program;

namespace MyExamProject
{
    internal class Program
    {
            static public void MainMenu()
            {
            string[] menuItems = { "\t\tНачать викторину", "\t\tРезультаты прошлых викторин", "\t\tТоп-20 викторины", "\t\tНастройки", "\t\tВыход" };
            int selectedItem = 0;
            QuizManager quizManager = new QuizManager();
            while (true)
            { 
                Console.Clear();
                Console.WriteLine("\t\t\tГлавное меню\n");
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedItem)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(menuItems[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(menuItems[i]);
                    }
                }

                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedItem--;
                        if (selectedItem < 0)
                        {
                            selectedItem = menuItems.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        selectedItem++;
                        if (selectedItem == menuItems.Length)
                        {
                            selectedItem = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (selectedItem)
                        {
                            case 0:
                                // StartQuiz
                                break;
                            case 1:
                                //ShowQuizResults
                                break;
                            case 2:
                                //quizManager.ShowQuizTop20();
                                break;
                            case 3:
                                //ShowSettingsMenu
                                break;
                            case 4:
                                
                                UserMenu();
                                break;
                        }
                        break;
                }
            }
        }
        static public void UserMenu()
        {


            QuizApp quizApp = new QuizApp();
            string[] menuItems = { "\t\t1. Войти", "\t\t2. Зарегистрироваться", "\t\t3. Выход"};
            int selectedItem = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\t\tВИКТОРИНА\n\n\t\t   Выберите действие:\n");
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedItem)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(menuItems[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(menuItems[i]);
                    }
                }

                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedItem--;
                        if (selectedItem < 0)
                        {
                            selectedItem = menuItems.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        selectedItem++;
                        if (selectedItem == menuItems.Length)
                        {
                            selectedItem = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (selectedItem)
                        {
                            case 0:
                                quizApp.Login();
                                MainMenu();
                                break;
                            case 1:
                                quizApp.Register();
                                break;
                            case 2:
                                Environment.Exit(0);
                                break;
                        }
                        break;
                }
            }
        }

        static void Main(string[] args)
        {


            
            ////XmlTextWriter writer = new XmlTextWriter("users.xml", System.Text.Encoding.UTF8);
            ////writer.WriteStartDocument(true);
            ////writer.Formatting = Formatting.Indented;
            ////writer.Indentation = 2;

            
            ////writer.WriteStartElement("users");

           
            ////writer.WriteStartElement("user");

            
            ////writer.WriteAttributeString("username", "user1");
            ////writer.WriteAttributeString("password", "password1");
            ////writer.WriteAttributeString("birthdate", "2000-01-01");

            
            ////writer.WriteEndElement();

            
            ////writer.WriteEndElement();


            ////writer.WriteEndDocument();
            ////writer.Close();
            UserMenu();
        }
    }
}
