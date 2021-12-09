using CbtScheduler.Application.StudentScheduleService;
using CbtScheduler.Core.Entities;
using CbtScheduler.Core.Entities.Dtos;
using CbtScheduler.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CbtScheduler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentScheduleController : ControllerBase
    {
        private readonly IStudentScheduleService _studentScheduleService;
        public StudentScheduleController(IStudentScheduleService studentScheduleService)
        {
            _studentScheduleService = studentScheduleService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _studentScheduleService.GetAllAsync());
        }

        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _studentScheduleService.GetByIdAsync(id));
        }

        [HttpGet("GetStudentByMatricNo{MatricNo}")]
        public async Task<IActionResult> GetStudentByMatricNoAsync(string matricNo)
        {
            return Ok(await _studentScheduleService.GetStudentByMatricNoAsync(matricNo));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddASync(StudentSchedule entity)
        {            
            return Ok(await _studentScheduleService.AddAsync(entity));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _studentScheduleService.DeleteAsync(id));
        }

        [HttpPut("Insert")]
        public async Task<IActionResult> UpdateAsync(UpdateDto entity)
        {
            return Ok(await _studentScheduleService.UpdateAsync(entity));
        }
    }

}
