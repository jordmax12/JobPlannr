using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class TaskDto
    {
        public int Id { get; set; }

        public int PlannerId { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string Affiliation { get; set; }

        public string Footprint { get; set; }

        public ICollection<SubTaskDto> SubTasks { get; set; }

        public ICollection<HelperDto> Helpers { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }
    }
}
