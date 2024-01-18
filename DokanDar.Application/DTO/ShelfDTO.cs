using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Application.DTO
{
    public class ShelfDto
    {
        public int ShelfID { get; set; }

        [Required, StringLength(20)]
        public string ShelfName { get; set; }

        [Required]
        public int NumericNumber { get; set; }

        [Required, StringLength(50)]
        public string CreateUser { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string? UpdateUser { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? UpdateDate { get; set; }
    }
}
