using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [Table("Contributor")]
    public class Contributor
    {
        public int Id { get; set; }

        //type will be an enum
        public int Type { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Company { get; set; }

        public virtual List<Entry> Entries { get; set; } 
    }
}
