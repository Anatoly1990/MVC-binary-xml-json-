using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
namespace Serialize.Model
{
    [Serializable]
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }       
        public Person() { }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public Person(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }        
    }
}
