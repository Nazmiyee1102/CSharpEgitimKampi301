using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.PresentationLayer
{
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;

        public FrmCategory()
        {
            _categoryService = new CategoryManager(new EFCategoryDal());
            InitializeComponent();
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txt_categoryName.Text;
            category.Status = true;
            _categoryService.TInsert(category);
            MessageBox.Show("Ekleme Başarılı!");

            
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var deletedValues = _categoryService.TGetById(id);
            _categoryService.TDelete(deletedValues);
            MessageBox.Show("Silme Başarılı!");
        }

        private void btn_getir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var values = _categoryService.TGetById(id);
            dataGridView1 .DataSource = new List<object> { values };
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            int updatedId = int.Parse(txt_id.Text);
            var updatedValue = _categoryService.TGetById(updatedId);
            updatedValue.CategoryName = txt_categoryName.Text;
            updatedValue.Status = true;
            _categoryService.TUpdate(updatedValue);
        }
    }
}
