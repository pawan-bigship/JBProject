using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBProject.Models
{
    [Table("UserMaster", Schema = "dbo")]
    public partial class UserMaster
    {
        public UserMaster()
        {
            UserBankDetails = new HashSet<UserBankDetails>();
            UserCompanyDetails = new HashSet<UserCompanyDetails>();
            UserInRoles = new HashSet<UserInRoles>();
            UserInfo = new HashSet<UserInfo>();
        }

        [Key]
        [Column("UserID")]
        public long UserId { get; set; }
        [Required]
        [Column("EmailID")]
        [StringLength(256)]
        public string EmailId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public long? MobileNo { get; set; }
        [Column("UserTypeID")]
        public short UserTypeId { get; set; }
        [Column("PlanID")]
        public short PlanId { get; set; }
        [Column("OTP")]
        [StringLength(15)]
        public string Otp { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Required]
        [StringLength(256)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(256)]
        public string LastName { get; set; }

        [ForeignKey(nameof(PlanId))]
        [InverseProperty(nameof(PlanType.UserMaster))]
        public virtual PlanType Plan { get; set; }
        [ForeignKey(nameof(UserTypeId))]
        [InverseProperty("UserMaster")]
        public virtual UserType UserType { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserBankDetails> UserBankDetails { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserCompanyDetails> UserCompanyDetails { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserInRoles> UserInRoles { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}
