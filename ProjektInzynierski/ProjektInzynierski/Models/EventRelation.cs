using System;
using System.Collections.Generic;

namespace ProjektInzynierski.Models
{
    public partial class EventRelation
    {
        public EventRelation()
        {
            ForumEvent = new HashSet<ForumEvent>();
        }

        public int IdEvent { get; set; }
        public int IdRelation { get; set; }
        public int IdEventRelation { get; set; }

        public virtual Event IdEventNavigation { get; set; }
        public virtual Relation IdRelationNavigation { get; set; }
        public virtual ICollection<ForumEvent> ForumEvent { get; set; }
    }
}
