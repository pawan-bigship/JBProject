using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBProject.Models
{
    [Table("User_Bank_Details", Schema = "dbo")]
    public partial class UserBankDetails
    {
        [Key]
        [Column("AccountID")]
        public long AccountId { get; set; }
        [Column("UserID")]
        public long UserId { get; set; }
        [Required]
        [Column("Beneficiary_AccountNo")]
        [StringLength(25)]
        public string BeneficiaryAccountNo { get; set; }
        [Required]
        [Column("Beneficiary_AccountType")]
        [StringLength(50)]
        public string BeneficiaryAccountType { get; set; }
        [Required]
        [Column("IFSC_Code")]
        [StringLength(11)]
        public string IfscCode { get; set; }
        [Required]
        [Column("Beneficiary_Name")]
        [StringLength(80)]
        public string BeneficiaryName { get; set; }
        [Required]
        [Column("Cancelled_Cheque")]
        [StringLength(100)]
        public string CancelledCheque { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDateTime { get; set; }
        public bool? IsComplete { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(UserMaster.UserBankDetails))]
        public virtual UserMaster User { get; set; }
    }
}
