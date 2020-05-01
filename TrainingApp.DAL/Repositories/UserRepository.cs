using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly TrainingDBContext Database;

        public UserRepository(TrainingDBContext dBContext)
        {
            this.Database = dBContext;
        }

        public void DeleteItem(User item)
        {
            Database.User.Remove(item);

            Database.SaveChangesAsync();
        }

        public User GetItem(int? id)
        {
            var user = Database.User.Include("Role").Include("Training").Where(user => user.Id == id.Value).FirstOrDefault();

            return user;
        }

        public void SaveItem(User item)
        {
            Database.User.Add(item);

            Database.SaveChangesAsync();
        }

        public void UpdateItem(User item)
        {
            Database.Entry(item).State = EntityState.Modified;

            Database.User.Update(item);

            Database.SaveChangesAsync();
        }
    }
}
