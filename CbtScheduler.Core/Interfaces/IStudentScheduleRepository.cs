using CbtScheduler.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtScheduler.Application.Interfaces
{
    public interface IStudentScheduleRepository : IGenericRepository<StudentSchedule>
    {
        Task<List<StudentSchedule>> GetAllStudentByDateAsync(DateTime time);
        Task<StudentSchedule> GetStudentDataAsync(string matricNumber);
    }
}
