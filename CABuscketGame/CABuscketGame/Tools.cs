using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CABuscketGame
{
    public static class Tools
    {
        public static int EnterNum(string message)
        {
            Console.Write(message);

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                    return num;
                else
                    Console.Write("Ошибка ввода! Повторите ввод еще раз: ");
            }
        }
    }
}
