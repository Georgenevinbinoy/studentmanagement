using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student
{
    public class StudentDetails
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public String FirstName { get; set; }
        [Required]
        [StringLength(255)]
        public String LastName { get; set; }
        [Required]
        [StringLength(255)]
        public String Address { get; set; }
        [Required]
        [StringLength(255)]
        public String Phone { get; set; }
        
        public DateTime Dob { get; set; }
        public DateTime Eod { get; set; }
        [Required]
        [StringLength(255)]
        public String Course { get; set; }

    }
}
