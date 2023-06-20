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
        #region Конструктор
        /// <summary>
        /// Конструктор создания работника
        /// </summary>
        /// <param name="FIO">ФИО работника</param>
        /// <param name="Age">Возраст работника</param>
        /// <param name="Height">Рост работника</param>
        /// <param name="Burthday">Дата рождения работника</param>
        /// <param name="PlaceOfBirth">Место рождения работника</param>
        public Worker(string FIO, byte Age, uint Height, DateTime Burthday, string PlaceOfBirth)
        {
                                                                                                                                 //id и datatime не указываются в конструкторе
            this.FIO = FIO;
            this.Age = Age;
            this.Height = Height;
            this.Burthday = Burthday;
            this.PlaceOfBirth = PlaceOfBirth;
        }
        #endregion

        #region Свойства (автосвойства)
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
        #endregion

        #region Методы
        public string Print()
        {
            return "0";
        }
        #endregion
    }
}
