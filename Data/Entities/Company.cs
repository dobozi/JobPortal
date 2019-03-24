using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsPortal.Data.Entities
{
    public class Company
    {       
        public int Id { get; set; }
        public int UserId { get; set; }

        public ICollection<CompanyRecruiter> CompanyRecruiters { get; }

    }
  
}
