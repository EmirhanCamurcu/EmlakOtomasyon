using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace emlak_site_programı
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       // string yol = ConfigurationManager.ConnectionStrings["veritabani"].ConnectionString.ToString();
       // SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabani"].ConnectionString.ToString());
        SqlConnection baglan = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename='C:\Users\£MİRHAN\Desktop\Yeni klasör1\Yeni klasör\emlak_site_programı\emlak_site_programı\emlak.mdf';Integrated Security=True;User Instance=True");
        private void verilerigöster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * From sitebilgi",baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Zambak Sitesi")
            {
                BtnZambak.BackColor = Color.Yellow;
                BtnGul.BackColor = Color.Gray;
                BtnMenekşe.BackColor = Color.Gray;
                BtnPapatya.BackColor = Color.Gray;
            }
            if (comboBox1.Text == "Papatya Sitesi")
            {
                BtnZambak.BackColor = Color.Gray;
                BtnGul.BackColor = Color.Gray;
                BtnMenekşe.BackColor = Color.Gray;
                BtnPapatya.BackColor = Color.Yellow;
            }
            if (comboBox1.Text == "Gül Sitesi")
            {
                BtnZambak.BackColor = Color.Gray;
                BtnGul.BackColor = Color.Yellow;
                BtnMenekşe.BackColor = Color.Gray;
                BtnPapatya.BackColor = Color.Gray;
            }
            if (comboBox1.Text == "Menekşe Sitesi")
            {
                BtnZambak.BackColor = Color.Gray;
                BtnGul.BackColor = Color.Gray;
                BtnMenekşe.BackColor = Color.Yellow;
                BtnPapatya.BackColor = Color.Gray;
            }

        }

        private void BtnGoruntule_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into sitebilgi(id,site,oda,metre,fiyat,blok,no,adsoyad,telefon,notlar,satkira) values ('"+textBox7.Text.ToString()+"','"+comboBox1.Text.ToString()+"','"+comboBox3.Text.ToString()+"','"+textBox1.Text.ToString()+"','"+textBox2.Text.ToString()+"','"+comboBox4.Text.ToString()+"','"+textBox6.Text.ToString()+"','"+textBox3.Text.ToString()+"','"+textBox4.Text.ToString()+"','"+textBox5.Text.ToString()+"','"+comboBox2.Text.ToString()+"')",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster(); 
        }

        int id = 0;
        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from sitebilgi where id=("+id+")",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster(); 
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox7.Text=listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[0].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[0].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
        }

        private void BtnDuzelt_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update sitebilgi set id ='"+textBox7.Text.ToString()+"',site='"+comboBox1.Text.ToString()+"',oda='"+comboBox3.Text.ToString()+"',metre='"+textBox1.Text.ToString()+"',fiyat='"+textBox2.Text.ToString()+"',blok='"+comboBox4.Text.ToString()+"',no'"+textBox6.Text.ToString()+"',adsoyad='"+textBox3.Text.ToString()+"',telefon='"+textBox4.Text.ToString()+"',notlar='"+textBox5.Text.ToString()+"',satkira='"+comboBox2.Text.ToString()+"' where id ="+id+" ",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster();
        }
    }
}
