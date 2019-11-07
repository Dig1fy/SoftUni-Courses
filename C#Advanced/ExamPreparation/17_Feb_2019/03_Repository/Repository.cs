namespace Repository
{
    using System.Collections.Generic;

    public class Repository
    {
        Dictionary<int, Person> data;

        int ID = -1;

        public int Count { get => data.Count; }
        public Repository()
        {
            data = new Dictionary<int, Person>();
        }

        public void Add(Person person)
        {
            data.Add(++ID, person);
        }
        public Person Get(int wantedID)
        {
            foreach (var id in data)
            {
                if (id.Key == wantedID)
                {
                    return id.Value;
                }
            }

            return null;
        }

        public bool Update(int idToCheck, Person newPerson)
        {
            foreach (var id in data)
            {
                if (id.Key == idToCheck)
                {
                    data[id.Key] = newPerson;
                    return true;
                }
            }

            return false;
        }

        public bool Delete(int idToDelete)
        {
            foreach (var id in data)
            {
                if (id.Key == idToDelete)
                {
                    data.Remove(id.Key);
                    return true;
                }
            }

            return false;
        }
    }
}
