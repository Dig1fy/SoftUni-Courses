namespace Telephony
{
    public class Engine
    {
        public void Run()
        {
            var inputNumbers = Reader.ReadLine().Split();
            var inputSites = Reader.ReadLine().Split();

            ICall call = new CellPhone();
            Writer.WriteLine(call.Call(inputNumbers));

            IBrowse browse = new CellPhone();
            Writer.WriteLine(browse.Browse(inputSites));
        }
    }
}
