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
    public class RoleService : IRoleService
    {

        private readonly IUnitOfWork Database;

        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork database, IMapper mapper)
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

            try
            {
                var role = Database.Roles.GetItem(id.Value);

                if (role == null)
                {
                    throw new ValidationException($"There's no role with id = {id.Value}!", String.Empty);
                }

                Database.Roles.DeleteItem(role);

                Database.Commit();
            } catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }

        public IEnumerable<RoleDTO> GetAll()
        {
            var roles = Database.Roles.GetAll();

            var roleDtos = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleDTO>>(roles);

            return roleDtos;
        }

        public RoleDTO GetItem(long? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("The id value is not set!", String.Empty);
            }

            var role = Database.Roles.GetItem(id.Value);

            if (role == null)
            {
                throw new ValidationException($"There's no role with id = {id.Value}!", String.Empty);
            }

            var roleDto = _mapper.Map<Role, RoleDTO>(role);

            return roleDto;
        }

        public void SaveItem(RoleDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("The role is empty!", String.Empty);
            }

            try
            {
                var role = _mapper.Map<RoleDTO, Role>(item);

                Database.Roles.SaveItem(role);
                Database.Commit();
            } catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }

        public void UpdateItem(RoleDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("The role is empty!", String.Empty);
            }

            try
            {
                var role = _mapper.Map<RoleDTO, Role>(item);

                Database.Roles.UpdateItem(role);
                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }
    }
}
