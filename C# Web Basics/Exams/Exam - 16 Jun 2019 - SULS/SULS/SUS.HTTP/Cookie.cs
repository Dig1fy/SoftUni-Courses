namespace SUS.HTTP
{
    public class Cookie
    {
        public Cookie(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public Cookie(string cookieAsString)
        {
            //We split the cookieParts to 2. This is due to the fact that we could have weird cookie with more than 1 '=' in it's value
            var cookieParts = cookieAsString.Split(new char[] { '=' }, 2);
            this.Name = cookieParts[0];
            this.Value = cookieParts[1];
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Name}={this.Value}";
        }
    }
}
