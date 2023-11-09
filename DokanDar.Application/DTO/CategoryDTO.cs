using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Application.DTO
{
    public class CategoryDTO
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string? Description { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string UpdateUser { get; set; } = string.Empty;
        public DateTime? UpdateDate { get; set; }
    }
}
