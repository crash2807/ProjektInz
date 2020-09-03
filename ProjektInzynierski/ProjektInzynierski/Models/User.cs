using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektInzynierski.Models
{
    public partial class User
    {
        public User()
        {
            Event = new HashSet<Event>();
            Gift = new HashSet<Gift>();
            RelationIdUser2Navigation = new HashSet<Relation>();
            RelationIdUserNavigation = new HashSet<Relation>();
            UserHobby = new HashSet<UserHobby>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public byte[] Avatar { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Gift> Gift { get; set; }
        public virtual ICollection<Relation> RelationIdUser2Navigation { get; set; }
        public virtual ICollection<Relation> RelationIdUserNavigation { get; set; }
        public virtual ICollection<UserHobby> UserHobby { get; set; }
    }
}
