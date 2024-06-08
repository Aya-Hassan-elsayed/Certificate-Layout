using AutoMapper;
using Certificit.PL.DTO;
using Certificit.PL.Error;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Certificit.PL.Controllers
{
    public class RoleController : ApiController
    {
        public RoleManager<IdentityRole> _RoleManager { get; }
        public IMapper _Mapper { get; }

        public RoleController(RoleManager<IdentityRole> roleManager , IMapper mapper)
        {
            _RoleManager = roleManager;
            _Mapper = mapper;
        }
        #region Get All Roles
        [HttpGet]
        public async Task<ActionResult<ReturnRoleDto>> GetAll()
            {
            try
            {
                var rolesData = await _RoleManager.Roles.ToListAsync();

                if (rolesData == null || !rolesData.Any())
                {
                    return NotFound(new ApiResponse(404, "No roles found to show"));
                }

                var mapped = _Mapper.Map<IEnumerable<IdentityRole> , IEnumerable<ReturnRoleDto>>(rolesData);
                if (mapped == null)
                {
                    return BadRequest(new ApiResponse(400, "Mapped Failed"));
                }
                return Ok(mapped);
            }
            catch (System.Exception ex)
            {
                // Log the exception
                return StatusCode(500, new ApiResponse(500, "Internal Server Error: " + ex.Message));
            }
        }

        #endregion

        #region Create Role
        [HttpPost]
        public async Task<ActionResult> Craete(RoleDto identityRole)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(400, "Model state not valid"));
                }

                var mapped = _Mapper.Map<RoleDto , IdentityRole>(identityRole);
                if (mapped == null)
                {
                    return BadRequest(new ApiResponse(400, "Mapped Failed"));
                }

                var result = await _RoleManager.CreateAsync(mapped);
                if (!result.Succeeded)
                {
                    return BadRequest(new ApiResponse(400));
                }

                return Ok(new ApiResponse(200, "Role Added successfully"));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "Internal Server Error: " + ex.Message));
            }
        }
        #endregion

        #region Update Role
        [HttpPut]
        public async Task<ActionResult> Edit(IdentityRole identityRole)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(400, "Model state not valid"));
                }
                var role = await _RoleManager.FindByIdAsync(identityRole.Id);
                if (role == null)
                {
                    return NotFound(new ApiResponse(404, "Not Founded This Role For Update"));
                }
                role.Name = identityRole.Name;

                var result = await _RoleManager.UpdateAsync(role);
                if (!result.Succeeded)
                {
                    return BadRequest(new ApiResponse(400, "Failed to update role"));
                }
                return Ok(new ApiResponse(200, "Role updated successfully"));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "Internal Server Error: " + ex.Message));
            }
        }
        #endregion

        #region DeleteRole
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(string Id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(400, "Model state not valid"));
                }
                var role = await _RoleManager.FindByIdAsync(Id);
                if (role == null)
                {
                    return NotFound(new ApiResponse(404, "Not Founded This Role For Update"));
                }

                var result = await _RoleManager.DeleteAsync(role);
                if (!result.Succeeded)
                {
                    return BadRequest(new ApiResponse(400, "Failed to delete role"));
                }
                return Ok(new ApiResponse(200, "Role deleted successfully"));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "Internal Server Error: " + ex.Message));
            }
        }
        #endregion

    }
}
