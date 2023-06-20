using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7
{
    struct Repository
    {
        private Worker[] worker;
        uint id;
        private string path;
        private string[] titles;

        public Repository(string path) //зачем инициализация
        { 
            this.path = path;
            this.id = 0; //0 или 1
            this.titles = new string[5];
            this.worker = new Worker[2];

        }
        public Worker[] GetAllWorkers()
        {
            return worker;
        }

        public Worker GetWorkerById(int id) //можно объединить гетворкер и делит воркер (гетворкер+срока удалить)
        {
            Console.WriteLine("Введите id для отображения необходимого  сотрудника");
            return worker[id];
        }

        public void AddWorker(Worker worker)
        {
            this.Resize(id >= this.worker.Length);
            worker.FIO = Console.ReadLine();
            worker.Age = byte.Parse(Console.ReadLine());
            worker.Height = uint.Parse(Console.ReadLine()); 
            worker.Burthday = DateTime.Parse(Console.ReadLine());
            worker.PlaceOfBirth = Console.ReadLine();
            this.worker[id] = worker;
            id++; //зачем this

        }

        public void DeleteWorker(int id)
        {
            Console.WriteLine("Введите id для удаления необходимого  сотрудника");
            Array.Clear(worker, id, 1);
        }
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            return new Worker[0];
        }

        public void Writer() 
        {
            using (StreamWriter sw = new StreamWriter(path)) //зачем this
            {
                sw.WriteLine(worker);
            }
        }

        /// <summary>
    /// Загрузка информации о сотрудниках из файла
    /// </summary>
    /// <param name="path">путь к файлу с сотрудниками</param>
        public void Reader()
        {
            using (StreamReader sr = new StreamReader(path)) //зачем this
            {
                titles = sr.ReadLine().Split('#');
                string line = sr.ReadToEnd();
                string[] data = line.Split('#', '\r', '\n');
                if (line != null)
                {
                    foreach (var word in line)
                    {
                        Console.Write(word);
                    }
                }
                else
                {
                    Console.WriteLine("Файл не создан/пустой. Заполните хотя бы одного сотрудника");
                }
            }
        }

        /// <summary>
        /// Информация о взаимодействии с интерфейсом
        /// </summary>
        public void Help()
        {
            Console.WriteLine("\tВведите:\r\n1 - Отображение списка;\r\n2 - Отобразить сотрудника;\r\n3 - Добавить сотрудника;\r\n4 - Удалить сотрудника;" +
                "\r\n5 - Отобразить сотрудникв в определенном диапазоне дат;\r\nF - Помощь;\r\n0 - Выход.");
        }

        public void Resize(bool Flag)
        { 
        if (Flag)
            {
                Array.Resize(ref worker, this.worker.Length * 2);
            }    
        }
    }
}
