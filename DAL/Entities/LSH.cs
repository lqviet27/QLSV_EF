using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Lop")]
    public class LSH
    {
        public LSH()
        {
            this.SVs = new HashSet<SV>();
        }
        [Key]
        [Required] // not null...
        public int ID_Lop { get; set; }
        [Column("NameLop")]
        public string Name { get; set; }
        public virtual ICollection<SV> SVs { get; set; }
    }
}
