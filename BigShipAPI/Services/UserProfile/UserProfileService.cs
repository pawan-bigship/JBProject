using JBProject.Dtos.UserProfile;
using JBProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBProject.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JBProject.Services.UserProfile
{
    public class UserProfileService : IUserProfileService
    {
        public readonly BigShipContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserProfileService(BigShipContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<UserInfoDTO>> GetUserInfo(long userid)
        {
            ServiceResponse<UserInfoDTO> response = new ServiceResponse<UserInfoDTO>();
            try
            {
                UserInfo userInfo = await _context.UserInfo.FirstOrDefaultAsync
                  (x => x.UserId == userid);
                UserInfoDTO ud = new UserInfoDTO();
                ud.UserId = userInfo.UserId;
                ud.UserCat = userInfo.UserCat;
                ud.SaleMedium = userInfo.SaleMedium;
                ud.MonthlyShipments = userInfo.MonthlyShipments;
                ud.ProductCategory = userInfo.ProductCategory;
                ud.OtherCategory = userInfo.OtherCategory;
                //ud.createdDateTime = userInfo.CreatedDateTime;
                //       ud.UpdatedDateTime = userInfo.UpdatedDateTime;
                //         ud.IsComplete = userInfo.IsComplete;
                response.Data = ud;
                response.Message = "";
                response.Success = true;
                response.ResponseCode = 301;
            }
            catch (Exception ex)
            {
                response.ResponseCode = 301;
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;


        }

        public async Task<ServiceResponse<int>> Register_UserInfo(UserInfo uinfo)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            try
            {
                await _context.UserInfo.AddAsync(uinfo);
                await _context.SaveChangesAsync();

                response.ResponseCode = 200;
                response.Message = "User Information Added Successfully";
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.ResponseCode = 301;
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
