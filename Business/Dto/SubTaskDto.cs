using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class SubTaskDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public int Level { get; set; }

        public ICollection<SubTaskDto> Subtasks { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }
        
        public int TaskId { get; set; }
    }
}
