using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm
{
    internal class Account
    {
        //FALTA! Aplicar herencia con los tipos de cuenta

        User accountHolder;
        public int accountNumber { get; set; }
        public int accountKey { get; set; }
        public double balance { get; set; }

        List<Account> listAccounts = new List<Account>();

        public Account(User readAccountHolder, int readAccountNumber, double readBalance)
        {
            this.accountHolder = readAccountHolder;
            this.accountNumber = readAccountNumber;
            this.accountKey = 0000;
            this.balance = readBalance;
        }

        public void Deposit(List<Account> list, Account toAccount)
        {
            double depositAmount;

            Console.WriteLine("\nDigite el monto que desea consignar:");
            depositAmount = double.Parse(Console.ReadLine());

            Console.WriteLine($"\nEl saldo anterior era: {toAccount.balance}");
            toAccount.balance = balance + depositAmount;

            for (int index = 0; index < list.Count; index++)
            {
                if (list[index].accountNumber == toAccount.accountNumber)
                {                 
                    list[index].balance = toAccount.balance;
                }
            }

            Console.WriteLine($"El saldo actual es: {toAccount.balance}");
            this.listAccounts = list;

            AtmMain newMenu = new AtmMain(listAccounts);
        }

        public void Withdrawal(List<Account> list, Account toAccount)
        {
            //FALTA! Validar retiro

            double withdrawalAmount;

            Console.WriteLine("\nDigite el monto que desea retirar:");
            withdrawalAmount = double.Parse(Console.ReadLine());

            Console.WriteLine($"\nEl saldo anterior era: {toAccount.balance}");
            toAccount.balance = balance - withdrawalAmount;

            for (int index = 0; index < list.Count; index++)
            {
                if (list[index].accountNumber == toAccount.accountNumber)
                {
                    list[index].balance = toAccount.balance;
                }
            }

            Console.WriteLine($"El saldo actual es: {toAccount.balance}");
            this.listAccounts = list;

            AtmMain newMenu = new AtmMain(listAccounts);
        }

        public void CheckBalance(Account toAccount)
        {
            Console.WriteLine($"\nEl saldo de la cuenta de {toAccount.accountHolder.name} es de {toAccount.balance}");
            AtmMain newMenu = new AtmMain();
        }

        public void ChangeAccountKey(List<Account> list, Account toAccount)
        {

            int newAccountKey;

            Console.WriteLine("\nIngrese la nueva clave");
            newAccountKey = int.Parse(Console.ReadLine());

            toAccount.accountKey = newAccountKey;

            for (int index = 0; index < list.Count; index++)
            {
                if (list[index].accountNumber == toAccount.accountNumber)
                {
                    list[index].accountKey = toAccount.accountKey;
                }
            }

            this.listAccounts = list;
            Console.WriteLine("La clave ha sido actualizada de forma exitosa!");

            AtmMain newMenu = new AtmMain(listAccounts);
        }
    }
}
