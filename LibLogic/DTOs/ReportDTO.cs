using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibLogic.DTOs
{
    public class ReportDTO
    {
        public string? ReportName { get; set; }
        public DateTime ReportDate { get; set; }
        public List<UserDTO>? Users { get; set; }
    }
}
