using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePro.Models.ManyToMany
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string ArticleName { get; set; }

        public ICollection<TagViewModel> Tags { get; set; }
    }
}
