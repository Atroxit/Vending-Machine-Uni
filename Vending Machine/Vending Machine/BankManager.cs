using System;

namespace Bank
{
    //Bank Manager is used as a link between the Vending Machine and the Banks Database
    public class BankManager
    {
        //Instantiation of the Database Manager Class
        public DatabaseManager DM = new DatabaseManager();

        //Used to Activate the File Reader upon Vending Machine Start
        public BankManager()
        {
            DM.fileReader();
        }
        
        //Used to Verifiy Card a Given Account ID
        public bool verifiyCard(int accountID)
        {
            return DM.checkAccount(accountID);
        }
        
        //Used to Deduct Money from a Given Account
        public bool processPayment(int accountID, float amountToDeduct)
        {
            return DM.setBalance(accountID, amountToDeduct);
        }
    }
}