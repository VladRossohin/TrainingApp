using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Infrastructure;
using TrainingApp.BLL.Interfaces;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.BLL.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork Database;

        private readonly IMapper _mapper;

        public UserService(IUnitOfWork database, IMapper mapper)
        {
            Database = database;
            _mapper = mapper;
        }

        public void DeleteItem(long? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("The id value is not set!", String.Empty);
            }

            var user = Database.Users.GetItem(id.Value);

            if (user == null)
            {
                throw new ValidationException($"User with id = {id.Value} was not found!", String.Empty);
            }

            Database.Users.DeleteItem(user);

            Database.Commit();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var users = Database.Users.GetAll();

            var userDtos = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);

            return userDtos;
        }

        public UserDTO GetItem(long? id)
        {
            var user = Database.Users.GetItem(id.Value);

            if (user == null)
            {
                throw new ValidationException($"There's no user with id = {id.Value}", String.Empty);
            }

            var userDto = _mapper.Map<User, UserDTO>(user);

            return userDto;

        }

        public void SaveItem(UserDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("The user is empty!", String.Empty);
            }

            try
            {
                var user = _mapper.Map<UserDTO, User>(item);

                Database.Users.SaveItem(user);

                Database.Commit();
            } catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }

        public void UpdateItem(UserDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("The user is empty!", String.Empty);
            }

            try
            {
                var user = _mapper.Map<UserDTO, User>(item);

                Database.Users.UpdateItem(user);

                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }
    }
}
