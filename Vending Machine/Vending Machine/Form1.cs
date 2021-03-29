using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bank;

namespace Vending_Machine
{
    public partial class VendingMachine : Form
    {
        private float balance = 0.00f;
        private int cardID = -1;
        
        //Key = ID, Value = Price
        Dictionary<string, float> drinks = new Dictionary<string, float>();
        BankManager BM = new BankManager();

        public VendingMachine()
        {
            
            InitializeComponent();

            //First Row
            drinks.Add("A1", 2.00f); //Pipsi
            drinks.Add("A2", 1.70f); //Cola
            drinks.Add("A3", 2.20f); //Diet Pipsi

            //Second Row
            drinks.Add("B1", 1.50f); //Dr. Cola
            drinks.Add("B2", 2.00f); //Diet Cola
            drinks.Add("B3", 1.70f); //Diet Dr. Cola

            //Third Row
            drinks.Add("C1", 3.40f); //Power Thirst
            drinks.Add("C2", 3.00f); //Max Power
            drinks.Add("C3", 3.40f); //Diet Power
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = CardIDDropdown.SelectedIndex;
            Console.WriteLine("card id selected: " + x);
            cardID = x;
        }
        

        private void CashInput_TextChanged(object sender, EventArgs e)
        {
            if(CashInput.Text.Equals("")) return;
            try
            {
                this.balance = float.Parse(CashInput.Text);
            }
            catch (Exception)
            {
                Console.WriteLine("Error Parsing Cash Input");
            }
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            float price = getPrice(DrinkSelectionInput.Text);
            Console.WriteLine("Item Price: " + price);
            if (price == 0)
            {
                MessageBox.Show("You have entered an Invalid ID", "Invalid ID");
                return;
            }

            if (cardID >= 0)
            {
                bool payment = this.BM.processPayment(cardID, price);
                if (payment)
                {
                    resetMachine();
                    MessageBox.Show("Dispensed Item!", "Dispensed Item!");
                }
                else
                {
                    MessageBox.Show("You can't afford this item. Please select another item.", "Insufficient Funds");
                }
            }
            else
            {
                if (this.balance >= price)
                {
                    this.balance -= price;
                    ChangeLabel.Text = "£" + Math.Round(this.balance, 2);
                    MessageBox.Show("Dispensed Item!", "Dispensed Item!");
                    resetMachine();
                }
                else
                {
                    MessageBox.Show("You can't afford this item. Please select another item.", "Insufficient Funds");
                }
            }
            

        }

        private void resetMachine()
        {
            this.balance = 0;
            CashInput.Text = "";
            DrinkSelectionInput.Text = "";
            CardIDDropdown.SelectedIndex = -1;
        }

        private float getPrice(String ID)
        {
            float value;
            drinks.TryGetValue(ID, out value);

            return value;
        }
    }
}
