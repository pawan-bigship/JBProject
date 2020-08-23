using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBProject.Models
{
    [Table("PlanType", Schema = "dbo")]
    public partial class PlanType
    {
        public PlanType()
        {
            UserMaster = new HashSet<UserMaster>();
        }

        [Key]
        [Column("PlanID")]
        public short PlanId { get; set; }
        [Required]
        [StringLength(256)]
        public string PlanName { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        [InverseProperty("Plan")]
        public virtual ICollection<UserMaster> UserMaster { get; set; }
    }
}
