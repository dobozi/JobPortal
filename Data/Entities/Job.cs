using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace JobsPortal.Data.Entities
{
       public class Job
    {   [Required]
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string CompanyName { get; set; }
        public string WorkplaceAddress { get; set; }
        public string WorkSchedule { get; set; }

    }
}
