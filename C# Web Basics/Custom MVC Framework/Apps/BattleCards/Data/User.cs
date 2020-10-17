using SUS.MvcFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleCards.Data
{
    public class User: IdentityUser<string>
    {
        //Since the Id is string, we can initialize it in the constructor
        public User()
        {
            this.Cards = new HashSet<UserCard>();
            this.Role = IdentityRole.User;
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual ICollection<UserCard> Cards{ get; set; }
    }
}
