using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.DTO
{
    public class PaginationDTO
    {
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 20;
    }
}
