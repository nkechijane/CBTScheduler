using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtScheduler.Core.Entities.Dtos
{
    public class UpdateDto
    {
        public int Id { get; set; }
        public DateTime DayAndTime { get; set; }
        public string Hall { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Lab { get; set; }
    }
}
