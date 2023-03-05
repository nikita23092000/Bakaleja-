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

namespace Bakaleja__Курсовой_прект_.View
{
    public partial class ProductForm : Form
    {
        Service service;
        Client client;
        private GroceryDBContext context = new GroceryDBContext();
        private Product product;

        public ProductForm()
        {
        }

        public ProductForm(Product product)
        {
            this.product=product;
        }

        public ProductForm(Service service, Client client)
        {
            InitializeComponent();
            this.service = service;
            this.client = client;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            
            

            context.SaveChanges();
        }
    }
}
