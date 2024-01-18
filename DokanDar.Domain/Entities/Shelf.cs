using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DokanDar.Domain.Common;

namespace DokanDar.Domain.Entities
{
    [Table("Shelf")]
    public class Shelf: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShelfID { get; set; }

        [Required, StringLength(20)]
        public string ShelfName { get; set; }

        [Required]
        public int NumericNumber { get; set; }
    }
}
