using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsPortal.Data.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Document CV { get; set; }
        public string Adress { get; set; }
        public int PhoneNumber { get; set; }
    }
}
