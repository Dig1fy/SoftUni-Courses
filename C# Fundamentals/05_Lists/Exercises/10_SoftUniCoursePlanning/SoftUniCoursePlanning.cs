using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialPlan = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "course start")
            {
                string[] commandArray = command.Split(":").ToArray();
                string action = commandArray[0];
                string lessonTitle = commandArray[1];

                if (action == "Add")
                {
                    if (!initialPlan.Contains(lessonTitle))
                    {
                        initialPlan.Add(lessonTitle);
                    }
                }

                else if (action == "Insert")
                {
                    int index = int.Parse(commandArray[2]);

                    if (!initialPlan.Contains(lessonTitle))
                    {
                        initialPlan.Insert(index, lessonTitle);
                    }
                }

                else if (action == "Remove")
                {
                    string title = commandArray[1];

                    if (initialPlan.Contains(title))
                    {
                        int index = initialPlan.IndexOf(title);

                        if (index + 1 < initialPlan.Count)
                        {
                            if (initialPlan[index + 1] == $"{title}-Exercise")
                            {
                                initialPlan.RemoveRange(index, 2);
                            }
                            else
                            {
                                initialPlan.Remove(title);
                            }
                        }
                        else
                        {
                            initialPlan.Remove(title);
                        }
                    }
                }

                else if (action == "Swap")
                {
                    string swapTitle = commandArray[2];

                    if (initialPlan.Contains(lessonTitle) && initialPlan.Contains(swapTitle))
                    {
                        int indexLesson = initialPlan.IndexOf(lessonTitle);
                        int indexSwap = initialPlan.IndexOf(swapTitle);
                        string temp = initialPlan[indexLesson];

                        initialPlan[indexLesson] = swapTitle;
                        initialPlan[indexSwap] = temp;
                    }

                    string lessonExercise = $"{swapTitle}-Exercise";

                    if (initialPlan.Contains(lessonExercise))
                    {
                        string tempExercise = lessonExercise;
                        int index = initialPlan.IndexOf(swapTitle);

                        initialPlan.Remove(lessonExercise);
                        initialPlan.Insert(index + 1, tempExercise);
                    }
                }

                else if (action == "Exercise")
                {
                    string title = commandArray[1];

                    if (initialPlan.Contains(title))
                    {
                        int index = initialPlan.IndexOf(title);

                        if (index + 1 < initialPlan.Count)
                        {
                            if (initialPlan[index + 1] != $"{title}-Exercise")
                            {
                                initialPlan.Insert(index + 1, $"{title}-Exercise");
                            }
                        }
                        else
                        {
                            initialPlan.Add($"{title}-Exercise");
                        }
                    }
                    else
                    {
                        initialPlan.Add(title);
                        initialPlan.Add($"{title}-Exercise");
                    }
                }
            }

            for (int i = 0; i < initialPlan.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{initialPlan[i]}");
            }
        }
    }
}