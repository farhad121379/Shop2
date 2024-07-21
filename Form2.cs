using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using core.Deta;
using Domon1.ENtityes;

namespace Shop2
{
    public partial class Form2 : Form
    {
        Shop2DB MyDb = new Shop2DB();
        public Form2()
        {
            InitializeComponent();
            MyDb = new Shop2DB();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Showkala2();
        }
        private void Showkala2()
        {
            dataGridView1.AutoGenerateColumns = false;
           
            var _grop = MyDb.kala.Select(p => new { p.ID, p.name, p.moojoodi, p.ghimat, p.grop_Kala1.name_grop });
            dataGridView1.DataSource = _grop.ToList();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mo =int.Parse(txtmo2.Text.Trim());
            int mo1 = int.Parse(txtmo1_2.Text.Trim());
            string name = txt_name2.Text.Trim();
            var _list = MyDb.kala.Where(p => p.name.Contains(name) &&  p.moojoodi>=mo && p.moojoodi<=mo1);
            dataGridView1.DataSource = _list.ToList();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
