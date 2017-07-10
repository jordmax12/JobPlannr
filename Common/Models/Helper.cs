using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [Table("Helper")]
    public class Helper
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User2 { get; set; }
        public int HelperId { get; set; }

        public int? EntryId { get; set; }
    }
}
