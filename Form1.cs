using core.Deta;
using Domon1.ENtityes;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Shop2
{
    public partial class Form1 : Form
    {
        Shop2DB Cont = new Shop2DB();
        kala selectkala = null;
        public Form1()
        {
            InitializeComponent();
            Cont = new Shop2DB();
        }

        private void R_c(object sender, EventArgs e)
        {
            if (selectkala == null)
            {
                kala Kala = new kala
                {
                    name = txt_G.Text.Trim(),
                    ghimat = txtGh.Text.Trim(),
                    mojodi = txtmo.Text.Trim()

                };

                Cont.Add(Kala);
            }
            else
            {
                selectkala.name = txt_G.Text.Trim();
                selectkala.mojodi = txtmo.Text.Trim();
                selectkala.ghimat = txtGh.Text.Trim();
                Cont.Update(selectkala);
            }
                Cont.SaveChanges();
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
            dataGridView1.DataSource = Cont.kala.ToList();

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex == -1)
                return;

            int id = Convert.ToInt32(dataGridView1["Column1", e.RowIndex].Value);

            selectkala = Cont.kala.Find(id);
            if (selectkala != null)
            {
                txt_G.Text = selectkala.name;
                txtmo.Text = selectkala.mojodi;
                txtGh.Text = selectkala.ghimat;

            }
        }

        private void Remove(object sender, EventArgs e)
        {
            

            Cont.Remove(selectkala);
            Cont.SaveChanges();

           Showkala();
        }
    }
}
