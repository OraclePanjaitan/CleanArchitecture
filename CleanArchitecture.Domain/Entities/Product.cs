using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{    
    public class Product
    {
        [Key]
        public int Kode { get; set; }

        [Required]
        public string Name { get; set; }
        public string Manufacturer { get; set; } = "Toyota";
        public int Rating { get; set; } = 1;
        public Guid UniqueCode { get; set; } = Guid.NewGuid();

    }
}
