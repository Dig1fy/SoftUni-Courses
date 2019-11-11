namespace Telephony
{
    using System.Text;

    public class CellPhone : IBrowse, ICall

    {
        public string Browse(string[] sites)
        {
            var stringBuilder = new StringBuilder();

            foreach (var site in sites)
            {
                if (IsThereADigit(site))
                {
                    stringBuilder.AppendLine("Invalid URL!");
                }
                else
                {
                    stringBuilder.AppendLine($"Browsing: {site}!");
                }                
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string Call(string[] numbers)
        {
            var stringBuilder = new StringBuilder();

            foreach (var number in numbers)
            {
                if (IsThereALetter(number))
                {
                    stringBuilder.AppendLine("Invalid number!");
                }
                else
                {
                    stringBuilder.AppendLine($"Calling... {number}");
                }                
            }

            return stringBuilder.ToString().TrimEnd();
        }

        private bool IsThereADigit(string site)
        {
            foreach (var charR in site)
            {
                if (char.IsDigit(charR))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsThereALetter(string number)
        {
            foreach (var charR in number)
            {
                if (char.IsLetter(charR))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
