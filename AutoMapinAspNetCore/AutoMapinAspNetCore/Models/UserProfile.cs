using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapinAspNetCore.Models
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<User, UserViewModel>();             
        }
    }
}