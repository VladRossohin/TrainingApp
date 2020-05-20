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
    public class KickService : IKickService
    {

        private readonly IUnitOfWork Database;

        private readonly IMapper _mapper;

        public KickService(IUnitOfWork database, IMapper mapper)
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

            var kick = Database.Kicks.GetItem(id.Value);

            if (kick == null)
            {
                throw new ValidationException($"The kick with id = {id.Value} was not found!", String.Empty);
            }

            Database.Kicks.DeleteItem(id.Value);

            Database.Commit();
        }

        public IEnumerable<KickDTO> GetAll()
        {
            var kicks = Database.Kicks.GetAll();

            var kickDtos = _mapper.Map<IEnumerable<Kick>, IEnumerable<KickDTO>>(kicks);

            return kickDtos;
        }

        public IEnumerable<KickDTO> GetByExerciseId(long? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("The id value is not set!", String.Empty);
            }

            var kicks = Database.Kicks.GetByExerciseId(id.Value);

            var kickDtos = _mapper.Map<IEnumerable<Kick>, IEnumerable<KickDTO>>(kicks);

            return kickDtos;
        }

        public KickDTO GetItem(long? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("The id value is not set!", String.Empty);
            }

            var kick = Database.Kicks.GetItem(id.Value);

            if (kick == null)
            {
                throw new ValidationException($"There's no kick with id = {id.Value}!", String.Empty);
            }

            var kickDTO = _mapper.Map<Kick, KickDTO>(kick);

            return kickDTO;
        }

        public void SaveItem(KickDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("The kick is empty!", String.Empty);
            }

            try
            {
                var kick = _mapper.Map<KickDTO, Kick>(item);

                Database.Kicks.SaveItem(kick);
                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }

        public void UpdateItem(KickDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("The kick is empty!", String.Empty);
            }

            try
            {
                var kick = _mapper.Map<KickDTO, Kick>(item);

                Database.Kicks.UpdateItem(kick);
                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }
    }
}
