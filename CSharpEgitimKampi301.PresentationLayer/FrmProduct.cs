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
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public FrmProduct()
        {
            _productService = new ProductManager(new EFProductDal());
            _categoryService = new CategoryManager(new EFCategoryDal());
            InitializeComponent();
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetAll();
            dataGridView1.DataSource = values;
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.CategoryId = int.Parse(comboBox1.SelectedValue.ToString());
            product.Price = decimal.Parse(txt_Price.Text);
            product.ProductName = txt_productName.Text;
            product.Description = txt_description.Text;
            product.Stock = int.Parse(txt_Stock.Text);
            _productService.TInsert(product);
            MessageBox.Show("Ekleme İşlemi Yapıldı.");
        }

        private void btn_list2_Click(object sender, EventArgs e)
        {
            var values = _productService.GetProductsWithCategory();
            dataGridView1.DataSource = values;
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var deletedValues = _productService.TGetById(id);
            _productService.TDelete(deletedValues);
            MessageBox.Show("Silme Başarılı");
        }

        private void btn_getir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var value = _productService.TGetById(id);
            dataGridView1.DataSource = new List<object> { value };

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var value = _productService.TGetById(id);
            value.CategoryId = int.Parse(comboBox1.SelectedValue.ToString());
            value.Description = txt_description.Text;
            value.Price = decimal.Parse(txt_Price.Text);
            value.Stock = int.Parse(txt_Stock.Text);
            value.ProductName = txt_productName.Text;
            _productService.TUpdate(value);
            MessageBox.Show("Güncelleme İşlemi Başarılı!");
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values = _categoryService.TGetAll();
            comboBox1.DataSource = values;
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryId";
        }
    }
}
