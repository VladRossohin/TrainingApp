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
    public class ExcerciseService : IExcerciseService
    {

        private readonly IUnitOfWork Database;

        public ExcerciseService(IUnitOfWork database)
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
                var excercise = Database.Excercises.GetItem(id.Value);

                if (excercise == null)
                {
                    throw new ValidationException($"There's no excercise with id = {id.Value}!", String.Empty);
                }

                Database.Excercises.DeleteItem(excercise);

                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }

        public IEnumerable<ExcerciseDTO> GetAll()
        {
            var excercises = Database.Excercises.GetAll();

            var excerciseDtos = Mapper.Map<IEnumerable<Excercise>, IEnumerable<ExcerciseDTO>>(excercises);

            return excerciseDtos;
        }

        public ExcerciseDTO GetItem(long? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("The id value is not set!", String.Empty);
            }

            var excercise = Database.Excercises.GetItem(id.Value);

            if (excercise == null)
            {
                throw new ValidationException($"There's no excercise with id = {id.Value}!", String.Empty);
            }

            var excerciseDto = Mapper.Map<Excercise, ExcerciseDTO>(excercise);

            return excerciseDto;
        }

        public void SaveItem(ExcerciseDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("The excercise is empty!", String.Empty);
            }

            try
            {
                var excercise = Mapper.Map<ExcerciseDTO, Excercise>(item);

                Database.Excercises.SaveItem(excercise);
                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }

        public void UpdateItem(ExcerciseDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("The excercise is empty!", String.Empty);
            }

            try
            {
                var excercise = Mapper.Map<ExcerciseDTO, Excercise>(item);

                Database.Excercises.UpdateItem(excercise);
                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }
    }
}
