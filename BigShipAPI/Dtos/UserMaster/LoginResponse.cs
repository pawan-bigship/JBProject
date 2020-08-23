using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBProject.Dtos.UserMaster
{
    public class LoginResponse
    {
        public long UserId { get; set; }
       public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public long? MobileNo { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpiresIn { get; set; }
        public string CompanyName { get; set; }
        public short UserTypeId { get; set; }
        public short PlanId { get; set; }
        public string Otp { get; set; }
        public bool Status { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime? UpdatedOn { get; set; } = DateTime.MinValue;
        public static implicit operator string(LoginResponse v)
        {
            throw new NotImplementedException();
        }
    }
}
