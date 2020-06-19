using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMotors.WebMotorsWeb.Models
{
    public class ModelViewModel
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public virtual MakeViewModel Make { get; set; }
        public string Name { get; set; }
    }
}
