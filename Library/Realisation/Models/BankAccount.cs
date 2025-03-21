using Library.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library.Realisation.Models
{
    [Serializable]
    public class BankAccount : IBankAccount
    {

        // Конструкторы
        public BankAccount(string name)
        {
            Name = name;
            Balance = 0;
            Id = Guid.NewGuid();
        }

        public BankAccount(string name, float balance, Guid id)
        {
            Name = name;
            Balance = balance;
            Id = id;
        }

        public BankAccount() { }

        public override string ToString()
        {
            return $"Bank : Id: {Id}, Name: {Name}, Balance: {Balance}";
        }
    }
}
