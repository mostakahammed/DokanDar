using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Domain.Common
{
    public abstract class BaseEntity
    {
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
