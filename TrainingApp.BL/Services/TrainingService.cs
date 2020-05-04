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

        public TrainingService(IUnitOfWork database)
        {
            Database = database;
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

                Database.Trainings.DeleteItem(training);

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

            var trainingDtos = Mapper.Map<IEnumerable<Training>, IEnumerable<TrainingDTO>>(trainings);

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

            var trainingDTO = Mapper.Map<Training, TrainingDTO>(training);

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
                var training = Mapper.Map<TrainingDTO, Training>(item);

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
                var training = Mapper.Map<TrainingDTO, Training>(item);

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
