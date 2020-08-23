using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBProject.Data.Auth;
using JBProject.Dtos.UserMaster;
using JBProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JBProject.Controllers
{
    //[EnableCors("ApiCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserMasterRegisterDto request)
        {
            ServiceResponse<int> response = await _authRepo.Register(
                new UserMaster {
                    EmailId = request.EmailId,
                    FirstName=request.FirstName,
                    LastName = request.LastName, 
                    UserTypeId = request.UserTypeId,
                    PlanId = request.PlanId,
                    Otp = request.Otp,
                    Status = request.Status,
                    AddedOn = request.AddedOn,
                    UpdatedOn=request.AddedOn
                }, request.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto objlogin)
                {
                         ServiceResponse<LoginResponse> response = await _authRepo.Login(
                             objlogin.username, objlogin.password
                          );
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
                
        }

        //[Authorize]
        [HttpPut("UpdateMobileNo")]
        public async Task<IActionResult> UpdateMobile(UserMobile Mobile_Res)
        {
            ServiceResponse<LoginResponse> response = await _authRepo.MobileUpdate(
               Mobile_Res
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
