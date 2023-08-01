using Lesson_7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lesson7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key;
            string path = @"Сотрудники.txt";
            
            Repository rep = new Repository(path);

            Help();
            rep.ReadFromFile(); //можно создать 2 массива (1 с уже имеющимися, второй с добавленными). Вызывать их по мене необходимости (по сути для экономии памяти и возможности выйти без сохранения)
            
            while (true)
            {
                key = Console.ReadLine();
                
                switch (key)
                {
                    case "1": // Отображение списка
                        var workers = rep.GetAllWorkers();
                        foreach (var worker1 in workers.Where(x => !string.IsNullOrWhiteSpace(x.FIO)))
                        {
                            Console.WriteLine(worker1.Print());
                        }
                        Console.WriteLine();
                        break;

                    case "2": // Отобразить сотрудника
                        Console.WriteLine("Введите id для отображения необходимого  сотрудника");
                        var worker = rep.GetWorkerById(int.Parse(Console.ReadLine()));
                        Console.WriteLine(worker?.Print());
                        break;
                    case "3": // Добавить сотрудника
                        //rep.AddWorker();
                        break;
                    case "4": // Удалить сотрудника
                        rep.DeleteWorker(int.Parse(Console.ReadLine()));
                        break;
                    case "5": // Сотрудники в диапазоне дат
                       // rep.GetWorkersBetweenTwoDates();
                        break;
                    case "F":   // Помощь                                     
                    case "f":
                        Help();
                        break;
                    case "0": // Выход
                        System.Environment.Exit(0);
                        rep.WriteToFile();
                        break;
                }
            }
            /// <summary>
            /// Информация о взаимодействии с интерфейсом
            /// </summary>
            void Help()
            {
                Console.WriteLine("\tВведите:\r\n1 - Отображение списка;\r\n2 - Отобразить сотрудника;\r\n3 - Добавить сотрудника;\r\n4 - Удалить сотрудника;" +
                    "\r\n5 - Отобразить сотрудникв в определенном диапазоне дат;\r\nF - Помощь;\r\n0 - Выход.");
            }
        }
    }
}

