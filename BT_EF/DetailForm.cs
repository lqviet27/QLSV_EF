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
    public partial class DetailForm : Form
    {
        private SV_BLL SV_BLL = new SV_BLL();
        private LSH_BLL LSH_BLL = new LSH_BLL();
        MainForm mainForm;
        string mssv;
        
        public DetailForm(MainForm mainForm, string mssv)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.mssv = mssv;
            setCBB();
            displaySV();
        }
        public void setCBB()
        {
            comboBox1.Items.AddRange(mainForm.getCBBItem().ToArray());
        }
        public void displaySV()
        {
            SV s = SV_BLL.findSV(mssv);
            if (s != null)
            {
                textBox1.Text = s.MSSV;
                textBox2.Text = s.Name;
                comboBox1.SelectedIndex = s.ID_Lop - 1;
                dateTimePicker1.Value = s.NS;
                if (s.Gender) radioButton2.Select();
                else radioButton2.Select();
                textBox4.Text = s.DTB + "";
            }
            
        }
        private void bnt_ok_Click(object sender, EventArgs e)
        {
            if (mssv.Equals(""))
            {
                SV s = new SV
                {
                    MSSV = textBox1.Text.ToString().Trim(),
                    Name = textBox2.Text.ToString().Trim(),
                    ID_Lop = Convert.ToInt32(((CBBItem)comboBox1.SelectedItem).Value.ToString()),
                    NS = dateTimePicker1.Value,
                    Gender = radioButton1.Checked ? true : false,
                    DTB = Convert.ToDouble(textBox4.Text.ToString())

            };
                SV_BLL.addSV(s);
            }
            else
            {
                textBox1.ReadOnly = true;
                SV s = SV_BLL.findSV(mssv);
                if(s != null)
                {
                    //s.MSSV = textBox1.Text.ToString().Trim();
                    s.Name = textBox1.Text.ToString().Trim();
                    s.ID_Lop = Convert.ToInt32(((CBBItem)comboBox1.SelectedItem).Value.ToString());
                    s.NS = dateTimePicker1.Value;
                    s.Gender = radioButton1.Checked ? true : false;
                    s.DTB = Convert.ToDouble(textBox4.Text.ToString());
                }
                SV_BLL.editSV(s);
            }
            this.Dispose();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
