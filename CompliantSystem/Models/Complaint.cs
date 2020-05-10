using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompliantSystem.Models
{
    public class Complaint
    {
        public int ComplaintId { get; set; }
        public int UserId { get; set; }

        public String ComplaintSubject { get; set; }
        public String ComplaintDescription { get; set; }
        public int ComplaintStatus { get; set; }

    }
}
