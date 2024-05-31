using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CreateDB: CreateDatabaseIfNotExists<DBQLSV>
    {
        protected override void Seed(DBQLSV db) //ham seed de add cac doi tuong vao trong doi tuong csdl va tu doi tuong csdl do -> anh xa thanh cac record cua csdl khi bien dich
        {
            db.LSHes.AddRange(new LSH[]
            {
                new LSH{ID_Lop = 1, Name = "22T_Nhat1" },
                new LSH{ID_Lop = 2, Name = "22T_Nhat2" }
            });
            db.SVs.AddRange(new SV[]
            {
                new SV{MSSV = "102220347", Name = "Le Quoc Viet", ID_Lop = 2, NS = new DateTime(2004,05,27), Gender = true, DTB = 10 },
                new SV{MSSV = "102220312", Name = "Tran Trung Duc", ID_Lop = 2, NS = new DateTime(2004,01,12), Gender = true, DTB = 9 },
                new SV{MSSV = "102220331", Name = "Tran Ngoc Minh Hoang", ID_Lop = 1, NS = new DateTime(2004,11,29), Gender = true, DTB = 8 },
                new SV{MSSV = "102220328", Name = "Luu Viet Hoang", ID_Lop = 1, NS = new DateTime(2004,09,15), Gender = true, DTB = 7 },
            });
        }
    }
}
