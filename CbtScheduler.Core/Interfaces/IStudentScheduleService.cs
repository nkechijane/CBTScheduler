using CbtScheduler.Core.Entities;
using CbtScheduler.Core.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtScheduler.Core.Interfaces
{
    public interface IStudentScheduleService
    {
        public Task<ResponseDto> GetByIdAsync(int id);
        public Task<ResponseDto> GetAllAsync();
        public Task<ResponseDto> AddAsync(StudentSchedule entity);
        public Task<ResponseDto> UpdateAsync(UpdateDto entity);
        public Task<ResponseDto> DeleteAsync(int id);
        public Task<ResponseDto> GetStudentByMatricNoAsync(string matricNumber);
        public Task<ResponseDto> GetStudentByDateAsync(DateTime time);
        public Task<string> GenerateTimeTableAsync();

    }
}
