using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Repositories
{
    public class TrainingRepository : CommonRepository<Training>, IRepository<Training>
    {
        private readonly TrainingDBContext Database;

        public TrainingRepository(TrainingDBContext database) : base(database)
        {

        }

        public IEnumerable<Training> GetAll()
        {
            return Database.Training;
        }

        public Training GetItem(long? id)
        {
            var training = Database.Training.Include("IdNavigation").Include("Excercise").Where(tr => tr.Id == id.Value).FirstOrDefault();

            return training;
        }

    }
}
