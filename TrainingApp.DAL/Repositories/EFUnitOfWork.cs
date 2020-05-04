﻿using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly TrainingDBContext _dBContext;

        private readonly ExcerciseRepository _excerciseRepository;
        private readonly KickRepository _kickRepository;
        private readonly RoleRepository _roleRepository;
        private readonly SensorRepository _sensorRepository;
        private readonly TrainingRepository _trainingRepository;
        private readonly UserRepository _userRepository;

        public EFUnitOfWork(TrainingDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public CommonRepository<Excercise> Excercises => _excerciseRepository ?? new ExcerciseRepository(_dBContext);

        public CommonRepository<Kick> Kicks => _kickRepository ?? new KickRepository(_dBContext);

        public CommonRepository<Role> Roles => _roleRepository ?? new RoleRepository(_dBContext);

        public CommonRepository<Sensor> Sensors => _sensorRepository ?? new SensorRepository(_dBContext);

        public CommonRepository<Training> Trainings => _trainingRepository ?? new TrainingRepository(_dBContext);

        public CommonRepository<User> Users => _userRepository ?? new UserRepository(_dBContext);

        public void Commit()
        {
            _dBContext.SaveChanges();
        }

        public void Rollback()
        {
            _dBContext.Dispose();
        }
    }
}
