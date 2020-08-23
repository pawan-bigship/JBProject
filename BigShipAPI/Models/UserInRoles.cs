using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBProject.Models
{
    [Table("UserInRoles", Schema = "dbo")]
    public partial class UserInRoles
    {
        [Key]
        [Column("UserRoleID")]
        public int UserRoleId { get; set; }
        [Column("UserID")]
        public long UserId { get; set; }
        [Column("RoleID")]
        public short RoleId { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(RoleMaster.UserInRoles))]
        public virtual RoleMaster Role { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(UserMaster.UserInRoles))]
        public virtual UserMaster User { get; set; }
    }
}
