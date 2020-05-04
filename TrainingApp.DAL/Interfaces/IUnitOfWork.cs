using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.DAL.Models;
using TrainingApp.DAL.Repositories;

namespace TrainingApp.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICommonRepository<Excercise> Excercises { get; }
        ICommonRepository<Kick> Kicks { get; }
        ICommonRepository<Role> Roles { get; }
        ICommonRepository<Sensor> Sensors { get; }
        ICommonRepository<Training> Trainings { get; }
        CommonRepository<User> Users { get; }

        void Commit();
        void Rollback();
    }
}
