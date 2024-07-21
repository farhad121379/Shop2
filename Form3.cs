using core.Deta;
using Domon1.ENtityes;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Shop2
{
    public partial class Form3 : Form
    {
        Shop2DB MyDb = new Shop2DB();
        kala selectkala = null;
        Gropkala sel_G_K = null;
        public Form3()
        {
            InitializeComponent();
            MyDb = new Shop2DB();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Showkala2();
        }
        private void Showkala2()
        {
            dataGridView1.AutoGenerateColumns = false;

            var _grop = MyDb.kala.Select(p => new { p.ID, p.name, p.moojoodi, p.ghimat, p.grop_Kala1.name_grop });
            dataGridView1.DataSource = _grop.ToList();

        }

        private void Form3_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1)
                return;

            int id = Convert.ToInt32(dataGridView1["Column1", e.RowIndex].Value);

            selectkala = MyDb.kala.Find(id);
            sel_G_K = MyDb.Gropkala.Find(id);
            if (selectkala != null && sel_G_K != null)
            {
                txt_name3.Text = selectkala.name;
                txtmo3.Text = selectkala.mojodi;
                txtGh3.Text = selectkala.ghimat;
                txt_g_n3.Text = sel_G_K.name_grop;


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Gropkala gropkala = new Gropkala();
            gropkala.name_grop = txt_g_n3.Text.Trim();
            if (selectkala == null && sel_G_K == null)
            {
                kala Kala = new kala

                {
                    name = txt_name3.Text.Trim(),
                    ghimat = txtGh3.Text.Trim(),
                    mojodi = txtmo3.Text.Trim(),



                };

                MyDb.Add(Kala);
            }
            else
            {
                selectkala.name = txt_name3.Text.Trim();
                selectkala.mojodi = txtGh3.Text.Trim();
                selectkala.ghimat = txtmo3.Text.Trim();
                sel_G_K.name_grop = txt_g_n3.Text.Trim();
                MyDb.Update(selectkala);
            }

            MyDb.SaveChanges();
            MessageBox.Show("با موفقیت ثبت شد.");
            Showkala2();
        }
    }
}
