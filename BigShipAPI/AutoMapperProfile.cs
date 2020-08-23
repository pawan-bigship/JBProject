using AutoMapper;
using JBProject.Dtos.UserMaster;
using JBProject.Dtos.UserProfile;
using JBProject.Models;
namespace JBProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserMaster, LoginResponse>();
            CreateMap<UserInfoDTO, UserInfo>();
        }
    }
}
