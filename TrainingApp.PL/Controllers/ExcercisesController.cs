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
    [Route("api/excercises")]
    public class ExcercisesController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        private readonly IMapper _mapper;

        public ExcercisesController(IExerciseService exerciseService, IMapper mapper)
        {
            _exerciseService = exerciseService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllExercises()
        {
            var exerciseDtos = _exerciseService.GetAll();

            var exercises = _mapper.Map<IEnumerable<ExerciseDTO>, IEnumerable<ExerciseModel>>(exerciseDtos);

            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public ActionResult GetExerciseById(long? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("The id value is not set!");
            }

            var exerciseDto = _exerciseService.GetItem(id.Value);

            if (exerciseDto == null)
            {
                return NotFound();
            }

            var exercise = _mapper.Map<ExerciseDTO, ExerciseModel>(exerciseDto);

            return Ok(exercise);
        }

        [HttpPost("create")]
        public ActionResult CreateExercise([FromBody]ExerciseModel exercise)
        {
            if (exercise == null)
            {
                return BadRequest("The exercise model is empty!");
            }

            try
            {
                var exerciseDto = _mapper.Map<ExerciseModel, ExerciseDTO>(exercise);
                _exerciseService.SaveItem(exerciseDto);

                return Ok("The exercise was succesfully created!");
            }
            catch
            {
                return StatusCode(500, "An error has occured!");
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(long? id, [FromBody]ExerciseModel exercise)
        {
            if (!id.HasValue)
            {
                return BadRequest("The exercise id was not set!");
            }

            if (exercise == null)
            {
                return BadRequest("The exercise model is empty!");
            }

            try
            {
                var exerciseDto = _exerciseService.GetItem(id.Value);
                if (exerciseDto == null)
                {
                    return NotFound();
                }

                _mapper.Map(exercise, exerciseDto);

                exerciseDto.Id = id.Value;

                _exerciseService.SaveItem(exerciseDto);

                return Ok("The exercise has been succesfully updated!");

            }
            catch
            {
                return StatusCode(500, "An error was occured!");
            }
        }
    }
}
