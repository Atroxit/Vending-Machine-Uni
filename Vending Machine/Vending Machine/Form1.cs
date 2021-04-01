using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
        private bool cardValidity = false;
        
        //Key = ID, Value = Price / Quanity
        Dictionary<string, Vector2> drinks = new Dictionary<string, Vector2>();
        BankManager BM = new BankManager();

        public VendingMachine()
        {
            
            InitializeComponent();

            //First Row
            drinks.Add("A1", new Vector2(2.0f, 10)); //Pipsi
            drinks.Add("A2", new Vector2(1.70f, 10)); //Cola
            drinks.Add("A3", new Vector2(2.20f, 0)); //Diet Pipsi / Out of stock

            //Second Row
            drinks.Add("B1", new Vector2(1.50f, 10)); //Dr. Cola
            drinks.Add("B2", new Vector2(2.00f, 10)); //Diet Cola
            drinks.Add("B3", new Vector2(1.70f, 10)); //Diet Dr. Cola

            //Third Row
            drinks.Add("C1", new Vector2(3.40f, 10)); //Power Thirst
            drinks.Add("C2", new Vector2(3.00f, 10)); //Max Power
            drinks.Add("C3", new Vector2(3.40f, 10)); //Diet Power
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = CardIDDropdown.SelectedIndex;
            Console.WriteLine("card id selected: " + x);
            cardID = x;
            if (cardID != -1)
            {
                cardValidity = BM.verifiyCard(x);
            }
            else
            {
                return;
            }
            
            if (cardValidity)
            {
                MessageBox.Show("The card you have entered is valid", "Valid Card ID");
            }
            else
            {
                MessageBox.Show("You have entered an Invalid Card ID", "Invalid Card ID");
            }
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
            
            float quantity = getQuantity(DrinkSelectionInput.Text);
            if (quantity <= 0)
            {
                MessageBox.Show("This item is not in stock sorry. \nPlease select another item.", "Item Not In Stock");
                return;
            }
            
            if (cardID >= 0)
            {
                if (cardValidity == false)
                {
                    return;
                }
                //Apply Discount
                price *= 0.9f;
                bool payment = this.BM.processPayment(cardID, price);
                if (payment)
                {
                    MessageBox.Show("Dispensed Item! \nRemaining Quantity: " + dispenseItem(DrinkSelectionInput.Text) + "\nFrom Card ID: " + (cardID + 1), "Dispensed Item!");
                    resetMachine();
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
                    MessageBox.Show("Dispensed Item! \nRemaining Quantity: " + dispenseItem(DrinkSelectionInput.Text) , "Dispensed Item!");
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
            Vector2 value;
            drinks.TryGetValue(ID, out value);

            return value.X;
        }
        
        private float getQuantity(String ID)
        {
            Vector2 value;
            drinks.TryGetValue(ID, out value);

            return value.Y;
        }
        
        private float dispenseItem(String ID)
        {
            Vector2 quantity;
            drinks.TryGetValue(ID, out quantity);

            quantity.Y -= 1;
            
            drinks[ID] = quantity;
            
            return quantity.Y;
        }
    }
}
