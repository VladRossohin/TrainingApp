using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingApp.Api.Models;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Interfaces;
using TrainingApp.BLL.Services;

namespace TrainingApp.Api.Controllers
{
    [ApiController]
    [Route("api/sensors")]
    public class SensorsController : ControllerBase
    {

        private readonly ISensorService _sensorService;
        private readonly IMapper _mapper;

        public SensorsController(ISensorService sensorService, IMapper mapper)
        {
            _sensorService = sensorService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllSensors()
        {
            var sensorDtos = _sensorService.GetAll();

            var sensors = _mapper.Map<IEnumerable<SensorDTO>, IEnumerable<SensorModel>>(sensorDtos);

            return Ok(sensors);
        }

        [HttpGet("{id}")]
        public ActionResult GetSensorById(long? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("The id value is not set!");
            }

            var sensorDto = _sensorService.GetItem(id.Value);

            if (sensorDto == null)
            {
                return NotFound();
            }

            var sensor = _mapper.Map<SensorDTO, SensorModel>(sensorDto);

            return Ok(sensor);
        }


        [HttpPost("create")]
        public ActionResult CreateSensor([FromBody]SensorModel sensor)
        {
            if (sensor == null)
            {
                return BadRequest("The sensor model is empty!");
            }

            try
            {
                var sensorDto = _mapper.Map<SensorModel, SensorDTO>(sensor);
                _sensorService.SaveItem(sensorDto);

                return Ok("The sensor was succesfully created!");
            }
            catch
            {
                return StatusCode(500, "An error has occured!");
            }

        }

        [HttpPut("{id?}")]
        public ActionResult UpdateSensor(long? id, [FromBody]SensorModel sensor)
        {
            if (!id.HasValue)
            {
                return BadRequest("The sensor id was not set!");
            }

            if (sensor == null)
            {
                return BadRequest("The sensor model is empty!");
            }

            try
            {
                var sensorDto = _sensorService.GetItem(id.Value);
                if (sensorDto == null)
                {
                    return NotFound();
                }

                _mapper.Map(sensor, sensorDto);

                sensorDto.Id = id.Value;

                _sensorService.SaveItem(sensorDto);

                return Ok("The sensor has been succesfully updated!");

            }
            catch
            {
                return StatusCode(500, "An error was occured!");
            }
        }

        [HttpDelete("{id?}")]
        public ActionResult DeleteSensor(long? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("The sensor id was not set!");
            }

            try
            {
                var sensorDto = _sensorService.GetItem(id.Value);

                if (sensorDto == null)
                {
                    return NotFound();
                }

                _sensorService.DeleteItem(id.Value);

                return Ok($"The sensor {sensorDto.Id} {sensorDto.Name} has been succesfully deleted!");
            }
            catch
            {
                return StatusCode(500, "An error was occured!");
            }
        }
    }
}
