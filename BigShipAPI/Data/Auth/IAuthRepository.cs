using JBProject.Dtos.UserMaster;
using JBProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBProject.Data.Auth
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(UserMaster userMaster,string password);
        Task<ServiceResponse<LoginResponse>> Login(string username, string password);
        Task<ServiceResponse<LoginResponse>> MobileUpdate(UserMobile mobileupdate);
        Task<bool> UserExists(string emailid,long MobileNo);
    }
}
