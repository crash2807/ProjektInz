using System;
using System.Collections.Generic;

namespace ProjektInzynierski.Models
{
    public partial class Hobby
    {
        public Hobby()
        {
            UserHobby = new HashSet<UserHobby>();
        }

        public int IdHobby { get; set; }
        public string HobbyName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserHobby> UserHobby { get; set; }
    }
}
