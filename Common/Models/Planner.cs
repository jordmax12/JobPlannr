using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [Table("Planner")]
    public class Planner
    {
        public int Id { get; set; }

        [MaxLength(100), MinLength(5)]
        public string Name { get; set; }

        //[DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime Created { get; set; }

        //[DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime? Modified { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
