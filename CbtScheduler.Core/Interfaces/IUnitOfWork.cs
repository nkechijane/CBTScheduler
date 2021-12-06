using CbtScheduler.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtScheduler.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentScheduleRepository StudentSchedule { get; set; }
    }
}
