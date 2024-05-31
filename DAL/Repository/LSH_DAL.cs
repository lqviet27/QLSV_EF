using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LSH_DAL
    {
        private DBQLSV db;
        public LSH_DAL()
        {
            db = new DBQLSV();
        }
        public List<LSH> getLSH()
        {
            return db.LSHes.Select(p => p).ToList();
        }
    }
}
