using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePro.Models.ManyToMany
{
    public class Article
    {
        public int Id { get; set; }
        public string ArticleName { get; set; }
        public ICollection<ArticleTag> ArticleTags { get; set; }
    }
}
