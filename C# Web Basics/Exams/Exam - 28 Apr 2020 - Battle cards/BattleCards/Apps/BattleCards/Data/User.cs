using SUS.MvcFramework;
using System;
using System.Collections.Generic;

namespace BattleCards.Data
{
    public class User: IdentityUser<string>
    {
        public User()
        {
            this.Cards = new HashSet<UserCard>();
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual ICollection<UserCard> Cards{ get; set; }
    }
}