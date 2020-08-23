using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBProject.Models
{
    [Table("RoleMaster", Schema = "dbo")]
    public partial class RoleMaster
    {
        public RoleMaster()
        {
            UserInRoles = new HashSet<UserInRoles>();
        }

        [Key]
        [Column("RoleID")]
        public short RoleId { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<UserInRoles> UserInRoles { get; set; }
    }
}
