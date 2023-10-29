using DokanDar.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Key]
        public int CategoryID           { get; set; }

        [Required, StringLength(20)]
        public string CategoryName      { get; set; }

        [Required, StringLength(50)]
        public string? Description      { get; set; }
    }
}
