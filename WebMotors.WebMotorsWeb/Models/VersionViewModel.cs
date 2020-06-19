using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMotors.WebMotorsWeb.Models
{    
    public class VersionViewModel
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public virtual ModelViewModel Make { get; set; }
        public string Name { get; set; }
    }
}
