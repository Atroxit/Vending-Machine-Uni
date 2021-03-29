using System;

namespace Bank
{
    public class BankManager
    {
        public DatabaseManager DM = new DatabaseManager();

        public BankManager()
        {
            DM.fileReader();
        }
        
        public bool verifiyCard(int accountID)
        {
            return DM.checkAccount(accountID);
        }
        
        public bool processPayment(int accountID, int amountToDeduct)
        {
            return DM.setBalance(accountID, amountToDeduct);
        }
    }
}