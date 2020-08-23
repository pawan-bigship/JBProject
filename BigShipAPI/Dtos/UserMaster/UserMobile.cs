using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBProject.Dtos.UserMaster
{
    public class UserMobile
    {
        public long UserId { get; set; }     
        public long MobileNo { get; set; }
        public string Otp { get; set; }
    }
}
