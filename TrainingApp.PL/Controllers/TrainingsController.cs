using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingApp.Api.Models;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Interfaces;
using TrainingApp.DAL.Models;

namespace TrainingApp.Api.Controllers
{
    [ApiController]
    [Route("api/trainings")]
    public class TrainingsController : ControllerBase
    {
        private readonly ITrainingService _trainingService;
        private readonly IMapper _mapper;

        public TrainingsController(ITrainingService trainingService, IMapper mapper)
        {
            _trainingService = trainingService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllTrainings()
        {
            var trainingDtos = _trainingService.GetAll();

            var trainings = _mapper.Map<IEnumerable<TrainingDTO>, IEnumerable<TrainingModel>>(trainingDtos);

            return Ok(trainings);
        }

        [HttpGet("{id}")]
        public ActionResult GetTrainingById(long? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("The id value is not set!");
            }

            var trainingDto = _trainingService.GetItem(id.Value);

            if (trainingDto == null)
            {
                return NotFound();
            }

            var training = _mapper.Map<TrainingDTO, TrainingModel>(trainingDto);

            return Ok(training);
        }

        [HttpGet("user/{id}")]
        public ActionResult GetTrainingsByUserId(long? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("The id value is not set!");
            }

            var trainingDtos = _trainingService.GetByUserId(id.Value);

            var trainings = _mapper.Map<IEnumerable<TrainingDTO>, IEnumerable<TrainingModel>>(trainingDtos);

            return Ok(trainings);
        }


        [HttpPost("create")]
        public ActionResult CreateTraining([FromBody]TrainingModel training)
        {
            if (training == null)
            {
                return BadRequest("The training model is empty!");
            }

            try
            {
                var trainingDto = _mapper.Map<TrainingModel, TrainingDTO>(training);
                _trainingService.SaveItem(trainingDto);

                return Ok("The training was succesfully created!");
            }
            catch
            {
                return StatusCode(500, "An error has occured!");
            }

        }

        [HttpPut("{id?}")]
        public ActionResult UpdateTraining(long? id, [FromBody]TrainingModel training)
        {
            if (!id.HasValue)
            {
                return BadRequest("The training id was not set!");
            }

            if (training == null)
            {
                return BadRequest("The training model is empty!");
            }

            try
            {
                var trainingDto = _trainingService.GetItem(id.Value);
                if (trainingDto == null)
                {
                    return NotFound();
                }

                _mapper.Map(training, trainingDto);

                trainingDto.Id = id.Value;

                _trainingService.SaveItem(trainingDto);

                return Ok($"The training {trainingDto.Id} {trainingDto.Name} has been succesfully updated!");

            }
            catch
            {
                return StatusCode(500, "An error was occured!");
            }
        }

        [HttpDelete("{id?}")]
        public ActionResult DeleteTraining(long? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("The training id was not set!");
            }

            try
            {
                var trainingDto = _trainingService.GetItem(id.Value);

                if (trainingDto == null)
                {
                    return NotFound();
                }

                _trainingService.DeleteItem(id.Value);

                return Ok($"The training {trainingDto.Id} {trainingDto.Name} has been succesfully deleted!");
            }
            catch
            {
                return StatusCode(500, "An error was occured!");
            }
        }
    }
}
