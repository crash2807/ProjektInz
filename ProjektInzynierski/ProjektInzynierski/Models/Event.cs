using System;
using System.Collections.Generic;

namespace ProjektInzynierski.Models
{
    public partial class Event
    {
        public Event()
        {
            EventRelation = new HashSet<EventRelation>();
            ForumEvent = new HashSet<ForumEvent>();
            GiftRelationEvent = new HashSet<GiftRelationEvent>();
        }

        public int IdEvent { get; set; }
        public string EventName { get; set; }
        public int IdUser { get; set; }
        public DateTime EventDate { get; set; }
        public string EventPlace { get; set; }
        public string Description { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<EventRelation> EventRelation { get; set; }
        public virtual ICollection<ForumEvent> ForumEvent { get; set; }
        public virtual ICollection<GiftRelationEvent> GiftRelationEvent { get; set; }
    }
}
