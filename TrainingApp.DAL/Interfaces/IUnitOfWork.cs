using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.DAL.Models;
using TrainingApp.DAL.Repositories;

namespace TrainingApp.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        CommonRepository<Excercise> Excercises { get; }
        CommonRepository<Kick> Kicks { get; }
        CommonRepository<Role> Roles { get; }
        CommonRepository<Sensor> Sensors { get; }
        CommonRepository<Training> Trainings { get; }
        CommonRepository<User> Users { get; }

        void Commit();
        void Rollback();
    }
}
