using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Repositories
{
    public class RoleRepository : IRepository<Role>
    {

        private readonly TrainingDBContext Database;

        public RoleRepository(TrainingDBContext database)
        {
            Database = database;
        }

        public void DeleteItem(long id)
        {
            var role = Database.Roles.Find(id);

            if (role != null)
            {
                Database.Roles.Remove(role);
            }
        }

        public IEnumerable<Role> GetAll()
        {
            var roles = Database.Roles;

            return roles;
        }

        public Role GetItem(long id)
        {
            var role = Database.Roles.Find(id);

            return role;
        }

        public void SaveItem(Role item)
        {
            Database.Roles.Add(item);
        }

        public void UpdateItem(Role item)
        {
            Database.Entry(item).State = EntityState.Modified;
        }
    }
}
