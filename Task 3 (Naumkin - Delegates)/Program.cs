using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3__Naumkin___Delegates_
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Доброго времени суток!{0}Данное программа читает слова из файла,{1}выводит сумму чисел, и количество слов, не поддающихся конвертации{2}~~~~~~~~~~~~~~~~~~~~~~~~~~~~~",Environment.NewLine, Environment.NewLine,Environment.NewLine);
            #region Константы
            //Массив разделителей
            string[] dividers = {";"};
            //Имя входящего файла
            string inputFileName = "input.txt";
            //Имя файла вывода
            string outputFileName = "outpup.txt";

            #endregion

            #region Инициализация и подпись на события
            FileReader reader = new FileReader();

            //Подпись на событие окончания считывания из файла
            reader.endReading += HandlerRead.Message;
            //Подпись на событие окончания записи в файл
            reader.endWriting += HandlerWrite.Message;

            #endregion

            //Чтение из файла
            string[] read = reader.ReadFileToArray(inputFileName, dividers);

            //Результат обработки данных
            string result = Summarizer.DataProcessing(read);

            //Запись результатов в файл
            reader.WriteToFile(outputFileName, result);

            //Отписываемся от событий
            reader.endReading -= HandlerRead.Message;
            reader.endWriting -= HandlerWrite.Message;

            //Завершение программы
            Console.WriteLine("{0}Для выхода нажмите клавишу Enter...", Environment.NewLine);
            Console.ReadLine();         
        }
    }
}
