using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Repositories
{
    public class KickRepository : IRepository<Kick>
    {

        private readonly TrainingDBContext Database;

        public KickRepository(TrainingDBContext database)
        {
            Database = database;
        }

        public void DeleteItem(Kick item)
        {
            Database.Kick.Remove(item);
            Database.SaveChangesAsync();
        }

        public Kick GetItem(int? id)
        {
            var kick = Database.Kick.Include("Excercise").Include("Sensor").Where(k => k.Id == id.Value).FirstOrDefault();

            return kick;
        }

        public void SaveItem(Kick item)
        {
            Database.Kick.Add(item);
            Database.SaveChangesAsync();
        }

        public void UpdateItem(Kick item)
        {
            Database.Entry(item).State = EntityState.Modified;
            Database.Kick.Update(item);
            Database.SaveChangesAsync();
        }
    }
}
