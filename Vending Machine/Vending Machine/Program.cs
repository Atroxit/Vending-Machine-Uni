using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bank;

namespace Vending_Machine
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            BankManager BM = new BankManager();
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VendingMachine());
        }
    }
}
