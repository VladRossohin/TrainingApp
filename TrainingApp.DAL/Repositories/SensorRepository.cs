using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Repositories
{
    public class SensorRepository : CommonRepository<Sensor>, IRepository<Sensor>
    {

        private readonly TrainingDBContext Database;

        public SensorRepository(TrainingDBContext database) : base(database)
        {

        }

        public IEnumerable<Sensor> GetAll()
        {
            return Database.Sensor;
        }

        public Sensor GetItem(int? id)
        {
            var sensor = Database.Sensor.Include("Excercise").Include("Kick").Where(s => s.Id == id.Value).FirstOrDefault();

            return sensor;
        }

    }
}
