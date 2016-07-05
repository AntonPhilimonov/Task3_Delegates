using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3__Naumkin___Delegates_
{
    static class Summarizer
    {
        //Объявляем делегат для суммирования
        delegate void DoSummarize(string s, ref decimal sum, ref int count);

        /// <summary>
        /// Обработка данных
        /// </summary>
        /// <param name="read">Массив слов, прочитанных из файла</param>
        /// <returns>Строка с результатом</returns>
        public static string DataProcessing(string[] read)
        {
            //Сумма чисел в файле
            decimal sum = 0;
            //Количество символов в файле
            int count = 0;

            //Создаем экземпляр делегата
            DoSummarize Do;

            //Обработка слов, прочитанных из файла
            foreach (string s in read)
            {
                decimal number;
                if (Decimal.TryParse(s, out number))
                //Если слово имеет возможность конвертироваться в вещественное число, передаем делегату метод суммиирования
                {
                    Do = Summarizer.Numbers;
                }
                else
                //иначе передаем делегату метод подсчета символов
                {
                    Do = Summarizer.Counts;
                }
                //Вызываем делегатт
                Do(s, ref sum, ref count);
            }
            //Возвращаем строку с результатом
            return string.Format("Арифметическая Сумма = {0:0.##}{1}Число символов = {2}", sum, Environment.NewLine, count);
        }

        /// <summary>
        /// Метод суммирования чисел
        /// </summary>
        /// <param name="s">Обрабатываемое слово</param>
        /// <param name="sum">Сумма чисел в файле</param>
        /// <param name="count">Количество символов в файле</param>
        public static void Numbers(string s, ref decimal sum, ref int count)
        {
            sum = sum + Convert.ToDecimal(s);
        }

        /// <summary>
        /// Метод подсчет символов
        /// </summary>
        /// <param name="s">Обрабатываемое слово</param>
        /// <param name="sum">Сумма чисел в файле</param>
        /// <param name="count">Количество символов в файле</param>
        public static void Counts(string s, ref decimal sum, ref int count)
        {
            count = count + s.Length;
        }

    }
}
