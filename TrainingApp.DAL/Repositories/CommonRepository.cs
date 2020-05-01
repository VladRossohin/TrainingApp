using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Repositories
{
    public abstract class CommonRepository<T> : ICommonRepository<T>
    {

        private readonly TrainingDBContext Database;

        protected CommonRepository(TrainingDBContext database)
        {
            Database = database;
        }

        public void DeleteItem(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            Database.Remove(item);
        }

        public void SaveItem(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            Database.Add(item);
        }

        public void UpdateItem(T item)
        {
            Database.Entry(item).State = EntityState.Modified;
        }
    }
}
