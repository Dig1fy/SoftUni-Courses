namespace MortalEngines.Commands
{
    public class Command : ICommand
    {
        private string name;
        private string[] arguments;

        public Command(string name, string[] arguments)
        {
            Name = name;
            Arguments = arguments;
        }

        public string Name 
        {
            get => this.name;

            private set
            {
                this.name = value;
            }

        }

        public string[] Arguments 
        {
            get => this.arguments;

            private set
            {
                this.arguments = value;
            }
        }
    }
}
