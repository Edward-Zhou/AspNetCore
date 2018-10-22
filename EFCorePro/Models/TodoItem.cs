using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePro.Models
{
    public class TodoItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string TodoItemDetailId { get; set; }
        public virtual TodoItemDetail TodoItemDetail { get; set; }
    }
    public class TodoItemDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
