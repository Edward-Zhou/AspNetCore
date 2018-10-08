using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePro.Models.LazyLoad
{
    public class JunctionClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ClassA ClassA { get; set; }
        public virtual ClassB ClassB { get; set; }

    }
    public class ClassA
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ClassB
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
