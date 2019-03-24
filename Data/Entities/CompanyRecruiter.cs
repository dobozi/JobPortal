using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsPortal.Data.Entities
{
    public class CompanyRecruiter
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int RecruiterId { get; set; }
        public Recruiter Recruiter { get; set; }        
       
    }
}
