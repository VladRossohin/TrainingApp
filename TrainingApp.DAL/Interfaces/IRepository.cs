using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.DAL.Interfaces
{
    public interface IRepository<T>
    {
        T GetItem(long? id);
        IEnumerable<T> GetAll();

    

    }
}
