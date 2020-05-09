using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;


namespace TrainingApp.DAL.Repositories
{
    public class TrainingRepository : IRepository<Training>
    {

        private readonly TrainingDBContext Database;

        public TrainingRepository(TrainingDBContext database)
        {
            Database = database;
        }

        public void DeleteItem(long id)
        {
            var training = Database.Trainings.Find(id);

            if (training != null)
            {
                Database.Trainings.Remove(training);
            }
        }

        public IEnumerable<Training> GetAll()
        {
            var trainings = Database.Trainings;

            return trainings;
        }

        public Training GetItem(long id)
        {
            var training = Database.Trainings.Include("User").Include("Exercises").Where(tr => tr.Id == id).FirstOrDefault();

            return training;
        }

        public void SaveItem(Training item)
        {
            Database.Trainings.Add(item);
        }

        public void UpdateItem(Training item)
        {
            Database.Entry(item).State = EntityState.Modified;
        }
    }
}
