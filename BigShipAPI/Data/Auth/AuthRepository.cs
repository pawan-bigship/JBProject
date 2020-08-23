 using JBProject.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JBProject.Dtos.UserMaster;
using AutoMapper;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authentication.OAuth;
using JBProject.Dtos;

namespace JBProject.Data.Auth
{
   public class AuthRepository : IAuthRepository
    {
        public readonly BigShipContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
 
        public AuthRepository(BigShipContext context,IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }
     
        public async Task<ServiceResponse<int>> Register(UserMaster userMaster, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            //if (await UserExists(userMaster.EmailId, (long)userMaster.MobileNo))
                if (await EmailIdExists(userMaster.EmailId))
                {
                response.Success = false;
                response.Message = "User Already Exists";
                return response;
            }
            CreatePasswordHash(password, out byte[] passwordSalt, out byte[] passwordHash);
            userMaster.PasswordHash = passwordHash;
            userMaster.PasswordSalt = passwordSalt;
           userMaster.UserTypeId = 3828;
            userMaster.PlanId = 6545;
            userMaster.Status = true;
             await _context.UserMaster.AddAsync(userMaster);
            await _context.SaveChangesAsync();
           
            response.Data = (int)userMaster.UserId;
            return response;
        }
        public async Task<bool> EmailIdExists(string emailid)
        {
            if (await _context.UserMaster.AnyAsync(x => x.EmailId.ToLower() == emailid.ToLower() ))

            { return true; }

            else
                return false;

        }
        public async Task<bool> MobileExists(long mobileno)
        {
            if (await _context.UserMaster.AnyAsync(x =>x.MobileNo == mobileno & mobileno>0))

            { return true; }

            else
                return false;

        }
        public async Task<bool> UserExists(string emailid, long mobileno)
        {
            if (await _context.UserMaster.AnyAsync(x => x.EmailId.ToLower() == emailid.ToLower() ||  x.MobileNo == mobileno))
              
            { return true; }

            else
                return false;

        }
 
        public async Task<ServiceResponse<LoginResponse>> Login(string username, string password)
        {
           // throw new System.NotImplementedException();
            ServiceResponse<LoginResponse> response = new ServiceResponse<LoginResponse>();
          UserMaster user=new UserMaster();
 //           UserMaster user = await _context.UserMaster.FirstOrDefaultAsync
 //    (x => x.EmailId.ToLower().Equals
 //    (
 //       username.ToLower())
 //);
            if (username.IndexOf('@') > -1)
            {
                //Validate email format
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                       @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                          @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(username))
                {
                    response.Success = false;
                    //response.Message = "Emailid not valid.";
                    response.Message = "Mobile No Or Email ID not valid.";
                    return response;
                }
                else
                {
                    user = await _context.UserMaster.FirstOrDefaultAsync
               (x => x.EmailId.ToLower().Equals
               (
                  username.ToLower())
           );
                }

            }
            else
            {
                //validate Username format
                string mobileRegex = @"^[6-9]\d{9}$";
                Regex re = new Regex(mobileRegex);
                if (!re.IsMatch(username))
                
                {
                    response.Success = false;
                    //response.Message = "Mobile No  not valid.";
                    response.Message = "Mobile No Or Email ID not valid.";
                    return response;
                }
                else
                {
                    user = await _context.UserMaster.FirstOrDefaultAsync
               (x => x.MobileNo.Equals
               (
                 Convert.ToInt64(username))
           );
                }
            }

            LoginResponse Login_Res = new LoginResponse();
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
                return response;
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password";
                return  response;
            }
            else
            {
                Login_Res.UserId = user.UserId;
                Login_Res.EmailId = user.EmailId;
                Login_Res.Status = user.Status;                
                TokenMaster tm = CreateToken(user);
                Login_Res.Token =tm.Token;
                Login_Res.TokenExpiresIn = tm.tokenExpiresIn;// DateFormat.AddingTSeprator(tm.tokenExpiresIn);
                Login_Res.FirstName = user.FirstName;
                Login_Res.LastName = user.LastName; 
                Login_Res.MobileNo = user.MobileNo;
                Login_Res.UserTypeId = user.UserTypeId;
                Login_Res.PlanId = user.PlanId;
                Login_Res.AddedOn = user.AddedOn;
                Login_Res.UpdatedOn = user.UpdatedOn; 
                //  response.Data = user.UserId.ToString();
                //return jwt token
                response.Data = Login_Res;
            }

            return response;
        }
        public async Task<ServiceResponse<LoginResponse>> MobileUpdate(UserMobile Mobile_Res)
        {
            ServiceResponse<LoginResponse> response = new ServiceResponse<LoginResponse>();
          try
            {
                if (await MobileExists(Mobile_Res.MobileNo))
                {
                    response.Success = false;
                    response.Message = "Mobile No Already Exists";
                    return response;
                }
                 else
                {
                    UserMaster user = await _context.UserMaster.FirstOrDefaultAsync(x=>x.UserId == Mobile_Res.UserId);
                    //&& !x.MobileNo.Equals(MobileExists(Mobile_Res.MobileNo))
                    user.UserId = Mobile_Res.UserId;
                    user.MobileNo = Mobile_Res.MobileNo;
                    //Genterate Random Number 
                    Random rnd = new Random();
                    int rvalue = rnd.Next(100000, 999999);
                    user.Otp = rvalue.ToString();
                    TokenMaster tm = CreateToken(user);
                    LoginResponse Login_Res = new LoginResponse();
                    Login_Res.UserId = user.UserId;
                    Login_Res.EmailId = user.EmailId;
                    Login_Res.Status = user.Status;
                    Login_Res.Token = tm.Token;
                    Login_Res.TokenExpiresIn = tm.tokenExpiresIn;// DateFormat.AddingTSeprator(tm.tokenExpiresIn);
                    Login_Res.FirstName = user.FirstName;
                    Login_Res.LastName = user.LastName; 
                    Login_Res.MobileNo = user.MobileNo;
                    Login_Res.UserTypeId = user.UserTypeId;
                    Login_Res.PlanId = user.PlanId;
                    Login_Res.AddedOn = user.AddedOn;
                    Login_Res.UpdatedOn = user.UpdatedOn;
                    //  response.Data = user.UserId.ToString();
                    //return jwt token
                    response.Data = Login_Res;

                   // response.Data = _mapper.Map<LoginResponse>(user);
                    //_context.UserMaster.Update(user);
                    await _context.SaveChangesAsync();
                    //Send Mail on success


                }
            }
            catch (Exception ex)
            {
                    response.Success = false;
                    response.Message = ex.Message;
                //response.Data = ex.Message;
                }
            return response;
        }
        //Json Token
        private   TokenMaster CreateToken(UserMaster user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.EmailId)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)
            );

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(2),//token time 
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            TokenMaster tmaster = new TokenMaster
            {
                Token = tokenHandler.WriteToken(token),
                //if (!datetime.HasValue) return "";
                //dt = datetime.Value;
                tokenExpiresIn = Convert.ToDateTime(tokenDescriptor.Expires)
            };
            return tmaster;
        }
        //Method to hash the password 
        //By Pawan on 30.07.2020
        public void CreatePasswordHash(string password,out byte[] passwordSalt, out byte[] passwordHash)
        {

            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])
                {
                    return false;
                }
            }
            return true;
        }


    
  

    }
}
