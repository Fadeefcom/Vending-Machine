using DataProvider.Entities;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace VendingMachine.Models
{
    public class AdminItemViewModel
    {
        public bool Loading { get; set; }

        public int Count { get; set; }

        public string Name { get; set; }

        public double Volume { get; set; }

        public double Cost { get; set; }
    }
}
