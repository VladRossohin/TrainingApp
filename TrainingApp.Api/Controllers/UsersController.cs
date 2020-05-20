using System.Collections.Generic;
using System.Web.Http.Results;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Api.Models;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrainingApp.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var userDtos = _userService.GetAll();

            var users = _mapper.Map<IEnumerable<UserDTO>, IEnumerable<UserModel>>(userDtos);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult GetUserById(long? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("The id value is not set!");
            }

            var userDto = _userService.GetItem(id.Value);

            if (userDto == null)
            {
                return NotFound();
            }

            var user = _mapper.Map<UserDTO, UserModel>(userDto);

            return Ok(user);
        }


        [HttpPost("create")]
        public ActionResult CreateUser([FromBody]UserModel user)
        {
            if (user == null)
            {
                return BadRequest("The user model is empty!");
            }

            try
            {
                var userDto = _mapper.Map<UserModel, UserDTO>(user);
                _userService.SaveItem(userDto);

                return Ok("The user was succesfully created!");
            } catch
            {
                return StatusCode(500, "An error has occured!");
            }

        }

        [HttpPut("{id?}")]
        public ActionResult UpdateUser(long? id, [FromBody]UserModel user)
        {
            if (!id.HasValue)
            {
                return BadRequest("The user id was not set!");
            }

            if (user == null)
            {
                return BadRequest("The user model is empty!");
            }

            try
            {
                var userDto = _userService.GetItem(id.Value);
                if (userDto == null)
                {
                    return NotFound();
                }

                _mapper.Map(user, userDto);

                userDto.Id = id.Value;

                _userService.SaveItem(userDto);

                return Ok("The user has been succesfully updated!");

            } catch
            {
                return StatusCode(500, "An error was occured!");
            }
        }

        [HttpDelete("{id?}")]
        public ActionResult DeleteUser(long? id) 
        {
            if (!id.HasValue)
            {
                return BadRequest("The user id was not set!");
            }

            try
            {
                var userDto = _userService.GetItem(id.Value);

                if (userDto == null)
                {
                    return NotFound();
                }

                _userService.DeleteItem(id.Value);

                return Ok($"The user {userDto.Name} {userDto.LastName} has been succesfully deleted!");
            } catch
            {
                return StatusCode(500, "An error was occured!");
            }
        }
    }
}
