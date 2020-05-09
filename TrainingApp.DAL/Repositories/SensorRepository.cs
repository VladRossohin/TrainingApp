using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public void DeleteItem(long id)
        {
            var sensor = Database.Sensors.Find(id);

            if (sensor != null)
            {
                Database.Sensors.Remove(sensor);
            }
        }

        public IEnumerable<Sensor> GetAll()
        {
            var sensors = Database.Sensors;

            return sensors;
        }

        public Sensor GetItem(long id)
        {
            var sensor = Database.Sensors.Find(id);

            return sensor;
        }

        public void SaveItem(Sensor item)
        {
            Database.Sensors.Add(item);
        }

        public void UpdateItem(Sensor item)
        {
            Database.Entry(item).State = EntityState.Modified;
        }
    }
}
