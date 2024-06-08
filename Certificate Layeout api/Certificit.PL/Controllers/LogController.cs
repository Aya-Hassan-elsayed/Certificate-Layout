using AutoMapper;
using Certificit.DAL.Entities;
using Certificit.DAL.Interfaces;
using Certificit.PL.DTO;
using Certificit.PL.Error;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Certificit.PL.Controllers
{
    public class LogController : ApiController
    {
        public IGenaricInterface<Log> Log { get; }
        public IMapper Mapper { get; }

        public LogController(IGenaricInterface<Log> log , IMapper mapper)
        {
            Log = log;
            Mapper = mapper;
        }

        #region Get All Logs
        [HttpGet]
        public async Task<ActionResult> GetAll ()
        {
            try
            {

                var LogsData = await Log.GetAll();
                if (LogsData == null)
                {
                    return NotFound(new ApiResponse(404));
                }
                var mapp = Mapper.Map<IEnumerable<Log>, IEnumerable<ReturnlogDto>>(LogsData);
                return Ok(mapp);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "Internal Server Error: " + ex.Message));
            }
        }
        #endregion

        #region add new log
        [HttpPost]
        public async Task<ActionResult> AddLog(LogDto logDto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(400 , "log data issue"));
                }
                var mapp = Mapper.Map<LogDto,Log>(logDto);
                int result = await Log.AddAsync(mapp);
                if (result == 0)
                {
                    return BadRequest(new ApiResponse(400, "log data issue"));
                }
               return Ok(new ApiResponse(200));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "Internal Server Error: " + ex.Message));
            }
        }
        #endregion
    }
}
