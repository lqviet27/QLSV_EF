using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("SinhVien")]
    public class SV
    {
        [Key] 
        [Required]
        public string MSSV { get; set; }
        [Column("NameSV")]
        public string Name { get; set; }
        public int ID_Lop { get; set; }
        public DateTime NS { get; set; }
        public bool Gender { get; set; } //true :nam, flase: nu
        public double DTB { get; set; }

        [ForeignKey("ID_Lop")] 
        public virtual LSH LSH { get; set; }

    }
}
