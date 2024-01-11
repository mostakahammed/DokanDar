using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Domain.Common
{
    public abstract class BaseEntity
    {
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string? UpdateUser { get; set; } = string.Empty;
        public DateTime? UpdateDate { get; set; }
    }
}
