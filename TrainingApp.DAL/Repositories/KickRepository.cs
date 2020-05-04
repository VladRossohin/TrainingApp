using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Repositories
{
    public class KickRepository : CommonRepository<Kick>
    {

        private readonly TrainingDBContext Database;

        public KickRepository(TrainingDBContext database) : base(database)
        {

        }

        public override IEnumerable<Kick> GetAll()
        {
            return Database.Kick;
        }

        public override Kick GetItem(long? id)
        {
            var kick = Database.Kick.Include("Excercise").Include("Sensor").Where(k => k.Id == id.Value).FirstOrDefault();

            return kick;
        }

    }
}
