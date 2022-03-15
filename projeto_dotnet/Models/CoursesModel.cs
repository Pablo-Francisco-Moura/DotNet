using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_dotnet.Models
{
    public class CoursesModel
    {
        public int Id{ get; set; }
        [Required]
        public string Title { get; set; }
        public string Duration{ get; set; }
        public IEnumerable<Status> Status{ get; set; }
    }
}
