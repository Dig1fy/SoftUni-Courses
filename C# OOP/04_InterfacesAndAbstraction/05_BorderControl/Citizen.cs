namespace BorderControl
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string id)
        {
            this.Id = id;
        }

        public string Id { get; private set; }
    }
}
