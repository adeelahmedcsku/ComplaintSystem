
using CompliantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompliantSystem.Services
{
   public interface IComplaintService
    {

        
        IEnumerable<Complaint> GetAll();
        Complaint GetById(int id);
        Complaint Create(Complaint complaint);
        void Update(Complaint complaint);
        void Delete(int id);
        List<Complaint> GetComplaintsByUser(int userId);
    }
}
