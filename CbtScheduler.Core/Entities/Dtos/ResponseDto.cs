using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtScheduler.Core.Entities.Dtos
{
    public class ResponseDto
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Payload { get; set; }
    }
}
