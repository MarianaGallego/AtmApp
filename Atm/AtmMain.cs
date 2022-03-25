using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm
{
    internal class AtmMain
    {
        List<Account> listAccountsAtmMain = new List<Account>();
        int readAccountNumber;
        Boolean validated = false;
        int readAccountKey;
        Account onAccount;

        public AtmMain()
        {
            listAccountsAtmMain = CreateUsersAndAccounts();

            Console.WriteLine("\nIngrese el número de la cuenta sobre la que desea operar:");
            readAccountNumber = int.Parse(Console.ReadLine());

            validated = ValidateAccount();

            if (validated == true)
                ShowMenu();
            else
            {
                Console.WriteLine("NO se validó la cuenta");
            }              
        }

        public AtmMain(List<Account> updatedAccounts)
        {
            listAccountsAtmMain = updatedAccounts;

            Console.WriteLine("\nIngrese el número de la cuenta sobre la que desea operar:");
            readAccountNumber = int.Parse(Console.ReadLine());

            validated = ValidateAccount();

            if (validated == true)
                ShowMenu();
            else
                Console.WriteLine("NO se validó la cuenta");
        }

        public List<Account> CreateUsersAndAccounts()
        {
            User firstUser = new User("Mariana Gallego Rodas", "1017252512", "3007535105");
            User secondUser = new User("Cecilia Rodas Gallego", "43511417", "3126379477");
            User thirdUser = new User("Gabriel Gallego Estrada", "3347412", "3155614781");

            Account firstAccount = new Account(firstUser, 1017252512, 4500000);
            Account secondAccount = new Account(secondUser, 43511417, 5720000);
            Account thirdAccount = new Account(thirdUser, 3347412, 7845000);

            List<Account> listAccounts = new List<Account>();
            listAccounts.Add(firstAccount);
            listAccounts.Add(secondAccount);
            listAccounts.Add(thirdAccount);

            return listAccounts;
        }

        public Boolean ValidateAccount()
        {
            for (int index = 0; index < listAccountsAtmMain.Count; index++)
            {
                if (listAccountsAtmMain[index].accountNumber == readAccountNumber)
                {
                    Console.WriteLine("\nIngrese la clave de la cuenta: ");
                    readAccountKey = int.Parse(Console.ReadLine());

                    if (listAccountsAtmMain[index].accountKey == readAccountKey)
                    {
                        validated = true;
                        onAccount = listAccountsAtmMain[index];
                        //Console.WriteLine("Los datos coinciden");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Clave incorrecta");
                        AtmMain newMenu = new AtmMain(listAccountsAtmMain);
                    }                       
                }
            }
            return validated;
        }

        public void ShowMenu()
        {
            int option;

            Console.WriteLine("\nIngrese el número indice de lo que desea hacer: ");
            Console.WriteLine("\n1. Consignar dinero");
            Console.WriteLine("2. Retirar dinero");
            Console.WriteLine("3. Consultar saldo");
            Console.WriteLine("4. Cambiar contraseña");

            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    //Console.WriteLine("Quiere consignar dinero");
                    onAccount.Deposit(listAccountsAtmMain, onAccount);
                    break;

                case 2:
                    //Console.WriteLine("Quiere retirar dinero");
                    onAccount.Withdrawal(listAccountsAtmMain, onAccount);
                    break;
                case 3:
                    //Console.WriteLine("Quiere consultar saldo");
                    onAccount.CheckBalance(onAccount);
                    break;
                case 4:
                    //Console.WriteLine("Quiere cambiar la clave");
                    onAccount.ChangeAccountKey(listAccountsAtmMain, onAccount);
                    break;
                default:
                    Console.WriteLine("Opción incorrecta");
                    break;
            }

        }

    }
}
