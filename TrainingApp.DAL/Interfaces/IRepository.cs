using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.DAL.Interfaces
{
    public interface IRepository<T> : ICommonRepository<T>
    {
        abstract T GetItem(long? id);
        abstract IEnumerable<T> GetAll();

    

    }
}
