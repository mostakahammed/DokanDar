using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Application.DTO
{
    public class CategoryDto
    {
        public int CategoryID { get; set; }

        [Required, StringLength(20)]
        public string CategoryName { get; set; }

        [Required, StringLength(50)]
        public string? Description { get; set; }

        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUser { get; set; } = string.Empty;
        public DateTime? UpdateDate { get; set; }
    }
}
