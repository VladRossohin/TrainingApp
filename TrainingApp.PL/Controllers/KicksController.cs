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
    [Route("api/kicks")]
    public class KicksController : ControllerBase
    {
        private readonly IKickService _kickService;
        private readonly IMapper _mapper;

        public KicksController(IKickService kickService, IMapper mapper)
        {
            _kickService = kickService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllKicks()
        {
            var kickDtos = _kickService.GetAll();
            var kicks = _mapper.Map<IEnumerable<KickDTO>, IEnumerable<KickModel>>(kickDtos);

            return Ok(kicks);
        }

        [HttpGet("{id}")]
        public ActionResult GetKickById(long? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("The id value is not set!");
            }

            var kickDto = _kickService.GetItem(id.Value);

            if (kickDto == null)
            {
                return NotFound();
            }

            var kick = _mapper.Map<KickDTO, KickModel>(kickDto);

            return Ok(kick);
        }

        public ActionResult CreateKick([FromBody]KickModel kick)
        {
            if (kick == null)
            {
                return BadRequest("The kick model is empty!");
            }

            try
            {
                var kickDto = _mapper.Map<KickModel, KickDTO>(kick);
                _kickService.SaveItem(kickDto);

                return Ok("The kick was succesfully created!");
            }
            catch
            {
                return StatusCode(500, "An error has occured!");
            }

        }

        [HttpPut("{id?}")]
        public ActionResult UpdateKick(long? id, [FromBody]KickModel kick)
        {
            if (!id.HasValue)
            {
                return BadRequest("The kick id was not set!");
            }

            if (kick == null)
            {
                return BadRequest("The kick model is empty!");
            }

            try
            {
                var kickDto = _kickService.GetItem(id.Value);
                if (kickDto == null)
                {
                    return NotFound();
                }

                _mapper.Map(kick, kickDto);

                kickDto.Id = id.Value;

                _kickService.SaveItem(kickDto);

                return Ok("The kick has been succesfully updated!");

            }
            catch
            {
                return StatusCode(500, "An error was occured!");
            }
        }

        [HttpDelete("{id?}")]
        public ActionResult DeleteKick(long? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("The kick id was not set!");
            }

            try
            {
                var kickDto = _kickService.GetItem(id.Value);

                if (kickDto == null)
                {
                    return NotFound();
                }

                _kickService.DeleteItem(id.Value);

                return Ok($"The kick {kickDto.KickDateTime.Date} has been succesfully deleted!");
            }
            catch
            {
                return StatusCode(500, "An error was occured!");
            }
        }
    }
}
