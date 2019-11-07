using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StacksAndQueues
{
    class Program
    {
        static void Main()
        {

            var bulletPrice = int.Parse(Console.ReadLine());
            var gunBarrel = int.Parse(Console.ReadLine()); //total number of bullets

            var bulletsSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var locksSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var intelValue = int.Parse(Console.ReadLine());
            var initialBulletsTotal = bulletsSize.Length;

            var queLocks = new Queue<int>(locksSize);
            var stackBullets = new Stack<int>(bulletsSize);
            var queBulletsLeft = new Queue<int>();

            for (int i = 0; i < bulletsSize.Length; i++)
            {
                queBulletsLeft.Enqueue(666);
            }

            var bulletCounter = 0;
            var currentBulletSize = 0;
            var currentLockSize = 0;

            while (queLocks.Count != 0 && stackBullets.Count != 0)
            {
                currentBulletSize = stackBullets.Pop();
                currentLockSize = queLocks.Peek();

                if (currentBulletSize <= currentLockSize)
                {
                    if (queLocks.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        queLocks.Dequeue();
                    }

                    Console.WriteLine("Bang!");
                    queBulletsLeft.Dequeue();
                    bulletCounter++;

                    if (queBulletsLeft.Count == 0)
                    {
                        break;
                    }
                    if (bulletCounter == gunBarrel)
                    {
                        Console.WriteLine("Reloading!");
                        bulletCounter = 0;
                    }
                }
                else
                {
                    Console.WriteLine("Ping!");
                    queBulletsLeft.Dequeue();
                    bulletCounter++;

                    if (queBulletsLeft.Count == 0)
                    {
                        break;
                    }
                    if (bulletCounter == gunBarrel)
                    {
                        Console.WriteLine("Reloading!");
                        bulletCounter = 0;
                    }
                }
            }

            var profit = intelValue - bulletPrice * (initialBulletsTotal - (queBulletsLeft.Count));

            if (queLocks.Count == 0)
            {
                Console.WriteLine($"{queBulletsLeft.Count} bullets left. Earned ${profit}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queLocks.Count}");
            }
        }
    }
}

