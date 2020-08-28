using System;
using System.Collections.Generic;

namespace ProjektInzynierski.Models
{
    public partial class Relation
    {
        public Relation()
        {
            EventRelation = new HashSet<EventRelation>();
            GiftRelationEvent = new HashSet<GiftRelationEvent>();
        }

        public int IdRelation { get; set; }
        public int IdUser { get; set; }
        public int IdUser2 { get; set; }

        public virtual User IdUser2Navigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<EventRelation> EventRelation { get; set; }
        public virtual ICollection<GiftRelationEvent> GiftRelationEvent { get; set; }
    }
}
