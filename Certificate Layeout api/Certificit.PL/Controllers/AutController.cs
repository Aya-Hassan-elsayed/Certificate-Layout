using AutoMapper;
using Certificit.DAL.Entities;
using Certificit.DAL.Entities.Identity;
using Certificit.DAL.Interfaces;
using Certificit.PL.DTO;
using Certificit.PL.Error;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Certificit.PL.Controllers
{
    public class AutController : ApiController
    {
        public UserManager<AppUser> _UserManager { get; }
        public SignInManager<AppUser> _SignInManager { get; }
        public ITokenServices _TokenServices { get; }
        public IGenaricInterface<Log> _Logs { get; }

        public AutController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenServices tokenServices , IGenaricInterface<Log> logs , IMapper ma)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
            _TokenServices = tokenServices;
            _Logs = logs;
        }

        #region Login
        [HttpPost("Login")] //Post : api/Aut/Login
        public async Task<ActionResult<UserDto>> Login (LoginDto loginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(400, "Invalid input data"));
                }

                var User = await _UserManager.FindByEmailAsync(loginDto.Email);
                if (User == null)
                {
                    return Unauthorized(new ApiResponse(401));
                }

                var result = await _SignInManager.CheckPasswordSignInAsync(User, loginDto.Password, false);
                if (!result.Succeeded)
                {
                    return Unauthorized(new ApiResponse(401));
                }
                var token = await _TokenServices.GenerateToken(User, _UserManager);
                if (token is not null)
                {
                    //Log log = new Log()
                    //{
                    //    Email = loginDto.Email,
                    //    Note = "Login",
                    //    Username = loginDto.Email.Split('@')[0],
                    //    Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    //};
                    //int resultlog = await _Logs.AddAsync(log);
                }
                return Ok(new UserDto()
                {
                    Status = 200,
                    Token = token
                }); ; 
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "Internal Server Error: " + ex.Message));
            }

        }
        #endregion

        #region Register
        [HttpPost("Register")] //Post : api/Aut/Register
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(400, "Invalid input data"));
                }

                AppUser User = new AppUser()
                {
                    DisplayName = registerDto.DisplayName,
                    Email = registerDto.Email,
                    PhoneNumber = registerDto.PhoneNumber,
                    UserName = registerDto.Email.Split('@')[0]
                };

                var result = await _UserManager.CreateAsync(User, registerDto.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(new ApiResponse(400));
                }

                return Ok(new ApiResponse(200 , "Succsufly add new user"));


            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "Internal Server Error: " + ex.Message));
            }
        }

        #endregion

    }
}
