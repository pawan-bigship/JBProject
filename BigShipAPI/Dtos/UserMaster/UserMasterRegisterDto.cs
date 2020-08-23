using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBProject.Dtos.UserMaster
{
    public class UserMasterRegisterDto
    { 
       

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public long? MobileNo { get; set; }
        public string CompanyName { get; set; }
        public short UserTypeId { get; set; }
        public short PlanId { get; set; }
        public string Otp { get; set; }
        public bool Status { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
