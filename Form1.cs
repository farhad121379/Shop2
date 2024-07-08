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
using Microsoft.EntityFrameworkCore;

namespace Shop2
{
    public partial class Form1 : Form
    {
        Shop2DB Cont = new Shop2DB();
        public Form1()
        {
            InitializeComponent();
            Cont = new Shop2DB();
        }

        private void R_c(object sender, EventArgs e)
        {
            kala kala = new kala {
             name =txt_G.Text.Trim()

             };

            Cont.Add(kala);
            Cont.SaveChanges();
            MessageBox.Show("با موفقیت ثبت شد.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Showkala();
        }

        private void Showkala()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Cont.kala.ToList();
        }
    }
}
