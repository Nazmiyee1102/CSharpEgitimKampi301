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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();

        private void btn_listele_Click(object sender, EventArgs e)
        {
            var values = db.TblGuide.ToList();
            dataGridView1.DataSource = values;
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            TblGuide guide = new TblGuide();
            guide.GuideName = txt_ad.Text;
            guide.GuideSurname = txt_soyad.Text;
            db.TblGuide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Eklendi.");
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var removeValue = db.TblGuide.Find(id);
            db.TblGuide.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Silindi.");
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var updateValue = db.TblGuide.Find(id);
            updateValue.GuideName = txt_ad.Text;
            updateValue.GuideSurname = txt_soyad.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Güncellendi.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btn_getir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var values = db.TblGuide.Where(x => x.GuideId == id).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
