using System;
using System.IO;

namespace Bank
{
    public class DatabaseManager
    {
        private String[,] CSVData;
        private String path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\", @"CSV\UserData.txt"));

        //Reads the UsersData CSV File, Converts to 2D Array
        public void fileReader()
        {
            //Gets the File Path & Set CSVData's Length
            String[] lines = File.ReadAllLines(path);
            CSVData = new String[lines.Length,2];
            
            for (int i = 0; i < lines.Length; i++)
            {
                //Each Users ID & Balance Split
                String ID = lines[i].Split(",")[0];
                String Balance = lines[i].Split(",")[1];
                
                //Converts Each ID & Balance into a Usable Format
                CSVData[i,0] = ID;
                CSVData[i,1] = Balance;
                
                //[i, 0] = ID | [i, 1] = Balance
                //Console.WriteLine(CSVData[i,0] + CSVData[i,1]);
            }
        }

        public void fileWriter(int accountID, float amountToDeduct)
        {
            //Deduct Amount from User's Current Balance
            for (int i = 0; i < CSVData.Length / 2; i++)
            {
                if (accountID == int.Parse(CSVData[i,0]))
                {
                    CSVData[i,1] = (float.Parse(CSVData[i,1]) - amountToDeduct).ToString();
                    Console.WriteLine("Reminaing Balance: " + CSVData[i,1]);
                }
            }

            //Rewrites the UserData Folder with the New Information
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < CSVData.Length / 2; i++)
            {
                sw.WriteLine(CSVData[i,0] + "," + CSVData[i,1]);
            }
            sw.Close();
        }
        
        public bool checkAccount(int accountID)
        {
            for (int i = 0; i < CSVData.Length / 2; i++)
            {
                if (accountID == int.Parse(CSVData[i,0]))
                {
                    return true;
                }
            }
            return false;
        }
        
        public float getAmount(int accountID)
        {
            try
            {
                return float.Parse(CSVData[accountID,1]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Card ID");
                throw;
            }
        }
        
        public bool setBalance(int accountID, float amountToDeduct)
        {
            if (getAmount(accountID) >= amountToDeduct)
            {
                fileWriter(accountID, amountToDeduct);
                return true;
            }
            return false;
        }
    }
}