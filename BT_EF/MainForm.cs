using BLL;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT_EF
{
    public partial class MainForm : Form
    {
        private SV_BLL SV_BLL = new SV_BLL();
        private LSH_BLL LSH_BLL = new LSH_BLL();
        public MainForm()
        {
            InitializeComponent();
            SetCBB();
        }
        public void SetCBB()
        {
            LSH_BLL.SetCBBItem(comboBox1);
        }
        public List<CBBItem> getCBBItem()
        {
            List<CBBItem> l = new List<CBBItem>();
            foreach(CBBItem item in comboBox1.Items)
            {
                l.Add(item);
            }
            return l;
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            int id_lop = Convert.ToInt32(((CBBItem)comboBox1.SelectedItem).Value.ToString());
            string nameOrMSSV = textBox1.Text.Trim();
            dataGridView1.DataSource = SV_BLL.searchSV(id_lop, nameOrMSSV);
            dataGridView1.Columns["LSH"].Visible = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            DetailForm df = new DetailForm(this,"");
            df.ShowDialog();
            btn_search.PerformClick();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            string mssv = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
            DetailForm df = new DetailForm(this, mssv);
            df.ShowDialog();
            btn_search.PerformClick();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                string mssv = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
                SV_BLL.deleteSV(mssv);
            }
            btn_search.PerformClick();
        }
    }
}
