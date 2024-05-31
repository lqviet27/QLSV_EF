using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SV_DAL
    {
        private DBQLSV db;
        public SV_DAL()
        {
            db = new DBQLSV();
        }

        public void Create(SV sV)
        {
            db.SVs.Add(sV);
            db.SaveChanges();
        }
        public void Update(SV sV)
        {
            var s = db.SVs.Find(sV.MSSV);
            s.Name = sV.Name;
            s.ID_Lop = sV.ID_Lop;
            s.NS = sV.NS;
            s.Gender = sV.Gender;
            s.DTB = sV.DTB;
            db.SaveChanges();
        }
        public List<SV> getAllSV()
        {
            List<SV> svs = new List<SV>();
            var res = db.SVs.Select(p => new { p.MSSV, p.Name, p.ID_Lop, p.NS, p.Gender, p.DTB });
            foreach (var item in res)
            {
                SV s = new SV();
                s.MSSV = item.MSSV;
                s.Name = item.Name;
                s.ID_Lop = item.ID_Lop;
                s.NS = item.NS;
                s.Gender = item.Gender;
                s.DTB = item.DTB;
                svs.Add(s);
            }
            return svs;
        }
        public List<SV> getSVbyCondition(int id_lop, string MSSVorName)
        {
            
            if(id_lop == 0)
            {
                return db.SVs.Where(p => p.MSSV == MSSVorName || p.Name == MSSVorName).ToList();
            }
            if (string.IsNullOrEmpty(MSSVorName))
            {
                return db.SVs.Where(p => p.ID_Lop == id_lop).ToList();
            }
            return db.SVs.Where(p => p.ID_Lop == id_lop && (p.MSSV == MSSVorName || p.Name == MSSVorName)).ToList();
        }

        public  SV findSVbyMSSV(string mssv)
        {
            SV sv = new SV();
            var s = db.SVs.Find(mssv);
            if (s != null)
            {
                sv.MSSV = s.MSSV;
                sv.Name = s.Name;
                sv.ID_Lop = s.ID_Lop;
                sv.NS = s.NS;
                sv.Gender = s.Gender;
                sv.DTB = s.DTB;
                return sv;
            }
            else return null;
            
        }

        public void Delete(string mssv)
        {
            var s = db.SVs.Find(mssv);
            db.SVs.Remove(s);
            db.SaveChanges();
        }
    }
}
