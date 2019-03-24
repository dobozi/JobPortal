using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobsPortal.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters")]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public DateTime Modified { get; set; }

        public Boolean Enabled { get; set; }

        public string Schema { get; set; }

    }
}
