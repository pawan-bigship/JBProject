using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JBProject.Dtos;
using JBProject.Models;
using JBProject.Services.UserProfile;
using AutoMapper;
using JBProject.Dtos.UserProfile;
using Microsoft.AspNetCore.Authorization;

namespace JBProject.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly lUserProfileService _userRepo;
       // private readonly IMapper _mapper;
        public UserProfileController(lUserProfileService userRepo)
        {
            _userRepo = userRepo;
            // _mapper = mapper;, IMapper mapper
        }
        // GET: api/UserProfile/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserInfo(long id)
        {
              ServiceResponse<UserInfoDTO> response = await _userRepo.GetUserInfo(
                    id
                 );
            return Ok(response);
            }

        // POST: api/UserProfile
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [HttpPost("Register")]
        public async Task<ActionResult> PostUserInfo(UserInfoDTO userInfo)
            {
            ServiceResponse<int> response = await _userRepo.Register_UserInfo(
                   new UserInfo
                   {
                       UserId = userInfo.UserId,
                       UserCat = userInfo.UserCat,
                       SaleMedium = userInfo.SaleMedium,
                       MonthlyShipments = userInfo.MonthlyShipments,
                       ProductCategory = userInfo.ProductCategory,
                       OtherCategory = userInfo.OtherCategory,
                       CreatedDateTime = DateTime.Now,
                       UpdatedDateTime = DateTime.Now,
                        IsComplete = true
        }
               );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
