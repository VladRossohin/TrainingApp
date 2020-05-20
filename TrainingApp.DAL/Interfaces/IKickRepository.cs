using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Interfaces
{
    public interface IKickRepository : IRepository<Kick>
    {
        IEnumerable<Kick> GetByExerciseId(long id);
    }
}
