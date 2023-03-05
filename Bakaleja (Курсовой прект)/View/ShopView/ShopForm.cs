using Bakaleja__Курсовой_прект_.Controller;
using Bakaleja__Курсовой_прект_.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakaleja__Курсовой_прект_.View.ShopView
{
    public partial class ShopForm : Form
    {
        private readonly ShopService _shopService = ShopService.Instance;
        public ShopForm()
        {
            InitializeComponent();
            this.Load += ShopForm_Load;
            listBox1.SelectedIndexChanged +=ListBox1_SelectedIndexChanged;
            listBox5.SelectedIndexChanged += ListBox5_SelectedIndexChanged;
            listBox6.SelectedIndexChanged +=ListBox6_SelectedIndexChanged;
        }

        private void ListBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)listBox6.SelectedItem;
            if (selectedProduct==null) return;

            UpdateClientsList(selectedProduct, listBox6);
        }
        private void UpdateClientsList(Product product, ListBox listBox)
        {
            listBox.Items.Clear();
            product.Clients.ToList().ForEach(c=>listBox.Items.Add(c));
        }

        private void ListBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)listBox5.SelectedItem;
            if(selectedProduct == null) return;

            UpdateClientsList(selectedProduct, listBox5);
        }

        private async void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var shops = await _shopService.GetTodayShopIsActive(listBox1.SelectedItem as Product);
            listBox2.Items.Clear();
            foreach (var item in shops)
            {
                listBox2.Items.Add(item);
            }

            var shopsDone = await _shopService.GetTodayShopIsDone(listBox1.SelectedItem as Product);
            listBox3.Items.Clear();
            foreach (var item in shopsDone)
            {
                listBox3.Items.Add(item);
            }
        }

        private async void ShopForm_Load(object sender, EventArgs e)
        {
            List<Product> products = await _shopService.GetAllProducts();
            foreach (var product in products)
            {
                listBox1.Items.Add(product);
            }
            products.ForEach(p=>listBox4.Items.Add(p));
            products.ForEach(p=>listBox6.Items.Add(p));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Product selectedProductForm = (Product)listBox6.SelectedItem;
            Product selectedProductTo = (Product)listBox5.SelectedItem;
            Client selectedClient = (Client)listBox7.SelectedItem;
            if (selectedProductForm == null || selectedProductTo == null || selectedClient == null) return;

            await _shopService.TransferClientToProduct(selectedProductTo.Id, selectedProductForm.Id, selectedClient);
           
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Product selectedProductForm = (Product)listBox4.SelectedItem;
            Product selectedProductTo = (Product)listBox5.SelectedItem;
            Client selectedClient = (Client)listBox6.SelectedItem;
            if(selectedProductForm == null || selectedProductTo == null || selectedClient==null) return;

            await _shopService.TransferClientToProduct(selectedProductTo.Id, selectedProductForm.Id, selectedClient);
        }
    }
}
