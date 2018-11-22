using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePro.Models.OneToMany
{
    public class ItemInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ItemTagInput> ItemTags { get; set; }
    }

    public class ItemTagInput
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
