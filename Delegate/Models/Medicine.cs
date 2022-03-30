using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate.Models
{
    internal class Medicine
    {
        private static int _id;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public bool IsDeleted { get; set; } = false;
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
            Console.WriteLine($"Id: {Id} - Name: {Name} - Price: {Price} - Count: {Count} - IsDeleted: {IsDeleted}");
        }
    }
}
