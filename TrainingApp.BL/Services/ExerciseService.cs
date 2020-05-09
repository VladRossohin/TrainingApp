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
    public class ExerciseService : IExerciseService
    {

        private readonly IUnitOfWork Database;

        private readonly IMapper _mapper;

        public ExerciseService(IUnitOfWork database, IMapper mapper)
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
                var exercise = Database.Exercises.GetItem(id.Value);

                if (exercise == null)
                {
                    throw new ValidationException($"There's no excercise with id = {id.Value}!", String.Empty);
                }

                Database.Exercises.DeleteItem(id.Value);

                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }

        public IEnumerable<ExerciseDTO> GetAll()
        {
            var exercises = Database.Exercises.GetAll();

            var exerciseDtos = _mapper.Map<IEnumerable<Exercise>, IEnumerable<ExerciseDTO>>(exercises);

            return exerciseDtos;
        }

        public ExerciseDTO GetItem(long? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("The id value is not set!", String.Empty);
            }

            var exercise = Database.Exercises.GetItem(id.Value);

            if (exercise == null)
            {
                throw new ValidationException($"There's no excercise with id = {id.Value}!", String.Empty);
            }

            var exerciseDto = _mapper.Map<Exercise, ExerciseDTO>(exercise);

            return exerciseDto;
        }

        public void SaveItem(ExerciseDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("The excercise is empty!", String.Empty);
            }

            try
            {
                var excercise = _mapper.Map<ExerciseDTO, Exercise>(item);

                Database.Exercises.SaveItem(excercise);
                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }

        public void UpdateItem(ExerciseDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("The excercise is empty!", String.Empty);
            }

            try
            {
                var exercise = _mapper.Map<ExerciseDTO, Exercise>(item);

                Database.Exercises.UpdateItem(exercise);
                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }
    }
}
