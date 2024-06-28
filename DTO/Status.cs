using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Status
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string StatusInfo { get; set; } = string.Empty;
    }
}
