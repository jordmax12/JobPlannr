using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [Table("Entry")]
    public class Entry
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string CompanyName { get; set; }

        public string Description { get; set; }

        [MaxLength(100)]
        public string Source { get; set; }

        [MaxLength(100)]
        public string Status { get; set; }

        public int Rank { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public virtual List<Helper> Contributors { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

    }
}
