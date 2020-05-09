using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Repositories
{
    public class ExerciseRepository : IRepository<Exercise>
    {

        private readonly TrainingDBContext Database;

        public ExerciseRepository(TrainingDBContext database)
        {
            Database = database;
        }

        public void DeleteItem(long id)
        {
            var exercise = Database.Exercises.Find(id);

            if (exercise != null)
            {
                Database.Exercises.Remove(exercise);
            }
        }

        public IEnumerable<Exercise> GetAll()
        {
            var exercises = Database.Exercises;

            return exercises;
        }

        public Exercise GetItem(long id)
        {
            var exercise = Database.Exercises.Find(id);

            return exercise;
        }

        public void SaveItem(Exercise item)
        {
            Database.Exercises.Add(item);
        }

        public void UpdateItem(Exercise item)
        {
            Database.Entry(item).State = EntityState.Modified;
        }
    }
}
