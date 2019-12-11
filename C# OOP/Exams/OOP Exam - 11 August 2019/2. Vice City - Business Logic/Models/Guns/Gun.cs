namespace ViceCity.Models.Guns
{
    using System;
    using ViceCity.Models.Guns.Contracts;

    public abstract class Gun : IGun //THE FUCKING JUDGE MIGHT BRAKE IF YOU DON"T USE ABSTRACT FIRE()
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;
        private int shootBullets;
        private int capacity;
        protected Gun(string name, int bulletsPerBarrel, int totalBullets, int ShootBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;

            this.shootBullets = ShootBullets;
            this.capacity = bulletsPerBarrel;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or a white space!");
                }

                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get => this.bulletsPerBarrel;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below zero!");
                }

                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get => this.totalBullets;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total bullets cannot be below zero!");
                }

                this.totalBullets = value;
            }
        }

        public bool CanFire
            => this.BulletsPerBarrel > 0;

        public int Fire()
        {
            this.BulletsPerBarrel -= shootBullets;

            if (this.BulletsPerBarrel <= 0)
            {
                if (TotalBullets < capacity && totalBullets > 0)
                {
                    this.BulletsPerBarrel = TotalBullets;
                }
                else if (TotalBullets >= capacity)
                {
                    TotalBullets -= capacity;
                    this.BulletsPerBarrel = capacity;
                }
            }

            return shootBullets;
        }
    }
}