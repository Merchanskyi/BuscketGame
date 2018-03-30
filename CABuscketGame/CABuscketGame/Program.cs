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

            Console.WriteLine("Игра BuscketGame");

            while (true)
            {
                minValue = Tools.EnterNum("Введите Минимальное(minValue) число: ");

                if (minValue < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Нельзя задать число меньше нуля для [Минимального(minValue)]. Попробуйте заново.");
                    continue;
                }

                maxValue = Tools.EnterNum("Введите Максимальное(maxValue) число: ");

                if (maxValue <= minValue)
                {
                    Console.Clear();
                    Console.WriteLine("Нельзя задать число меньше минимального для [Максимального(maxValue)]. Попробуйте заново.");
                    continue;
                }

                quessNumber = Tools.EnterNum("Введите число которое будет Верным(quessNumber): ");

                if (quessNumber > maxValue || quessNumber < minValue)
                {
                    Console.Clear();
                    Console.WriteLine("Нельзя задать верное число вне диапазона для [Верного(maxValue)]. Попробуйте заново.");
                    continue;
                }
                break;
            }

            //For full pass
            int pass = 0;

            //For player 1
            int step1 = 0;

            //For player 2
            int step2 = 0;

            //For player 3
            int step3 = 0;
            int[] masForPlayer3 = new int[maxValue];

            while (true)
            {
                //for (int i = 0; i < name.Count(); i++)
                //{
                //    if (name[i].ID == 1)
                //    {
                //        Console.WriteLine($"Ходит {name[i].Name}");
                //        step1 = minValue++;
                //        if (step1 == quessNumber)
                //        {
                //            Console.WriteLine($"Победил игрок {name[i].Name}");
                //            Console.ReadLine();
                //            return;
                //        }
                //    }
                //}

                //for (int i = 0; i < name.Count(); i++)
                //{
                //    if (name[i].ID == 2)
                //    {
                //        Console.WriteLine($"Ходит {name[i].Name}");
                //        step2 = rand.Next(minValue, maxValue);
                //        if (step2 == quessNumber)
                //        {
                //            Console.WriteLine($"Победил игрок {name[i].Name}");
                //            Console.ReadLine();
                //            return;
                //        }
                //    }
                //}

                for (int i = 0; i < name.Count(); i++)
                {
                    if (name[i].ID == 3)
                    {
                        Console.WriteLine($"Ходит {name[i].Name}");

                        
                        Console.WriteLine($"Его число {step3}");

                        for (int j = 0; minValue < maxValue; j++)
                        {
                            step3 = rand.Next(minValue, maxValue);
                            if (masForPlayer3.Contains(step3))
                                j--;
                            else
                                masForPlayer3[j] = step3;

                            break;
                        }

                        Console.WriteLine($"Его число {step3}");

                        if (step3 == quessNumber)
                        {
                            Console.WriteLine($"Победил игрок {name[i].Name}");
                            Console.ReadLine();
                            return;
                        }
                    }
                }

                //for (int i = 0; i < name.Count(); i++)
                //{
                //    if (name[i].ID == 4)
                //    {
                //        Console.WriteLine($"Ходит {name[i].Name}");
                //    }
                //}

                //for (int i = 0; i < name.Count(); i++)
                //{
                //    if (name[i].ID == 5)
                //    {
                //        Console.WriteLine($"Ходит {name[i].Name}");
                //    }
                //}

                Console.WriteLine($"Все персонажи походили. Нажмите Enter для продолжения шага. Шагов: {pass++ + 1}");
                Console.ReadLine();
            }
        }
    }
}
