namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private Dictionary<string, List<string>> doctors;
        private Dictionary<string, List<List<string>>> departments;

        public Engine()
        {
            doctors = new Dictionary<string, List<string>>();
            departments = new Dictionary<string, List<List<string>>>();
        }
        public void Run()
        {

            string command = Console.ReadLine();
            while (command != "Output")
            {
                var tokens = command
                    .Split()
                    .ToArray();

                var departament = tokens[0];
                var firstName = tokens[1];
                var lastName = tokens[2];
                var patient = tokens[3];
                var doctorFullName = firstName + lastName;

                AddDoctor(doctorFullName);
                AddDepartment(departament);

                bool isEmptySpot = departments[departament]
                    .SelectMany(x => x)
                    .Count() < 60;

                if (isEmptySpot)
                {
                    AddPatientToRoom(departament, patient, doctorFullName);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                Print(command);

                command = Console.ReadLine();
            }
        }

        private void Print(string command)
        {
            string[] args = command.Split();

            if (args.Length == 1)
            {
                var departmentName = args[0];
                var allPatientsInDepartment = departments[departmentName]
                    .Where(x => x.Count > 0)
                    .SelectMany(x => x)
                    .ToArray();

                Console.WriteLine(string.Join(Environment.NewLine, allPatientsInDepartment));
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int room))
            {
                var allPatientsInRoom = departments[args[0]][room - 1]
                    .OrderBy(x => x)
                    .ToArray();

                Console.WriteLine(string.Join(Environment.NewLine, allPatientsInRoom));
            }
            else
            {
                var allPatientsOfDoctor = doctors[args[0] + args[1]]
                    .OrderBy(x => x)
                    .ToArray();
                Console.WriteLine(string.Join(Environment.NewLine, allPatientsOfDoctor));
            }
        }

        private void AddPatientToRoom(string departament, string patient, string fullName)
        {
            int room = 0;
            doctors[fullName].Add(patient);
            for (int currentRoom = 0; currentRoom < departments[departament].Count; currentRoom++)
            {
                if (departments[departament][currentRoom].Count < 3)
                {
                    room = currentRoom;
                    break;
                }
            }

            departments[departament][room].Add(patient);
        }

        private void AddDepartment(string departament)
        {
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private void AddDoctor(string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
        }
    }
}
