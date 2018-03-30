using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CABuscketGame
{
    class Program
    {
        static IPlayer[] name = new IPlayer[]
        {
            new DiligentPlayer { Name = "Усердный игрок", ID = 1 },
            new SimplePlayer { Name = "Простой игрок", ID = 2 },
            new SimpleCleverPlayer { Name = "Простой умный игрок", ID = 3 },
            new DiligentCheater { Name = "Усердный читер", ID = 4 },
            new SimpleCheater { Name = "Простой читер", ID = 5 }
        };

        static void Main(string[] args)
        {
            Random rand = new Random();

            int minValue = 0;
            int maxValue = 0;
            int quessNumber = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=====[Игра BuscketGame]=====");
            Console.ResetColor();

            #region SamCodeVvoda
            while (true)
            {
                minValue = Tools.EnterNum("Введите Минимальное(minValue) число: ");

                if (minValue < 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Нельзя задать число меньше нуля для [Минимального(minValue)]. Попробуйте заново.");
                    Console.ResetColor();
                    continue;
                }

                maxValue = Tools.EnterNum("Введите Максимальное(maxValue) число: ");

                if (maxValue <= minValue)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Нельзя задать число меньше минимального для [Максимального(maxValue)]. Попробуйте заново.");
                    Console.ResetColor();
                    continue;
                }

                quessNumber = Tools.EnterNum("Введите число которое будет Верным(quessNumber): ");

                if (quessNumber > maxValue || quessNumber < minValue)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Нельзя задать верное число вне диапазона для [Верного(maxValue)]. Попробуйте заново.");
                    Console.ResetColor();
                    continue;
                }
                break;
            }
            #endregion

            #region AllPlayerMutyat

            //For full pass
            int pass = 0;

            //For player 1
            int step1 = 0;

            //For player 2
            int step2 = 0;

            //For player 3
            int step3 = 0;
            int[] masForPlayer3 = new int[maxValue];
            int temp3 = 0;

            //For player 4
            int step4 = 0;

            //For player 5
            int step5 = 0;

            while (true)
            {
                for (int i = 0; i < name.Count(); i++)
                {
                    if (name[i].ID == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"---Ходит [{name[i].Name}]---");
                        Console.ResetColor();
                        step1 = minValue++;
                        if (step1 == quessNumber)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Победил игрок [{name[i].Name}] угадавший заданное число: {quessNumber}");
                            Console.ResetColor();
                            Console.ReadLine();
                            return;
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Его число {step1}\n");
                        Console.ResetColor();
                    }

                    if (name[i].ID == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"---Ходит [{name[i].Name}]---");
                        Console.ResetColor();
                        step2 = rand.Next(minValue, maxValue);
                        if (step2 == quessNumber)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Победил игрок [{name[i].Name}] угадавший заданное число: {quessNumber}");
                            Console.ResetColor();
                            Console.ReadLine();
                            return;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Его число {step2}\n");
                        Console.ResetColor();
                    }

                    if (name[i].ID == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"---Ходит [{name[i].Name}]---");
                        Console.ResetColor();

                        for (int j = temp3; minValue < maxValue; j++)
                        {
                            step3 = rand.Next(minValue, maxValue);
                            if (masForPlayer3.Contains(step3))
                                j--;
                            else
                                masForPlayer3[j] = step3;

                            break;
                        }

                        if (step3 == quessNumber)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"Победил игрок [{name[i].Name}] угадавший заданное число: {quessNumber}");
                            Console.ResetColor();
                            Console.ReadLine();
                            return;
                        }
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Его число {step3}\n");
                        Console.ResetColor();
                    }

                    if (name[i].ID == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"---Ходит [{name[i].Name}]---");
                        Console.ResetColor();
                        step4 = minValue++;
                        if (step4 == step1 || step4 == step2 || step4 == step3)
                        {
                            step4++;
                        }

                        if (step4 == quessNumber)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"Победил игрок [{name[i].Name}] угадавший заданное число: {quessNumber}");
                            Console.ResetColor();
                            Console.ReadLine();
                            return;
                        }
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Его число {step4}\n");
                        Console.ResetColor();
                    }

                    if (name[i].ID == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"---Ходит [{name[i].Name}]---");
                        Console.ResetColor();

                        step5 = rand.Next(minValue, maxValue);
                        if (step5 == step1 || step5 == step2 || step5 == step3 || step5 == step4)
                        {
                            step5++;
                        }

                        if (step5 == quessNumber)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"Победил игрок [{name[i].Name}] угадавший заданное число: {quessNumber}");
                            Console.ResetColor();
                            Console.ReadLine();
                            return;
                        }
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Его число {step5}\n");
                        Console.ResetColor();
                    }
                }

                Console.WriteLine($"Все персонажи походили. Нажмите Enter для продолжения шага. Шагов: {pass++ + 1}");
                Console.ReadLine();
            }
            #endregion
        }
    }
}
