﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace WebBanHangOnline.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; }
        public ShoppingCart()
        {
            this.Items = new List<ShoppingCartItem>();
        }

        public void AddToCart(ShoppingCartItem item, string color, string size, int Quantity)
        {
            var checkExits = Items.FirstOrDefault(x => x.ProductId == item.ProductId && x.Color == item.Color && x.Size == item.Size);
            if (checkExits != null)
            {
                checkExits.Quantity += Quantity; //nếu checkExits tồn tại thì thay đổi giá trị của Quantity bằng Quantity thay đổi
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
            else
            {
                item.Quantity = Quantity;
                item.TotalPrice = item.Price * item.Quantity;
                Items.Add(item);
            }
        }

        public void Remove(int id, string color, string size)
        {
            var checkExits = Items.SingleOrDefault(x => x.ProductId == id && x.Color == color && x.Size == size);
            if (checkExits != null)
            {
                Items.Remove(checkExits);
            }
        }

        public void UpdateQuantity(int id, string color, string size, int quantity)
        {
            var checkExits = Items.SingleOrDefault(x => x.ProductId == id && x.Color == color && x.Size == size);
            if (checkExits != null)
            {
                checkExits.Quantity = quantity; // Gán giá trị mới cho số lượng
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
        }

        public decimal GetTotalPrice()
        {
            return Items.Sum(x => x.TotalPrice);
        }

        public decimal GetTotalQuantity()
        {
            return Items.Sum(x => x.Quantity);
        }

        public void ClearCart()
        {
            Items.Clear();
        }

    }

    public class ShoppingCartItem
    {
        public int ProductId { get; set; }
        public string Alias { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}