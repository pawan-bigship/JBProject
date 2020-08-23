using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBProject.Models
{
    [Table("UserType", Schema = "dbo")]
    public partial class UserType
    {
        public UserType()
        {
            UserMaster = new HashSet<UserMaster>();
        }

        [Key]
        [Column("UserTypeID")]
        public short UserTypeId { get; set; }
        [Required]
        [Column("UserType")]
        [StringLength(50)]
        public string UserType1 { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        [InverseProperty("UserType")]
        public virtual ICollection<UserMaster> UserMaster { get; set; }
    }
}
