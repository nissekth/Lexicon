﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DebuggingDemo
{
    internal class Program
    {
        private static List<Product>? products;

        static void Main(string[] args)
        {
            products = new List<Product>
            {
                new Product("T-shirt", 100m),
                new Product("Mugg", 200m),
                new Product("Keps", 300m)
            };
            var order = new Order("Anna Andersson", products, 0.15m);
            decimal total = order.CalculateTotal();

            Console.WriteLine($"Kund: {order.CustomerName}");
            Console.WriteLine($"Totalt att betala: {total:C}");
        }
    }

    class Product
    {
        public string Name { get; }
        public decimal Price { get; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    class Order
    {
        public string CustomerName { get; }
        public List<Product> Products { get; }
        public decimal Discount { get; }

        public Order(string customerName, List<Product> products, decimal discount)
        {
            CustomerName = customerName;
            Products = products;
            Discount = discount;
        }

        public decimal CalculateSubtotal()
        {
            return Products.Sum(p => p.Price);
        }

        public decimal CalculateTotal()
        {
            var subtotal = CalculateSubtotal();
            var discountAmount = subtotal * Discount;
            var total = subtotal - discountAmount;

            return total;
        }
    }
}
