using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Models
{
    internal class Medicine
    {
        private static int _id;

        public int Id { get; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public bool IsDeleted { get; set; }

        public Medicine()
        {
            _id++;
            Id = _id;
        }

        public void Sell()
        {
            Count--;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id} - Name: {Name} - Count: {Count} - Price: {Price} - IsDeleted: {IsDeleted}");
        }
    }
}
