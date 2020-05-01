using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.DAL.Interfaces
{
    public interface ICommonRepository<T>
    {
        void UpdateItem(T item);
        void SaveItem(T item);
        void DeleteItem(T item);
    }
}
