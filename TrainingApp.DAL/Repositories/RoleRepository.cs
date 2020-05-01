using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Repositories
{
    public class RoleRepository : CommonRepository<Role>, IRepository<Role> 
    {
        private readonly TrainingDBContext Database;

        public RoleRepository(TrainingDBContext database) : base(database)
        {

        }

        public IEnumerable<Role> GetAll()
        {
            return Database.Role;
        }

        public Role GetItem(int? id)
        {
            var role = Database.Role.Include("User").Where(r => r.Id == id.Value).FirstOrDefault();

            return role;
        }

    }
}
