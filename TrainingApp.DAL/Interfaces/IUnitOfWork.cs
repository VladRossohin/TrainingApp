using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IExerciseRepository Exercises { get; }
        IKickRepository Kicks { get; }
        IRepository<Role> Roles { get; }
        IRepository<Sensor> Sensors { get; }
        IRepository<Training> Trainings { get; }
        IRepository<User> Users { get; }

        void Commit();
        void Rollback();
    }
}
