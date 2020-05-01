using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Repositories
{
    public class ExcerciseRepository : IRepository<Excercise>
    {

        private readonly TrainingDBContext Database;

        public ExcerciseRepository(TrainingDBContext database)
        {
            Database = database;
        }

        public void DeleteItem(Excercise item)
        {
            Database.Excercise.Remove(item);
            Database.SaveChangesAsync();
        }

        public Excercise GetItem(int? id)
        {
            var excercise = Database.Excercise.Include("Sensor").Include("Training").Include("Kick").Where(exer => exer.Id == id.Value).FirstOrDefault();

            return excercise;
        }

        public void SaveItem(Excercise item)
        {
            Database.Excercise.Add(item);

            Database.SaveChangesAsync();
        }

        public void UpdateItem(Excercise item)
        {
            Database.Entry(item).State = EntityState.Modified;
            Database.Update(item);
            Database.SaveChangesAsync();
        }
    }
}
