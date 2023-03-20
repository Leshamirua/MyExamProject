using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyExamProject
{
    class XmlDataManager
    {
        public string usersFilename = "users.xml";

        public void AddUser(User user)
        {
            XDocument doc = XDocument.Load(usersFilename);

            XElement userElement = new XElement("user",
                new XElement("login", user.Login),
                new XElement("password", user.Password),
                new XElement("birthDate", user.BirthDate.ToString("dd.MM.yyyy")));

            doc.Element("users").Add(userElement);
            doc.Save(usersFilename);
        }

        public User GetUser(string login)
        {
            XDocument xdoc = XDocument.Load(usersFilename);
            XElement userElement = xdoc.Root.Elements("user")
                                        .FirstOrDefault(el => el.Element("login").Value == login);
            if (userElement != null)
            {
                User user = new User();
                user.Login = userElement.Element("login").Value;
                user.Password = userElement.Element("password").Value;
                user.BirthDate = DateTime.Parse(userElement.Element("birthDate").Value);
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
