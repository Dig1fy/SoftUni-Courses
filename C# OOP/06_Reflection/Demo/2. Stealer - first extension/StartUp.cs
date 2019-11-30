namespace Stealer
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var spy = new Spy();
            var fieldsInfo = spy.StealFieldInfo("Hacker", "username", "password");
            Console.WriteLine(fieldsInfo);

            var accessModifiersInfo = spy.AnalyzeAcessModifiers("Hacker");
            Console.WriteLine(accessModifiersInfo);
        }
    }
}
