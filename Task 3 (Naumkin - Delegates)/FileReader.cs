using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_3__Naumkin___Delegates_
{
    /// <summary>
    /// Класс для работы с файлом
    /// </summary>
    class FileReader
    {
        public delegate void MessageShower();

        
        /// <summary>
        /// Событие завершения чтения из файла
        /// </summary>
        public event MessageShower endReading;
        /// <summary>
        /// Событие завершения записи в файл
        /// </summary>
        public event MessageShower endWriting;
        
        /// <summary>
        /// Считывает строку и разбивает её на подстроки, возвращая массив
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="divider">Массив разделителей</param>
        /// <returns>Массив подстрок</returns>
        public string[] ReadFileToArray(string fileName, string[] divider)
        {
            string[] str;

            using (StreamReader file = new StreamReader(new FileStream(fileName, FileMode.Open)))
            {
                str = file.ReadToEnd().Split(divider, StringSplitOptions.RemoveEmptyEntries);
            }
            //Запускаем событие
            endReading();
            return str;
        }

        /// <summary>
        /// Метод записи результата в файл
        /// </summary>
        /// <param name="fileName">Имя файла вывода</param>
        /// <param name="result">Строка с результатом</param>
        public void WriteToFile (string fileName,string result)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                file.Write(result);
            }
            //Запускаем событие
            endWriting();
        }
    }
}
