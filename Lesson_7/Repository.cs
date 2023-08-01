using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7
{
    struct Repository
    {
        private Worker[] workers;
        uint id;
        private string path;
        private string[] titles;

        public Repository(string path) 
        { 
            this.path = path;
            this.id = 0; 
            this.titles = new string[5];
            this.workers = new Worker[1];

        }
        public Worker[] GetAllWorkers()
        {
            
            return workers;
        }

        public Worker? GetWorkerById(int concretId) 
        {
            if (concretId >= workers.Length || concretId < 1 )
            {
                return null;
            }
            return workers[concretId - 1];
        }

        public void AddWorker(Worker worker)
        {
            Resize(id >= this.workers.Length);
            if (worker.Id == default)
            {
                worker.Id = id;
                worker.ImploymentDate = DateTime.Now;
            }
            this.workers[id] = worker;
            id++; 
        }

        public void DeleteWorker(int id)
        {
            Console.WriteLine("Введите id для удаления необходимого  сотрудника");
            Array.Clear(workers, id, 1);
        }
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            return workers.Where(x => x.ImploymentDate >= dateFrom && x.ImploymentDate <= dateTo).ToArray();
        }

        /// <summary>
        /// Сохранение информации о сотрудниках в файл
        /// </summary>
        public void WriteToFile() 
        {
            using (StreamWriter sw = new StreamWriter(path)) //зачем this
            {
                for (int i = 0; i < this.workers.Length; i++)
                    sw.WriteLine(workers[i]);
            }
        }

        /// <summary>
    /// Загрузка информации о сотрудниках из файла
    /// </summary>
    /// <param name="path">путь к файлу с сотрудниками</param>
        public void ReadFromFile()
        {
            using (StreamReader sr = new StreamReader(path)) 
            {
                while (!sr.EndOfStream)
                {
                    //titles = sr.ReadLine().Split('#');
                    string line = sr.ReadLine();
                    var splatLine = line.Split('#', '\r', '\n');
                    AddWorker(new Worker(Convert.ToUInt32(splatLine[0]), Convert.ToDateTime(splatLine[1]), splatLine[2], Convert.ToByte(splatLine[3]), Convert.ToUInt32(splatLine[4]), Convert.ToDateTime(splatLine[5]), splatLine[6]));
                }
            }
        }

       
       /// <summary>
       /// Увеличение массива сотрудников
       /// </summary>
       /// <param name="Flag">Если условие выполняется, то делаем</param>
        public void Resize(bool Flag)
        { 
        if (Flag)
            {
                Array.Resize(ref workers, this.workers.Length * 2);
            }    
        }
    }
}
