using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBProject.Models
{
    [Table("User_Company_Details", Schema = "dbo")]
    public partial class UserCompanyDetails
    {
        [Key]
        [Column("CompanyID")]
        public long CompanyId { get; set; }
        [Column("UserID")]
        public long UserId { get; set; }
        [Required]
        [Column("Company_Name")]
        [StringLength(160)]
        public string CompanyName { get; set; }
        [Required]
        [Column("Company_EmailID")]
        [StringLength(320)]
        public string CompanyEmailId { get; set; }
        [Column("website")]
        public bool? Website { get; set; }
        [Column("website_url")]
        [StringLength(100)]
        public string WebsiteUrl { get; set; }
        [Column("Company_GSTIN")]
        [StringLength(30)]
        public string CompanyGstin { get; set; }
        [Required]
        [Column("BillingAddress_Line1")]
        [StringLength(100)]
        public string BillingAddressLine1 { get; set; }
        [Column("BillingAddress_Line2")]
        [StringLength(100)]
        public string BillingAddressLine2 { get; set; }
        [Column("BillingAddress_PinCode")]
        public int BillingAddressPinCode { get; set; }
        [Required]
        [Column("BillingAddress_City")]
        [StringLength(100)]
        public string BillingAddressCity { get; set; }
        [Required]
        [Column("BillingAddress_State")]
        [StringLength(100)]
        public string BillingAddressState { get; set; }
        [Column("BillingAddress_PhoneCountryCode")]
        [StringLength(10)]
        public string BillingAddressPhoneCountryCode { get; set; }
        [Required]
        [Column("BillingAddress_Phone")]
        [StringLength(15)]
        public string BillingAddressPhone { get; set; }
        [StringLength(100)]
        public string Signature { get; set; }
        [StringLength(100)]
        public string Logo { get; set; }
        [Column("Signature_Data")]
        public byte[] SignatureData { get; set; }
        [Column("Logo_Data")]
        public byte[] LogoData { get; set; }
        [Column("Invoice_Prefix")]
        [StringLength(100)]
        public string InvoicePrefix { get; set; }
        [Column("Invoice_Suffix")]
        [StringLength(100)]
        public string InvoiceSuffix { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDateTime { get; set; }
        public bool? IsComplete { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(UserMaster.UserCompanyDetails))]
        public virtual UserMaster User { get; set; }
    }
}
