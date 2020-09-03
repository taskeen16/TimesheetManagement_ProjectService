using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectService.Database.Entities
{
    public class project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string NatureofIndustry { get; set; }

        public string ProjectCode { get; set; }
    }
}
