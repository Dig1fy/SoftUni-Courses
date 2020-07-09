namespace P03_SalesDatabase.IOManagement.Contracts
{
    public interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);
    }
}
