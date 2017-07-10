using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [Table("SubTask")]
    public class SubTask
    {

        public SubTask()
        {
            //Subtasks = new List<SubTask>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public int Level { get; set; }

        public virtual ICollection<SubTask> Subtasks { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }

        public virtual Task Task { get; set; }
    }
}
