using AutoMapper;
using LogError.Domain.DTO;
using LogError.Domain.Entities;
using LogError.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LogError.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInfoController : ControllerBase
    {
        private readonly ILogInfoService _logInfoService;
        private readonly IMapper _mapper;

        public LogInfoController(ILogInfoService logInfoService, IMapper mapper)
        {
            _logInfoService = logInfoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Inclui uma nova informação de log
        /// </summary>
        /// <param name="logInfoDTO">Objeto log</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<LogInfoDTO> Post([FromBody] AddLogInfoDTO logInfoDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new ArgumentNullException("O log é obrigatorio");

                var logInfo = _mapper.Map<LogInfoDTO>(_logInfoService.Save(_mapper.Map<LogInfo>(logInfoDTO)));

                return Ok(logInfo);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Retorna lista de log's
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<LogInfoDTO>> Get()
        {
            return _mapper.Map<List<LogInfoDTO>>(_logInfoService.LogInfos());
        }

        /// <summary>
        /// Retorna log por Id
        /// </summary>
        /// <param name="id">Id do log</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<LogInfoDTO> Get(Guid id)
        {
            var log = _mapper.Map<LogInfoDTO>(_logInfoService.GetLogInfo(id));

            return log;
        }
    }
}
