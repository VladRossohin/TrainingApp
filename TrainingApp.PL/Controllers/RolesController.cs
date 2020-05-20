using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Razor.Generator;
using TrainingApp.Api.Models;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Interfaces;

namespace TrainingApp.Api.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RolesController : ControllerBase
    {

        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllRoles()
        {
            var roleDtos = _roleService.GetAll();

            var roles = _mapper.Map<IEnumerable<RoleDTO>, IEnumerable<RoleModel>>(roleDtos);

            return Ok(roles);
        }

        [HttpGet("{id}")]
        public ActionResult GetRoleById(long? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("The id value is not set!");
            }

            var roleDto = _roleService.GetItem(id.Value);

            if (roleDto == null)
            {
                return NotFound();
            }

            var role = _mapper.Map<RoleDTO, RoleModel>(roleDto);

            return Ok(role);
        }


        [HttpPost("create")]
        public ActionResult CreateRole([FromBody]RoleModel role)
        {
            if (role == null)
            {
                return BadRequest("The role model is empty!");
            }

            try
            {
                var roleDto = _mapper.Map<RoleModel, RoleDTO>(role);
                _roleService.SaveItem(roleDto);

                return Ok($"The role {role.Name} was succesfully created!");
            }
            catch
            {
                return StatusCode(500, "An error has occured!");
            }

        }

        [HttpPut("{id?}")]
        public ActionResult UpdateRole(long? id, [FromBody]RoleModel role)
        {
            if (!id.HasValue)
            {
                return BadRequest("The role id was not set!");
            }

            if (role == null)
            {
                return BadRequest("The role model is empty!");
            }

            try
            {
                var roleDto = _roleService.GetItem(id.Value);
                if (roleDto == null)
                {
                    return NotFound();
                }

                _mapper.Map(role, roleDto);

                roleDto.Id = id.Value;

                _roleService.SaveItem(roleDto);

                return Ok($"The role {role.Name} has been succesfully updated!");

            }
            catch
            {
                return StatusCode(500, "An error was occured!");
            }
        }

        [HttpDelete("{id?}")]
        public ActionResult DeleteRole(long? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("The role id was not set!");
            }

            try
            {
                var roleDto = _roleService.GetItem(id.Value);

                if (roleDto == null)
                {
                    return NotFound();
                }

                _roleService.DeleteItem(id.Value);

                return Ok($"The role {roleDto.Name} has been succesfully deleted!");
            }
            catch
            {
                return StatusCode(500, "An error was occured!");
            }
        }
    }
}
