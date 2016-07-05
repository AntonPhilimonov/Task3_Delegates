using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3__Naumkin___Delegates_
{
    static class HandlerRead
    {
        /// <summary>
        /// Оработчик события завершения чтения
        /// </summary>
        public static void Message()
        {
            Console.WriteLine("Чтение из файла завершено!");
        }
    }
}
