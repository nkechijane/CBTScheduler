using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtScheduler.Core.Entities
{
    public class StudentSchedule
    {
        public int Id { get; set; }
        public string MatricNumber { get; set; }
        public int SessionId { get; set; }
        public int SemesterId { get; set; }
        public string Level { get; set; }
        public string CourseCode { get; set; }
        public DateTime Day { get; set; }
        public DateTime Time { get; set; }
        public string Hall { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Lab { get; set; }


    }
}
