using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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

        public UserRepository(TrainingDBContext database)
        {
            Database = database;
        }

        public void DeleteItem(long id)
        {
            var user = Database.Users.Find(id);

            if (user != null)
            {
                Database.Users.Remove(user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            var users = Database.Users;

            return users;
        }

        public User GetItem(long id)
        {
            var user = Database.Users.Include("Role").Where(us => us.Id == id).FirstOrDefault();

            return user;
        }

        public void SaveItem(User item)
        {
            Database.Users.Add(item);
        }

        public void UpdateItem(User item)
        {
            Database.Entry(item).State = EntityState.Modified;
        }
    }
}
