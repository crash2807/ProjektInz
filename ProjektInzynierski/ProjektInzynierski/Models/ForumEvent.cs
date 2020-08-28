using System;
using System.Collections.Generic;

namespace ProjektInzynierski.Models
{
    public partial class ForumEvent
    {
        public int IdEventRelation { get; set; }
        public int IdEvent { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public virtual Event IdEventNavigation { get; set; }
        public virtual EventRelation IdEventRelationNavigation { get; set; }
    }
}
