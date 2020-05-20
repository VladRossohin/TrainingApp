using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Interfaces
{
    public interface IExerciseRepository : IRepository<Exercise>
    {
        IEnumerable<Exercise> GetByTrainingId(long id);
        IEnumerable<Exercise> GetBySensorId(long id);
    }
}
