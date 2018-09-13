using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePro.Models.ManyToMany
{
    public class ArticleTag
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
