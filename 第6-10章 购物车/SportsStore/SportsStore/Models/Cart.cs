using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*Cart.cs 有Cart和CartLine两个类*/

namespace SportsStore.Models
{
    
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantiry)
        {
            CartLine line = lineCollection
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantiry
                });
            }
            else
            {
                line.Quantity += quantiry;
            }

        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        public void ClearMyCart()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

    }


    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}