using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lesson_7
{
    struct Worker
    {
       
        /// <summary>
        /// Конструктор создания работника
        /// </summary>
        /// <param name="FIO">ФИО работника</param>
        /// <param name="Age">Возраст работника</param>
        /// <param name="Height">Рост работника</param>
        /// <param name="Burthday">Дата рождения работника</param>
        /// <param name="PlaceOfBirth">Место рождения работника</param>
        public Worker(uint Id, DateTime ImploymentDate, string FIO, byte Age, uint Height, DateTime Burthday, string PlaceOfBirth)
        {
            this.Id = Id;
            this.ImploymentDate = ImploymentDate;
            this.FIO = FIO;
            this.Age = Age;
            this.Height = Height;
            this.Burthday = Burthday;
            this.PlaceOfBirth = PlaceOfBirth;
        }

        public Worker(string FIO, byte Age, uint Height, DateTime Burthday, string PlaceOfBirth)
        {
            this.Id = default;
            this.ImploymentDate = default;
            this.FIO = FIO;
            this.Age = Age;
            this.Height = Height;
            this.Burthday = Burthday;
            this.PlaceOfBirth = PlaceOfBirth;
        }
        /// <summary>
        /// Id работника
        /// </summary>
        public uint Id { get; set; }
        
        /// <summary>
        /// Дата и время заполнения работника
        /// </summary>
        public DateTime ImploymentDate { get; set; }
       
        /// <summary>
        /// ФИО работника
        /// </summary>
        public string FIO { get; set; }
        /// <summary>
        /// Возраст работника
        /// </summary>
        public byte Age { get; set; }
        /// <summary>
        /// Рост работника
        /// </summary>
        public uint Height { get; set; }
        /// <summary>
        /// Дата рождения работника
        /// </summary>
        public DateTime Burthday { get; set; }
        /// <summary>
        /// Место рождения работника
        /// </summary>
        public string PlaceOfBirth { get; set; }
     
        public string Print()
        {
            return $"{this.Id + 1 ,30} {this.ImploymentDate,30} {this.FIO,30} {this.Age,15} {this.Height,15} {this.Burthday,15} {this.PlaceOfBirth,10}";
        }
    }
}
