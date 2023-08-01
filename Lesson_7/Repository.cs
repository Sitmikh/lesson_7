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
        private Worker[] worker;
        uint id;
        private string path;
        private string[] titles;

        public Repository(string path) 
        { 
            this.path = path;
            this.id = 1; //0 или 1
            this.titles = new string[5];
            this.worker = new Worker[1];

        }
        public Worker[] GetAllWorkers()
        {
            
            return worker;
        }

        public Worker? GetWorkerById(int concretId) 
        {
            if (concretId >= worker.Length || concretId < 0 )
            {
                return null;
            }
            return worker[concretId];
        }

        public void AddWorker(Worker worker)
        {
            Resize(id >= this.worker.Length);
            this.worker[id] = worker;
            id++; 

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
        
        /// <summary>
        /// Сохранение информации о сотрудниках в файл
        /// </summary>
        public void WriteToFile() 
        {
            using (StreamWriter sw = new StreamWriter(path)) //зачем this
            {
                for (int i = 0; i < this.worker.Length; i++)
                    sw.WriteLine(worker[i]);
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
                    AddWorker(new Worker(splatLine[2], Convert.ToByte(splatLine[3]), Convert.ToUInt32(splatLine[4]), Convert.ToDateTime(splatLine[5]), splatLine[6]));
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
                Array.Resize(ref worker, this.worker.Length * 2);
            }    
        }
    }
}
