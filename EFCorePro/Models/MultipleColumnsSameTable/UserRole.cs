using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePro.Models.MultipleColumnsSameTable
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public Guid UserRoleId { get; set; } = new Guid();
        public virtual Role Role { set; get; }
        public int RoleId { set; get; }
        public virtual User User { set; get; }
        public int UserId { set; get; }
    }
}
