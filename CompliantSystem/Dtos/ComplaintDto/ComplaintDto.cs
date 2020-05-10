using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompliantSystem.Dtos.ComplaintDto
{
    public class ComplaintDto
    {
        public int ComplaintId { get; set; }
        public UserDto  userDto { get; set; }

        public String ComplaintSubject { get; set; }
        public String ComplaintDescription { get; set; }
        public String ComplaintStatusName { get; set; }
        public int ComplaintStatus { get; set; }
    }
}
