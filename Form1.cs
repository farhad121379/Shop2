using core.Deta;
using Domon1.ENtityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;




namespace Shop2
{
    public partial class Form1 : Form
    {
        Shop2DB MyDb = new Shop2DB();
        kala selectkala = null;
        public Form1()
        {
            InitializeComponent();
            MyDb = new Shop2DB();
        }

        private void R_c(object sender, EventArgs e)
        {
            if (selectkala == null)
            {
                kala Kala = new kala
                {
                    name = txt_G.Text.Trim(),
                    ghimat = txtGh.Text.Trim(),
                    mojodi = txtmo.Text.Trim(),
                    

                };

                MyDb.Add(Kala);
            }
            else
            {
                selectkala.name = txt_G.Text.Trim();
                selectkala.mojodi = txtmo.Text.Trim();
                selectkala.ghimat = txtGh.Text.Trim();
                MyDb.Update(selectkala);
            }
          
                MyDb.SaveChanges();
                MessageBox.Show("با موفقیت ثبت شد.");
                Showkala();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Showkala();
        }

        private void Showkala()
        {
            dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.DataSource = MyDb.kala.ToList();
            var _grop = MyDb.kala.Select(p=>new { p.ID,p.name,p.mojodi,p.ghimat ,p.grop_Kala1.name_grop});
            dataGridView1.DataSource = _grop.ToList();




        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex == -1)
                return;

            int id = Convert.ToInt32(dataGridView1["Column1", e.RowIndex].Value);

            selectkala = MyDb.kala.Find(id);
            if (selectkala != null)
            {
                txt_G.Text = selectkala.name;
                txtmo.Text = selectkala.mojodi;
                txtGh.Text = selectkala.ghimat;


            }
        }

        private void Remove(object sender, EventArgs e)
        {
            MyDb.Remove(selectkala);
            MyDb.SaveChanges();

           Showkala();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            M();
        }

        private void M()
        {
            string name = "mahtab";
            string famliy = "farhad";
            MessageBox.Show(famliy+" "+name);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //N();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {


            //txt_ID.Text = txt_ID.Text + 1;
            
             dataGridView1.DataSource = MyDb.kala.Where(p => p.ID ==int .Parse(txt_ID.Text)).ToList();//اتصال به پایگاه داده
           
         
        }

        //private string N(string name = "mahtab", string family = "farhad") =>return(string family, string name);

    }
}
