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
    public partial class TovaryForm : Form
    {
        private readonly GroceryDBContext _context;
        private readonly DataService data = DataService.Instance;
        public TovaryForm()
        {
            InitializeComponent();
            _context = new GroceryDBContext();
            comboBox1.SelectedIndexChanged +=ComboBox1_SelectedIndexChanged;
            this.Load += AdminForm_Load;
        }

        private async void AdminForm_Load(object sender, EventArgs e)
        {
            (await DataService.Instance.GetAllTovariesAsync()).ToList().ForEach(t=>comboBox1.Items.Add(t));
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTovary = comboBox1.SelectedItem as Tovary;
            listBox1.Items.Clear();
            foreach (Service item in selectedTovary.Services)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tovary = _context.Tovaries.FirstOrDefault(t=>t.Name==comboBox1.Text);
            Service newService = new Service()
            {
                Name = textBox1.Text,
                Price = numericUpDown1.Value
            };
            if (tovary == null)
            {
                Tovary newTovary = new Tovary()
                {
                    Name = comboBox1.Text,
                };
                _context.Services.Add(newService);
                _context.SaveChanges();

                newTovary.Services.Add(newService);
                _context.Tovaries.Add(newTovary);
                _context.SaveChanges();
            }
            else
            {
                tovary.Services.Add(newService);
                _context.SaveChanges();
            }
        }
    }
}
