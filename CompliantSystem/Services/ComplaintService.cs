using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompliantSystem.Helpers;
using CompliantSystem.Models;

namespace CompliantSystem.Services
{
    public class ComplaintService : IComplaintService
    {
        private DataContext _context;

        public ComplaintService(DataContext context)
        {
            _context = context;
        }

        public Complaint Create(Complaint complaint)
        {
            _context.Complaints.Add(complaint);
            _context.SaveChanges();
            return complaint;
        }

        public void Delete(int id)
        {
            var complaint = _context.Complaints.Find(id);
            if (complaint != null)
            {
                _context.Complaints.Remove(complaint);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Complaint> GetAll()
        {
            return _context.Complaints;
        }

        public Complaint GetById(int id)
        {
            return _context.Complaints.Find(id);
        }

        public void Update(Complaint complaint)
        {
            var _complaint = _context.Complaints.Find(complaint.ComplaintId);

            if (_complaint == null)
                throw new AppException("Complaint not found");

            // update complaint properties
            _complaint.UserId = complaint.UserId;
            _complaint.ComplaintSubject = complaint.ComplaintSubject;
            _complaint.ComplaintDescription = complaint.ComplaintDescription;
            _complaint.ComplaintStatus = complaint.ComplaintStatus;
            _context.Complaints.Update(_complaint);
            _context.SaveChanges();
        }

        public  List<Complaint> GetComplaintsByUser(int userId)
        {
            var db = _context;
            return (from s in db.Complaints
                    where s.UserId == userId
                    select s).ToList();
        }
    }
}
