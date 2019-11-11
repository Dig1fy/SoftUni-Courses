namespace BorderControl
{
    public class Robot : IIdentifiable 
    {
        public Robot( string id)
        {
            this.Id = id;
        }
        public string Id { get; private set ; }
    }
}
