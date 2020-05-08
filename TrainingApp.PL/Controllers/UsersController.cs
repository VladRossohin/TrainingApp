using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using TrainingApp.Api.Models;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrainingApp.Api.Controllers
{
    [EnableCors]
    [Route("api")]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("users")]
        public IHttpActionResult GetAllUsers()
        {
            var userDtos = _userService.GetAll();

            var users = Mapper.Map<IEnumerable<UserDTO>, IEnumerable<UserModel>>(userDtos);

            return Json(users);
        }

        [HttpGet]
        [Route("users/{id?}")]
        public IHttpActionResult GetUserById([FromUri]long? id)
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

            var user = Mapper.Map<UserDTO, UserModel>(userDto);

            return Json(user);
        }


        [HttpPost]
        [Route("users/create")]
        public IHttpActionResult CreateUser([FromBody]UserModel user)
        {
            if (user == null)
            {
                return BadRequest("The user model is empty!");
            }

            try
            {
                var userDto = Mapper.Map<UserModel, UserDTO>(user);
                _userService.SaveItem(userDto);

                return Ok("The user was succesfully created!");
            } catch
            {
                return InternalServerError(new Exception("An error was occured!"));
            }

        }

        [HttpPut]
        [Route("users/{id?}")]
        public IHttpActionResult UpdateUser([FromUri]long? id, [FromBody]UserModel user)
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

                Mapper.Map(user, userDto);

                userDto.Id = id.Value;

                _userService.SaveItem(userDto);

                return Ok("The user has been succesfully updated!");

            } catch
            {
                return InternalServerError(new Exception("An error was occured!"));
            }
        }

        [HttpDelete]
        [Route("users/{id?}")]
        public IHttpActionResult DeleteUser([FromUri]long? id) 
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
                return InternalServerError(new Exception("An error was occured!"));
            }
        }
    }
}
