using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsPortal.Data.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Ext { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
    }
}
