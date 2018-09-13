using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePro.Models.ManyToMany
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public ICollection<ArticleTag> ArticleTags { get; set; }
    }
}
