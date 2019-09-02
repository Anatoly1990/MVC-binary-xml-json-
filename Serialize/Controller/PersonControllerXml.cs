using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serialize.Model;

namespace Serialize.Controller
{
    public class PersonControllerXml:BaseControllerXml
    {
        public List<Person> Person { get; set; }
        public Person CurrentPerson { get; set; }
        public bool IsNewPerson { get; } = false;
        public PersonControllerXml(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Поле не может быть пустым", nameof(name));
            }
            Person = GetUsersData();

            CurrentPerson = Person.SingleOrDefault(u => u.Name == name);
            if (CurrentPerson == null)
            {
                CurrentPerson = new Person(name);
                IsNewPerson = true;
                Person.Add(CurrentPerson);
            }
        }

        public void SetNewPersonDate(int age)
        {
            if (age < 0)
            {
                throw new ArgumentNullException("Неверный формат", nameof(age));
            }
            CurrentPerson.Age = age;
            Save();
        }
        private List<Person> GetUsersData()
        {
            var names = Load<List<Person>>("personsXml.xml") ?? new List<Person>();
            return names;

        }
        public void Save()
        {
            Save("personsXml.xml", Person);
        }
        public void ShowAllPerson()
        {
            Show("personsXml.xml");
        }
    }
}
