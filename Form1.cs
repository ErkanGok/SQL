using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÖgrenciListesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ListeKatmanıDal listeKatmanıDal = new ListeKatmanıDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            listload();
        }

        private void listload()
        {
            dgwList.DataSource = listeKatmanıDal.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listeKatmanıDal.Add(new ListeKatmanı
            {
                İsim = textBox1.Text,
                Soyisim = textBox2.Text,
                Bölüm = textBox3.Text,
                Ortalaması = Convert.ToDouble(textBox4.Text)
            });
            
            MessageBox.Show("Öğrenci Eklendi !");
            listload();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgwList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgwList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dgwList.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dgwList.CurrentRow.Cells[2].Value.ToString();
            textBox7.Text = dgwList.CurrentRow.Cells[3].Value.ToString();
            textBox8.Text = dgwList.CurrentRow.Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListeKatmanı listekatmanı = new ListeKatmanı
            {
                Okul_NO = Convert.ToInt32(dgwList.CurrentRow.Cells[0].Value),
                İsim = textBox5.Text,
                Soyisim = textBox6.Text,
                Bölüm = textBox7.Text,
                Ortalaması = Convert.ToDouble(textBox8.Text),
            };
            
            listeKatmanıDal.Update(listekatmanı);
            MessageBox.Show("Güncellendi !");
            listload();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Okul_NO = Convert.ToInt32(dgwList.CurrentRow.Cells[0].Value);
            listeKatmanıDal.Delete(Okul_NO);
            MessageBox.Show("Kayıt Silindi !");
            listload();
            
        }
    }
}
