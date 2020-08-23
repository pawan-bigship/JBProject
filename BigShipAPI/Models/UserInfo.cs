using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBProject.Models
{
    [Table("User_Info", Schema = "dbo")]
    public partial class UserInfo
    {
        [Key]
        [Column("InfoID")]
        public long InfoId { get; set; }
        [Column("UserID")]
        public long UserId { get; set; }
        [Required]
        [Column("User_Cat")]
        [StringLength(50)]
        public string UserCat { get; set; }
        [Column("sale_medium")]
        [StringLength(5000)]
        public string SaleMedium { get; set; }
        [Required]
        [Column("Monthly_Shipments")]
        [StringLength(500)]
        public string MonthlyShipments { get; set; }
        [Required]
        [StringLength(3000)]
        public string ProductCategory { get; set; }
        [Required]
        [StringLength(300)]
        public string OtherCategory { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDateTime { get; set; }
        public bool? IsComplete { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(UserMaster.UserInfo))]
        public virtual UserMaster User { get; set; }
    }
}
