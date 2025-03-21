using Library.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.Realisation.Models
{
    public class Operation : IOperation
    {

        public Operation(Guid from, Guid to, Guid categoryId, float amount)
        {
            Id = new Guid();
            From = from;
            To = to;
            CategoryId = categoryId;
            Amount = amount;
            Date = DateTime.Now;
            IsProcessed = false;
        }

        public override string ToString()
        {
            return $"Operation : ID: {Id}, From: {From} -> To: {To}, Amount: {Amount}," +
                $" Category: {CategoryId}, Date: {Date}, Description : {Description}, IsProcessed: {IsProcessed}";
        }
    }
}
