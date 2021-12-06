using CbtScheduler.Core.Entities;
using CbtScheduler.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtScheduler.Application.StudentScheduleService
{
    public class StudentScheduleService : IStudentScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentScheduleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> AddAsync(StudentSchedule entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<StudentSchedule>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<StudentSchedule>> GetAllStudentByTimeAsync(DateTime time)
        {
            throw new NotImplementedException();
        }

        public Task<StudentSchedule> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StudentSchedule> GetStudentDataAsync(string matricNumber)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(StudentSchedule entity)
        {
            throw new NotImplementedException();
        }
    }
}
