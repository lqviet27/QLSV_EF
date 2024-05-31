using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SV_BLL
    {
        private SV_DAL SV_DAL = new SV_DAL();

        public void addSV(SV s)
        {
            SV_DAL.Create(s);
        }

        public void deleteSV(string mssv)
        {
            SV_DAL.Delete(mssv);
        }

        public void editSV(SV s)
        {
            SV_DAL.Update(s);
        }

        public SV findSV(string mssv)
        {
            SV s = SV_DAL.findSVbyMSSV(mssv);
            return s;
        }

        public List<SV> searchSV(int id_lop, string nameOrMSSV)
        {
            if(id_lop == 0 && nameOrMSSV.Equals(""))
            {
                return SV_DAL.getAllSV();
            }
            else
            {
                return SV_DAL.getSVbyCondition(id_lop, nameOrMSSV);
            }
        }
    }
}
