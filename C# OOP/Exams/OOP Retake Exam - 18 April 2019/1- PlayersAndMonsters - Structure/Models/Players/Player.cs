namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;        

        protected Player(ICardRepository cardRepository, string userName, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = userName;
            this.Health = health;
        }

        public ICardRepository CardRepository { get; private set; }


        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string. ");
                }

                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                if (this.health < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero. ");
                }

                this.health = value;
            }
        }
        public bool IsDead => this.Health <= 0;   //CHECK IF IT SHOULD BE <= OR ONLY < 

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            if (this.Health - damagePoints < 0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health -= damagePoints;
            }
        }
    }
}
