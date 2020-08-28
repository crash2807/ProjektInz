using System;
using System.Collections.Generic;

namespace ProjektInzynierski.Models
{
    public partial class Gift
    {
        public Gift()
        {
            GiftRelationEvent = new HashSet<GiftRelationEvent>();
        }

        public int IdGift { get; set; }
        public int IdUser { get; set; }
        public string Gift1 { get; set; }
        public decimal? Price { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<GiftRelationEvent> GiftRelationEvent { get; set; }
    }
}
