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

            var greenLightInput = int.Parse(Console.ReadLine());
            var freeWindowInput = int.Parse(Console.ReadLine());
            var input = string.Empty;
            var stringBuilder = new StringBuilder();
            var myQueue = new Queue<string>();
            var carsCounter = 0;

            while ((input = Console.ReadLine()) != "END")
            {
                var greenLight = greenLightInput;
                var freeWindow = freeWindowInput;

                if (input != "green" && input.Length > 0)
                {
                    myQueue.Enqueue(input);
                }
                else
                {
                    if (myQueue.Count == 0)
                    {
                        break;
                    }

                    stringBuilder.Append(myQueue.Dequeue());
                    var currentCar = stringBuilder.Length;

                    if (greenLight > currentCar)
                    {
                        var currentVehicle = stringBuilder.ToString();

                        while (greenLight > currentCar)
                        {
                            greenLight -= currentCar;

                            if (myQueue.Count > 0)
                            {
                                stringBuilder = new StringBuilder(myQueue.Dequeue());
                                currentCar = stringBuilder.Length;
                                currentVehicle = stringBuilder.ToString();
                                carsCounter++;
                            }
                            else
                            {
                                stringBuilder = new StringBuilder();
                                carsCounter++;
                                break;
                            }
                        }

                        if (stringBuilder.Length > 0 && stringBuilder.Length >= greenLight)
                        {
                            stringBuilder.Remove(0, greenLight);
                        }
                        else
                        {
                            continue;
                        }

                        var carsRemaining = stringBuilder.Length;

                        if (freeWindow - carsRemaining < 0)
                        {
                            stringBuilder.Remove(0, freeWindow);
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentVehicle} was hit at {stringBuilder[0]}.");
                            return;
                        }
                        else if (freeWindow - carsRemaining >= 0)
                        {
                            stringBuilder.Clear();
                            carsCounter++;
                        }
                    }
                    else if (greenLight == currentCar)
                    {
                        stringBuilder.Clear();
                        carsCounter++;
                    }
                    else if (greenLight < currentCar)
                    {
                        var currentVehicle = stringBuilder.ToString();
                        stringBuilder.Remove(0, greenLight);
                        var carsRemaining = stringBuilder.Length;

                        if (freeWindow - carsRemaining < 0) //there will be a crash
                        {
                            stringBuilder.Remove(0, freeWindow);
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentVehicle} was hit at {stringBuilder[0]}.");
                            return;
                        }
                        else if (freeWindow - carsRemaining >= 0)  //the car can exit the crossroad
                        {
                            stringBuilder.Clear();
                            carsCounter++;
                        }
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsCounter} total cars passed the crossroads.");
        }
    }
}

