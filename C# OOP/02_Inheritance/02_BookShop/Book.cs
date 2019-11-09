namespace BookShop
{
    using System;
    using System.Text;

    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            Author = author;
            Title = title;
            Price = price;
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }
        public string Author
        {
            get { return author; }

            set
            {
                var authorSecondName = value.Split()[1];
                if (char.IsDigit(authorSecondName[0]))
                {
                    throw new ArgumentException("Author not valid!");
                } 

                this.author = value;
            }
        }

        public virtual decimal Price
        {
            get { return price; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: { this.GetType().Name}")
           .AppendLine($"Title: { this.Title}")
           .AppendLine($"Author: { this.Author}")
           .AppendLine($"Price: { this.Price:f2}");
            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }
    }
}
