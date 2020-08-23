using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBProject.Dtos.UserProfile
{
    public class UserCompanyDetailsDTO
    {
        public long CompanyId { get; set; }
        public long UserId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmailId { get; set; }
        public string CompanyGstin { get; set; }
        public string BillingAddressLine1 { get; set; }
        public string BillingAddressLine2 { get; set; }
        public int BillingAddressPinCode { get; set; }
        public string BillingAddressCity { get; set; }
        public string BillingAddressState { get; set; }
        public string BillingAddressPhoneCountryCode { get; set; }
        public string BillingAddressPhone { get; set; }
       public string Signature { get; set; }
        public string Logo { get; set; }
        public string InvoicePrefix { get; set; }
        public string InvoiceSuffix { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public bool? IsComplete { get; set; }
    }
}
