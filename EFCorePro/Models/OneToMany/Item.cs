using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePro.Models.OneToMany
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ItemTag> ItemTags { get; set; }
    }

    public class ItemTag
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
