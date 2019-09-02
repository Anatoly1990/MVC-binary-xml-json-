using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Serialize.Controller;

namespace Serialize
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите формат сохранения данных\n"+"A - binary\nB - xml\nC - json\n");
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.A:
                    Console.WriteLine("\nВведите имя работника компании");
                    var name = Console.ReadLine();
                    var personController = new PersonController(name);
                    if (personController.IsNewPerson)
                    {
                        Console.WriteLine("Введите возраст работника компании");
                        var age = Convert.ToInt32(Console.ReadLine());
                        personController.SetNewPersonDate(age);
                    }
                    personController.ShowAllPerson();
                    break;
                case ConsoleKey.B:
                    Console.WriteLine("\nВведите имя работника компании");
                    var name1 = Console.ReadLine();
                    var personController1 = new PersonControllerXml(name1);
                    if (personController1.IsNewPerson)
                    {
                        Console.WriteLine("Введите возраст работника компании");
                        var age = Convert.ToInt32(Console.ReadLine());
                        personController1.SetNewPersonDate(age);
                    }
                    personController1.ShowAllPerson();
                    break;
                case ConsoleKey.C:
                    Console.WriteLine("\nВведите имя работника компании");
                    var name2 = Console.ReadLine();
                    var personController2 = new PersonControllerJson(name2);
                    if (personController2.IsNewPerson)
                    {
                        Console.WriteLine("Введите возраст работника компании");
                        var age = Convert.ToInt32(Console.ReadLine());
                        personController2.SetNewPersonDate(age);
                    }
                    personController2.ShowAllPerson();
                    break;
                default:
                    break;
            }
            
           
               
        }
    }
}
