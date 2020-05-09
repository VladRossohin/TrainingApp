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

        public void DeleteItem(long id)
        {
            var kick = Database.Kicks.Find(id);

            if (kick != null)
            {
                Database.Kicks.Remove(kick);
            }
        }

        public IEnumerable<Kick> GetAll()
        {
            var kicks = Database.Kicks;

            return kicks;
        }

        public Kick GetItem(long id)
        {
            var kick = Database.Kicks.Include("Exercise").Where(k => k.Id == id).FirstOrDefault();

            return kick;
        }

        public void SaveItem(Kick item)
        {
            Database.Kicks.Add(item);
        }

        public void UpdateItem(Kick item)
        {
            Database.Entry(item).State = EntityState.Modified;
        }
    }
}
