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
        //        /// <summary>
        //        /// Метод для создания/заполнения файла
        //        /// </summary>
        //        /// <param name="id">первое число</param>
        //        /// <returns></returns>
        //        static uint Writer(uint id)
        //        {
        //            using (StreamWriter sw = new StreamWriter("Cотрудники.txt", true, Encoding.Unicode))
        //            {
        //                string line = String.Empty;

        //                line += $"{id}#";

        //                string dateTime = DateTime.Now.ToString();
        //                line += $"{dateTime}#";

        //                Console.Write("Введите ФИО: ");
        //                line += $"{Console.ReadLine()}#";

        //                Console.Write("Введите возраст: ");
        //                line += $"{Console.ReadLine()}#";

        //                Console.Write("Введите рост: ");
        //                line += $"{Console.ReadLine()}#";

        //                Console.Write("Введите дату рождения в формате ДД.ММ.ГГГГ: ");
        //                line += $"{Console.ReadLine()}#";

        //                Console.Write("Введите место рождения(город): ");
        //                line += $"город {Console.ReadLine()}";

        //                sw.WriteLine(line);

        //                return id;
        //            }
        //        }
        //        /// <summary>
        //        /// Метод для считывания из файла
        //        /// </summary>
        //        static void Reader()
        //        {
        //            using (StreamReader sr = new StreamReader("Cотрудники.txt", Encoding.Unicode))
        //            {
        //                string line = sr.ReadToEnd();
        //                string[] data = line.Split('#', '\r', '\n');
        //                if (line != null)
        //                {
        //                    foreach (var word in line)
        //                    {
        //                        Console.Write(word);
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Файл не создан/пустой. Нажмите 2 для создания файла и внесения в нее первой записи");
        //                }
        //            }
        //        }

        static void Main(string[] args)
        {
            string key;
            string path = @"Сотрудники.txt";
            
            Repository rep = new Repository(path);

            rep.Help();
            rep.Reader(); //можно создать 2 массива (1 с уже имеющимися, второй с добавленными). Вызывать их по мене необходимости (по сути для экономии памяти и возможности выйти без сохранения)
            
            while (true)
            {
                key = Console.ReadLine();
                
                switch (key)
                {
                    case "1": // Отображение списка
                        rep.GetAllWorkers();
                        break;
                    case "2": // Отобразить сотрудника
                        rep.GetWorkerById(int.Parse(Console.ReadLine()));
                        break;
                    case "3": // Добавить сотрудника
                        rep.AddWorker();
                        break;
                    case "4": // Удалить сотрудника
                        rep.DeleteWorker(int.Parse(Console.ReadLine()));
                        break;
                    case "5": // Сотрудники в диапазоне дат
                        rep.GetWorkersBetweenTwoDates();
                        break;
                    case "F":   // Помощь                                     
                    case "f":
                        rep.Help();
                        break;
                    case "0": // Выход
                        System.Environment.Exit(0);
                        rep.Writer();
                        break;
                }
            }
        }
    }
}

