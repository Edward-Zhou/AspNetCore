using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePro.Models.MultipleColumnsSameTable
{
    public class UserRoleRelationship
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid UserRoleRelationshipId { get; set; } = new Guid();

        public virtual UserRole ChildUserRole { get; set; }
        public int ChildUserRoleId { get; set; }

        public virtual UserRole ParentUserRole { get; set; }
        public int? ParentUserRoleId { get; set; }
    }
}
