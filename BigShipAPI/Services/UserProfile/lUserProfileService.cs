using JBProject.Dtos.UserProfile;
using JBProject.Models;
using Microsoft.AspNetCore.Authorization;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBProject.Services.UserProfile
{
    public  interface IUserProfileService
    {
        Task<ServiceResponse<int>> Register_UserInfo(UserInfo unifo);
        Task<ServiceResponse<UserInfoDTO>> GetUserInfo(long userid);
        //Task<ServiceResponse<LoginResponse>> Login(string username, string password);
        //Task<ServiceResponse<LoginResponse>> MobileUpdate(UserMobile mobileupdate);
        //Task<bool> UserExists(string emailid, long MobileNo);
    }
}
