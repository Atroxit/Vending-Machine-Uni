using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using Bank;

namespace Vending_Machine
{
    public partial class VendingMachine : Form
    {
        #region Variables

        //private vars
        private float balance = 0.00f;
        private int cardID = -1;
        private bool cardValidity = false;
        
        //Key = ID, Value = Price / Quanity
        private Dictionary<string, Vector2> drinks = new Dictionary<string, Vector2>();
        private BankManager BM = new BankManager();

        #endregion

        public VendingMachine()
        {
            //inits for winforms
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
        
        #region Event Handles

        /// <summary>
        /// The event handler for the card id dropdown box
        /// After a card id is selected it is sent to the bank to be validated
        /// </summary>
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
        
        /// <summary>
        /// Parses the cash input box and sets var balance to the parsed value
        /// </summary>
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
        
        /// <summary>
        /// The event handler for the buy button
        /// - gets the price of the selected drink
        /// - Input validation
        /// - gets the quantity of the selected drink
        /// - quantity validation
        /// ------- Card -------
        /// - if card is selected apply 10% discount
        /// - send payment to bank
        /// - if payment is successful dispense item
        /// ------- Cash -------
        /// - check if the balance is more than or equal to the item's price
        /// - if the user can afford the item then dispense item
        /// </summary>
        private void BuyButton_Click(object sender, EventArgs e)
        {
            //get price of selected drink
            float price = getPrice(DrinkSelectionInput.Text);
            Console.WriteLine("Item Price: " + price);
            //if price = 0 then it is an invalid input
            if (price == 0)
            {
                MessageBox.Show("You have entered an Invalid ID", "Invalid ID");
                return;
            }
            
            //get quantity of selected drink
            float quantity = getQuantity(DrinkSelectionInput.Text);
            //if quantity = 0 it means the drink is out of stock
            if (quantity <= 0)
            {
                MessageBox.Show("This item is not in stock sorry. \nPlease select another item.", "Item Not In Stock");
                return;
            }
            
            //if card id >= 0 it means card is selected
            if (cardID >= 0)
            {
                //------- Card -------
                
                //card validity check
                if (cardValidity == false)
                {
                    return;
                }
                //Apply Discount
                price *= 0.9f;
                //send payment to bank
                bool payment = this.BM.processPayment(cardID, price);
                //if payment was successful then dispense item
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
                //------- Cash -------
                
                //check the items price against the machine's balance
                if (this.balance >= price)
                {
                    //Deduct price from balance
                    this.balance -= price;
                    //Change label to display the change given
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
        
        #endregion

        #region HelperMethods

        /// <summary>
        /// Resets all variables back to their default values
        /// </summary>
        private void resetMachine()
        {
            this.balance = 0;
            CashInput.Text = "";
            DrinkSelectionInput.Text = "";
            CardIDDropdown.SelectedIndex = -1;
        }
        
        /// <summary>
        /// Returns the price of an item from a given ID
        /// </summary>
        /// <param name="ID">The ID of the requested item</param>
        /// <returns>Returns the price of the item</returns>
        private float getPrice(String ID)
        {
            Vector2 value;
            drinks.TryGetValue(ID, out value);

            return value.X;
        }
        
        /// <summary>
        /// Returns the quantity of a item from a given ID
        /// </summary>
        /// <param name="ID">The ID of the requested item</param>
        /// <returns>Returns the quantity of the item</returns>
        private float getQuantity(String ID)
        {
            Vector2 value;
            drinks.TryGetValue(ID, out value);

            return value.Y;
        }
        
        /// <summary>
        /// Dispenses an item from a given ID
        /// - deducts 1 off of the item's quantity
        /// </summary>
        /// <param name="ID">The ID of the requested item</param>
        /// <returns>Returns the quantity of the item after it has been dispensed</returns>
        private float dispenseItem(String ID)
        {
            Vector2 quantity;
            drinks.TryGetValue(ID, out quantity);

            quantity.Y -= 1;
            
            drinks[ID] = quantity;
            
            return quantity.Y;
        }
        
        #endregion
    }
}
