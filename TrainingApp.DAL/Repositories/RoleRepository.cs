using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Repositories
{
    public class RoleRepository : CommonRepository<Role>
    {
        private readonly TrainingDBContext Database;

        public RoleRepository(TrainingDBContext database) : base(database)
        {

        }

        public override IEnumerable<Role> GetAll()
        {
            return Database.Role;
        }

        public override Role GetItem(long? id)
        {
            var role = Database.Role.Include("User").Where(r => r.Id == id.Value).FirstOrDefault();

            return role;
        }

    }
}
