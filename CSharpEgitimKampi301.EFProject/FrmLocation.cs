using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();

        private void btn_listele_Click(object sender, EventArgs e)
        {
            var values = db.TblLocation.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.TblGuide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "GuideId";
            comboBox1.DataSource = values;
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            TblLocation location = new TblLocation();
            location.Capacity = byte.Parse(numericUpDown1.Value.ToString());
            location.City = txt_sehir.Text;
            location.Country = txt_ulke.Text;
            location.Price = decimal.Parse(txt_fiyat.Text);
            location.DayNight = txt_gun.Text;
            location.GuidId = int.Parse(comboBox1.SelectedValue.ToString());
            db.TblLocation.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Başarılı");
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var deletedValue = db.TblLocation.Find(id);
            db.TblLocation.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı");
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var updatedValue = db.TblLocation.Find(id);
            updatedValue.DayNight = txt_gun.Text;
            updatedValue.Price = decimal.Parse(txt_fiyat.Text);
            updatedValue.Capacity = byte.Parse(numericUpDown1.Value.ToString());
            updatedValue.City = txt_sehir.Text;
            updatedValue.Country = txt_ulke.Text;
            updatedValue.GuidId = int.Parse(comboBox1.SelectedValue.ToString().ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
        }
    }
}
