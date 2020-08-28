using System;
using System.Collections.Generic;

namespace ProjektInzynierski.Models
{
    public partial class UserHobby
    {
        public int IdUser { get; set; }
        public int IdHobby { get; set; }

        public virtual Hobby IdHobbyNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
