using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageManager
{
    class Program
    {
        static void Main()
        {
            //91 out of 100 in Judge

            var command = string.Empty;
            var capacity = int.Parse(Console.ReadLine());

            var receivers = new Dictionary<string, int>();
            var senders = new Dictionary<string, int>();

            while ((command = Console.ReadLine()) != "Statistics")
            {
                var input = command.Split("=");

                var action = input[0];

                if (action == "Add")
                {
                    var username = input[1];
                    var sent = int.Parse(input[2]);
                    var received = int.Parse(input[3]);

                    if (!receivers.ContainsKey(username) || !senders.ContainsKey(username))
                    {
                        receivers.Add(username, received);
                        senders.Add(username, sent);
                    }
                }

                else if (action == "Message")
                {
                    var sender = input[1];
                    var receiver = input[2];

                    if (receivers.ContainsKey(receiver) && senders.ContainsKey(sender))
                    {
                        receivers[receiver]++;
                        senders[sender]++;

                        if (senders[sender] + receivers[sender] >= capacity)
                        {
                            senders.Remove(sender);
                            receivers.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }
                        else if (receivers[receiver] + senders[receiver] >= capacity)
                        {
                            receivers.Remove(receiver);
                            senders.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }
                    }
                }

                else if (action == "Empty")
                {
                    var username = input[1];

                    if (username == "All")
                    {
                        receivers.Clear();
                        senders.Clear();
                    }

                    else
                    {
                        senders.Remove(username);
                        receivers.Remove(username);
                    }

                }
            }

            var finalResult = new Dictionary<string, List<int>>();
            var usersCount = 0;

            foreach (var sender in senders)
            {
                finalResult.Add(sender.Key, new List<int>());
                finalResult[sender.Key].Add(sender.Value);
            }
            foreach (var receiver in receivers)
            {
                usersCount++;
                finalResult[receiver.Key].Add(receiver.Value);
            }

            receivers = receivers.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            
            Console.WriteLine($"Users count: {usersCount}");

            foreach (var item in finalResult)
            {
                var totalPerItem = item.Value.Sum();

                if (totalPerItem >= capacity)
                {
                    receivers.Remove(item.Key);
                    senders.Remove(item.Key);
                    Console.WriteLine($"{item.Key} reached the capacity!");
                }
            }

            foreach (var kvpp in receivers)
            {
                var currentTotal = finalResult[kvpp.Key].Sum();
                Console.WriteLine($"{kvpp.Key} - {currentTotal}");
            }
        }
    }
}