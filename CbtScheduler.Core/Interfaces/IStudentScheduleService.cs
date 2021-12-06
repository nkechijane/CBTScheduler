using CbtScheduler.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtScheduler.Core.Interfaces
{
    public interface IStudentScheduleService
    {
        public Task<StudentSchedule> GetByIdAsync(int id);
        public Task<IReadOnlyList<StudentSchedule>> GetAllAsync();
        public Task<string> AddAsync(StudentSchedule entity);
        public Task<string> UpdateAsync(StudentSchedule entity);
        public Task<string> DeleteAsync(int id);
        public Task<StudentSchedule> GetStudentDataAsync(string matricNumber);
        public Task<IReadOnlyList<StudentSchedule>> GetAllStudentByTimeAsync(DateTime time);
    }
}
