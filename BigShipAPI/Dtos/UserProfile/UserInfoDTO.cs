using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBProject.Dtos.UserProfile
{
    public class UserInfoDTO
    {
      //  public long InfoId { get; set; }
       public long UserId { get; set; }
       public string UserCat { get; set; }
       public string SaleMedium { get; set; }
      public string MonthlyShipments { get; set; }
     public string ProductCategory { get; set; }
    public string OtherCategory { get; set; }
    }
}
