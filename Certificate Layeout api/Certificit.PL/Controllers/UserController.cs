using AutoMapper;
using Certificit.DAL.Entities;
using Certificit.DAL.Entities.Identity;
using Certificit.DAL.Interfaces;
using Certificit.PL.DTO;
using Certificit.PL.Error;
using Certificit.PL.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Certificit.PL.Controllers
{

    public class UserController : ApiController
    {
        public UserManager<AppUser> _UserManager { get; }
        public IMapper _Mapper { get; }
        public IConfiguration _Configuration { get; }

        public UserController(UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration)
        {
            _UserManager = userManager;
            _Mapper = mapper;
            _Configuration = configuration;
        }

        #region All User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnUserToListDto>>> GetAllUsers(string CompanyName)
        {
            try
            {
                if (CompanyName is null)
                {
                    var Users = await _UserManager.Users.ToListAsync();

                    if (Users == null || !Users.Any())
                    {
                        return NotFound(new ApiResponse(404, "No Users found"));
                    }

                    var mapped = _Mapper.Map<IEnumerable<AppUser>, IEnumerable<ReturnUserToListDto>>(Users);

                    if (mapped == null || !mapped.Any())
                    {
                        return BadRequest(new ApiResponse(400, "Failed to map data"));
                    }

                    return Ok(mapped);
                }
                else
                {
                    var Users = await _UserManager.Users.ToListAsync();

                    List<AppUser> appUsers = new List<AppUser>();
                    foreach (var item in Users)
                    {
                        if (item.DisplayName.ToLower().Contains(CompanyName.ToLower()))
                        {
                            appUsers.Add(item);
                        }
                    }
                    var mapped = _Mapper.Map<IEnumerable<AppUser>, IEnumerable<ReturnUserToListDto>>(appUsers);

                    if (mapped == null || !mapped.Any())
                    {
                        return BadRequest(new ApiResponse(400, "Failed to map data"));
                    }

                    return Ok(mapped);

                }

            }
            catch (Exception ex) // Using a more generic exception
            {
                return StatusCode(500, new ApiResponse(500, "Internal Server Error: " + ex.Message));
            }
        }
        #endregion

        #region Get User
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnUserInfoDto>> GetById(string id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(404, "Model state not valid"));
                }

                var user = await _UserManager.FindByIdAsync(id).ConfigureAwait(false);
                if (user is null)
                {
                    return NotFound(new ApiResponse(404, "No User found with this id"));
                }
                var mapped = _Mapper.Map<AppUser, ReturnUserInfoDto>(user);
                if (mapped is null)
                {
                    return BadRequest(new ApiResponse(400, "Failed Mapped"));
                }

                var userRoles = await _UserManager.GetRolesAsync(user);
                if (userRoles is not null)
                    mapped.Roles.AddRange(userRoles);

                return Ok(mapped);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "Internal Server Error: " + ex.Message));
            }
        }
        #endregion

        #region Delete User
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(404, "Model state not valid"));
                }
                var user = await _UserManager.FindByIdAsync(id);
                if (user is null)
                {
                    return NotFound(new ApiResponse(404, "No User found with this id"));
                }

                var result = await _UserManager.DeleteAsync(user);
                if (result is null)
                {
                    return BadRequest(new ApiResponse(400, "Failed Delete"));
                }
                return Ok(new ApiResponse(200, "Delete Sucsufluy"));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Edit 
        [HttpPut]
        public async Task<ActionResult> Edit(EditeUserDto editeUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(400, "Invalid data. Please check the provided information."));
                }

                // Retrieve the user entity by its ID
                var existingUser = await _UserManager.FindByIdAsync(editeUserDto.id);

                if (existingUser == null)
                {
                    return NotFound(new ApiResponse(404, "User not found."));
                }

                // Update the properties of the existing entity with values from the DTO
                _Mapper.Map(editeUserDto, existingUser);

                // Save changes to the database
                var result = await _UserManager.UpdateAsync(existingUser);
                if (result.Succeeded)
                {
                    return Ok(new ApiResponse(200, "User edited successfully!"));
                }
                else
                {
                    return BadRequest(new ApiResponse(400, "Failed to update user."));
                }
            }
            catch (System.Exception)
            {
                return StatusCode(500, new ApiResponse(500, "Internal Server Error. Please try again later."));
            }
        }

        #endregion

        #region Add Role
        [HttpPost("AddRole")]
        public async Task<ActionResult> AddRole([FromBody] UserRoleDto userRoleDto)
        {
            try
            {
                if (string.IsNullOrEmpty(userRoleDto.id))
                    return BadRequest("User ID is required.");

                var user = await _UserManager.FindByIdAsync(userRoleDto.id);
                if (user == null)
                    return NotFound("User not found.");

                if (userRoleDto.roles == null || !userRoleDto.roles.Any())
                    return BadRequest("Roles cannot be empty.");

                await _UserManager.AddToRolesAsync(user, userRoleDto.roles);

                return Ok(new ApiResponse(200, "Roles added successfully."));
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { Error = "Internal Server Error", Message = ex.Message });
            }
        }
        #endregion

        #region Edit Password
        [HttpPut("password")]
        public async Task<IActionResult> EditUserPassword(PasswordChangeDto model)
        {
            var user = await _UserManager.FindByIdAsync(model.userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await _UserManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest("Failed to change password");
            }

            return Ok("Password updated successfully");
        }
        #endregion

        #region reset password

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            try
            {
                var user = await _UserManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                // Generate a new password reset token for the user
                var resetToken = await _UserManager.GeneratePasswordResetTokenAsync(user);

                var result = await _UserManager.ResetPasswordAsync(user, resetToken, model.NewPassword);

                if (result.Succeeded)
                {
                    return Ok(new ApiResponse(200 , "Passworrd Resat Sucsuflly"));
                }
                else
                {
                    // Handle specific errors based on the IdentityResult errors
                    foreach (var error in result.Errors)
                    {
                        // Handle different error cases here
                        // For instance:
                        if (error.Code == "PasswordRequiresDigit")
                        {
                            return BadRequest("Password must contain a digit.");
                        }
                        // Add more conditions to handle other errors...
                    }

                    // If the specific error is not handled, return a generic error message
                    return BadRequest("Failed to reset password");
                }
            }
            catch (System.Exception)
            {
                // Log the exception for debugging but avoid exposing details in production
                return StatusCode(500, new ApiResponse(500, "Internal Server Error"));
            }

        }
        #endregion
    }
}
