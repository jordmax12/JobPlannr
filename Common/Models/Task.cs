using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [Table("Task")]
    public class Task
    {

        public Task()
        {
            SubTasks = new List<SubTask>();
        }
        public int Id { get; set; }

        [ForeignKey("Planner")]
        public int PlannerId { get; set; }

        public virtual Planner Planner { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string Affiliation { get; set; }

        public string Footprint { get; set; }
        
        public virtual ICollection<SubTask> SubTasks { get; set; }        

        public virtual ICollection<Helper> Helpers { get; set; }        

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }
    }
}
