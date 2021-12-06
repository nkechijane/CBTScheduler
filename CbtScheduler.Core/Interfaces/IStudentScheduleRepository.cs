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
        Task<IReadOnlyList<StudentSchedule>> GetAllStudentByTimeAsync(DateTime time);
        Task<IReadOnlyList<StudentSchedule>> GetStudentDataAsync(string matricNumber);
    }
}
