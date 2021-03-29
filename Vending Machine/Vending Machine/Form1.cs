using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vending_Machine
{
    public partial class VendingMachine : Form
    {
        public float balance = 0.00f;
        public VendingMachine()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = CardIDDropdown.SelectedIndex;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void CashInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                balance = float.Parse(CashInput.Text);
            }
            catch (Exception)
            {
                Console.WriteLine("Error Parsing Cash Input");
            }
            
        }
    }
}
