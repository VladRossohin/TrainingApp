using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Repositories
{
    public class SensorRepository : IRepository<Sensor>
    {

        private readonly TrainingDBContext Database;

        public SensorRepository(TrainingDBContext database)
        {
            Database = database;
        }

        public void DeleteItem(Sensor item)
        {
            Database.Sensor.Remove(item);
            Database.SaveChangesAsync();
        }

        public Sensor GetItem(int? id)
        {
            var sensor = Database.Sensor.Include("Excercise").Include("Kick").Where(s => s.Id == id.Value).FirstOrDefault();

            return sensor;
        }

        public void SaveItem(Sensor item)
        {
            Database.Sensor.Add(item);
            Database.SaveChangesAsync();
        }

        public void UpdateItem(Sensor item)
        {
            Database.Entry(item).State = EntityState.Modified;

            Database.Sensor.Update(item);
            Database.SaveChangesAsync();
        }
    }
}
