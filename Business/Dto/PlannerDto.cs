using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class PlannerDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime Created { get; set; }
        
        public DateTime? Modified { get; set; }
        
        public int UserId { get; set; }
    }
}
