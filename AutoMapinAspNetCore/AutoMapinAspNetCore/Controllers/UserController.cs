using AutoMapinAspNetCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapinAspNetCore.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var user = GetUserDetails();
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return View(userViewModel);
        }
        private static User GetUserDetails()
        {
            return new User
            {
                Id = 1,
                FirstName = "Jonh",
                LastName = "Smith",
                Email = "JonhSmith@gmail.com",
                Address = new Address { Country = "USA"}
            };
        }
    }
}
    