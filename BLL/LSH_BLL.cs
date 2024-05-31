using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using DAL;

namespace BLL
{
    public class LSH_BLL
    {
        //private DBQLSV db;
        private LSH_DAL LSH_DAL;
        public LSH_BLL()
        {
            LSH_DAL = new LSH_DAL();
        }
        public void SetCBBItem(ComboBox cb)
        {
            List<CBBItem> l = new List<CBBItem>();
            foreach (LSH i in LSH_DAL.getLSH())
            {
                l.Add(new CBBItem { Value = i.ID_Lop, Text = i.Name });
            }
            l.Add(new CBBItem { Value = 0, Text = "All" });
            cb.Items.AddRange(l.ToArray());
        }
    }
}
