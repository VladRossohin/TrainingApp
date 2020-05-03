using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Repositories
{
    public class ExcerciseRepository : CommonRepository<Excercise>, IRepository<Excercise>
    {

        private readonly TrainingDBContext Database;

        public ExcerciseRepository(TrainingDBContext database) : base(database)
        {

        }

        public IEnumerable<Excercise> GetAll()
        {
            return Database.Excercise;
        }

        public Excercise GetItem(long? id)
        {
            var excercise = Database.Excercise.Include("Sensor").Include("Training").Include("Kick").Where(exer => exer.Id == id.Value).FirstOrDefault();

            return excercise;
        }

    }
}
