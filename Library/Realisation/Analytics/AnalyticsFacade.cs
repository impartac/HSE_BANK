using Library.Abstractions.Analytics;
using Library.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Realisation.Analytics
{
    public class AnalyticsFacade : IAnalyticsFacade
    {
        public AnalyticsFacade() { }
        public IEnumerable<string> Execute<Acc, Cat, Op>(IEnumerable<Acc> accounts, IEnumerable<Cat> categories, IEnumerable<Op> operations)
            where Acc : IBankAccount
            where Cat : ICategory
            where Op : IOperation
        {
            List<string> result = new List<string>();

            float avg_amount = 0;
            float mx_amount = float.MinValue;
            float mn_amount = float.MaxValue;
            foreach (Op op in operations)
            {
                avg_amount += op.Amount;
                mx_amount = Math.Max(mx_amount, op.Amount);
                mn_amount = Math.Min(mn_amount, op.Amount);

            }
            result.Add($"Operation Analysis: avg_amount = {avg_amount / operations.Count()}, count = {operations.Count()}, max_amount = {mx_amount}, min_amount = {mn_amount}");

            float avg_balance = 0;
            float mx_balance = float.MinValue;
            float mn_balance = float.MaxValue;
            foreach (Acc acc in accounts)
            {
                avg_balance += acc.Balance;
                mx_balance = Math.Max(mx_balance, acc.Balance);
                mn_balance = Math.Min(mn_balance, acc.Balance);
            }
            result.Add($"Accounts Analysis: avg_balance = {avg_balance / accounts.Count()}, count = {accounts.Count()}, max_balance = {mx_balance}, min_balance = {mn_balance}");


            foreach (Cat cat in categories)
            {
                result.Add($"Cat: {cat.Name} in {operations.Count(x => x.CategoryId == cat.Id)} operations");
            }
            return result;
        }
    }
}
