using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBProject.Dtos.UserMaster
{
    public class TokenMaster
    {
        public string Token { get; set; }
        public DateTime tokenExpiresIn { get; set; }
    }
}
