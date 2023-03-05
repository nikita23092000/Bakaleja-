using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using MoreLinq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bakaleja__Курсовой_прект_.Model;
using Bakaleja__Курсовой_прект_.Controller;
using Bakaleja__Курсовой_прект_.View;
using Bakaleja__Курсовой_прект_.View.ShopView;

namespace Bakaleja__Курсовой_проект_.View
{
    public partial class MainForm : Form
    {
        private readonly Auth auth;
        

        public MainForm()
        {
            InitializeComponent();
            auth = new Auth(new Encrypt());

            this.Load +=MainForm_Load;
            

            

            

        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await auth.TovaryCheck();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            IUser user = await auth.Login(textBox1.Text, textBox2.Text.ToString());

            if (user is Tovary tovary)
            {
                new TovaryForm().ShowDialog();
            }
            else if(user is Product product)
            {
                new ProductForm (product).ShowDialog();
            }
            else if(user is Shop shop)
            {
                new ShopForm().ShowDialog(); 
            }
        }
    }
}
