using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void DeleteItem(Training item)
        {
            Database.Training.Remove(item);
            Database.SaveChangesAsync();
        }

        public Training GetItem(int? id)
        {
            var training = Database.Training.Include("IdNavigation").Include("Excercise").Where(tr => tr.Id == id.Value).FirstOrDefault();

            return training;
        }

        public void SaveItem(Training item)
        {
            Database.Training.Add(item);
            Database.SaveChangesAsync();
        }

        public void UpdateItem(Training item)
        {
            Database.Entry(item).State = EntityState.Modified;

            Database.Update(item);

            Database.SaveChangesAsync();
        }
    }
}
