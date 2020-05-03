using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Repositories
{
    public class UserRepository : CommonRepository<User>, IRepository<User>
    {
        private readonly TrainingDBContext Database;

        public UserRepository(TrainingDBContext database) : base(database)
        {

        }

        public IEnumerable<User> GetAll()
        {
            return Database.User;
        }

        public User GetItem(long? id)
        {
            var user = Database.User.Include("Role").Include("Training").Where(user => user.Id == id.Value).FirstOrDefault();

            return user;
        }

    }
}
