using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Serialize.Model;

namespace Serialize.Controller
{
    public abstract class BaseControllerBinary 
    {                            
        public void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);// сериализация пользователя
            };
        }
        public T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            };
        }
        public void Show(string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                List<Person> desPeople = (List<Person>)formatter.Deserialize(fs);
                foreach (var its in desPeople) { Console.WriteLine("Имя: {0} --- Возраст: {1}", its.Name, its.Age); }
            };
        }
    }
}
