using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void DeleteItem(Role item)
        {
            Database.Role.Remove(item);
            Database.SaveChangesAsync();
        }

        public Role GetItem(int? id)
        {
            var role = Database.Role.Include("User").Where(r => r.Id == id).FirstOrDefault();

            return role;
        }

        public void SaveItem(Role item)
        {
            Database.Role.Add(item);
            Database.SaveChangesAsync();
        }

        public void UpdateItem(Role item)
        {
            Database.Entry(item).State = EntityState.Modified;
            Database.Role.Update(item);

            Database.SaveChangesAsync();
        }
    }
}
