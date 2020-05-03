using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.BLL.Interfaces
{
    public interface IService<T>
    {
        T GetItem(long? id);
        IEnumerable<T> GetAll();

        void UpdateItem(T item);

        void SaveItem(T item);

        void DeleteItem(long? id);
    }
}
