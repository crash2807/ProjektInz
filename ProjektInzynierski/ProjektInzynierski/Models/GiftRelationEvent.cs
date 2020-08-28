using System;
using System.Collections.Generic;

namespace ProjektInzynierski.Models
{
    public partial class GiftRelationEvent
    {
        public int IdGift { get; set; }
        public int IdRelation { get; set; }
        public int IdEvent { get; set; }

        public virtual Event IdEventNavigation { get; set; }
        public virtual Gift IdGiftNavigation { get; set; }
        public virtual Relation IdRelationNavigation { get; set; }
    }
}
