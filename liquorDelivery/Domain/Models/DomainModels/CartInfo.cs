using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.DomainModels
{
    public class CartInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Path { get; set; }
        public int Qty { get; set; }
    }
}
