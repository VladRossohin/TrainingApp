using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Infrastructure;
using TrainingApp.BLL.Interfaces;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.BLL.Services
{
    public class SensorService : ISensorService
    {

        private readonly IUnitOfWork Database;

        public SensorService(IUnitOfWork database)
        {
            Database = database;
        }

        public void DeleteItem(long? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("The id value is not set!", String.Empty);
            }

            try
            {
                var sensor = Database.Sensors.GetItem(id.Value);

                if (sensor == null)
                {
                    throw new ValidationException($"There's no sensor with id = {id.Value}!", String.Empty);
                }

                Database.Sensors.DeleteItem(sensor);

                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }

        public IEnumerable<SensorDTO> GetAll()
        {
            var sensors = Database.Sensors.GetAll();

            var sensorDtos = Mapper.Map<IEnumerable<Sensor>, IEnumerable<SensorDTO>>(sensors);

            return sensorDtos;
        }

        public SensorDTO GetItem(long? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("The id value is not set!", String.Empty);
            }

            var sensor = Database.Sensors.GetItem(id.Value);

            if (sensor == null)
            {
                throw new ValidationException($"There's no sensor with id = {id.Value}!", String.Empty);
            }

            var sensorDto = Mapper.Map<Sensor, SensorDTO>(sensor);

            return sensorDto;
        }

        public void SaveItem(SensorDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("The semsor is empty!", String.Empty);
            }

            try
            {
                var sensor = Mapper.Map<SensorDTO, Sensor>(item);

                Database.Sensors.SaveItem(sensor);
                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }

        public void UpdateItem(SensorDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("The semsor is empty!", String.Empty);
            }

            try
            {
                var sensor = Mapper.Map<SensorDTO, Sensor>(item);

                Database.Sensors.UpdateItem(sensor);
                Database.Commit();
            }
            catch
            {
                throw new ValidationException("An error has occured!", String.Empty);
            }
        }
    }
}
