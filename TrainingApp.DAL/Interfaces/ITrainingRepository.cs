using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Interfaces
{
    public interface ITrainingRepository : IRepository<Training>
    {
        IEnumerable<Training> GetByUserId(long id);
    }
}
