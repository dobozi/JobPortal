using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsPortal.Data.Entities
{
    public class Recruiter
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Identifier { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public int PhoneNumber { get; set; }

        public ICollection<CompanyRecruiter> CompanyRecruiters { get; }
        public bool Deleted { get; set; }

    }
}
