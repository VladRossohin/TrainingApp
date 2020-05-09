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
    public class TrainingService : ITrainingService
    {
        private readonly IUnitOfWork Database;

        private readonly IMapper _mapper;

        public TrainingService(IUnitOfWork database, IMapper mapper)
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
                var training = Database.Trainings.GetItem(id.Value);

                if (training == null)
                {
                    throw new ValidationException($"There's no training with id = {id.Value}!", String.Empty);
                }

                Database.Trainings.DeleteItem(id.Value);

                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }

        public IEnumerable<TrainingDTO> GetAll()
        {
            var trainings = Database.Trainings.GetAll();

            var trainingDtos = _mapper.Map<IEnumerable<Training>, IEnumerable<TrainingDTO>>(trainings);

            return trainingDtos;
        }

        public TrainingDTO GetItem(long? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("The id value is not set!", String.Empty);
            }

            var training = Database.Trainings.GetItem(id.Value);

            if (training == null)
            {
                throw new ValidationException($"There's no training with id = {id.Value}!", String.Empty);
            }

            var trainingDTO = _mapper.Map<Training, TrainingDTO>(training);

            return trainingDTO;
        }

        public void SaveItem(TrainingDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("The training is empty!", String.Empty);
            }

            try
            {
                var training = _mapper.Map<TrainingDTO, Training>(item);

                Database.Trainings.SaveItem(training);
                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }

        public void UpdateItem(TrainingDTO item)
        {

            if (item == null)
            {
                throw new ValidationException("The training is empty!", String.Empty);
            }

            try
            {
                var training = _mapper.Map<TrainingDTO, Training>(item);

                Database.Trainings.UpdateItem(training);
                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }
    }
}
