using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Serialize.Model;
using System.IO;

namespace Serialize.Controller
{
    public abstract class BaseControllerJson
    {
        public void Save(string fileName, object item)
        {
            var formatter = new DataContractJsonSerializer(typeof(List<Person>));          
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.WriteObject(fs, item);
            }
        }

        public T Load<T>(string fileName)
        {
            var formatter = new DataContractJsonSerializer(typeof(List<Person>));
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.ReadObject(fs) is T items)
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
            var formatter = new DataContractJsonSerializer(typeof(List<Person>));
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                List<Person> desPeople = (List<Person>)formatter.ReadObject(fs);
                foreach (var its in desPeople) { Console.WriteLine("Имя: {0} --- Возраст: {1}", its.Name, its.Age); }

            };
        }

    }
}
