using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace SportsStore.Models.Respository
{
    /*存储类*/
    /*
     * 对EFDbContext类执行操作，并作为应用程序业务逻辑与数据库之间的“桥梁”
     */
    public class Repository
    {
        private EFDbContext context = new EFDbContext();
        
        /// <summary>
        /// IEnumerable<Product> Products
        /// </summary>
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public void SaveProdutct(Product product)
        {
            if (product.ProductID == 0)
            {
                product = context.Products.Add(product);
            }
            else
            {
                Product dbProduct = context.Products.Find(product.ProductID);
                if (dbProduct != null)
                {
                    dbProduct.Name = product.Name;
                    dbProduct.Description = product.Description;
                    dbProduct.Price = product.Price;
                    dbProduct.Category = product.Category;

                    dbProduct.Store = product.Store;
                }
            }
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            IEnumerable<Order> orders = context.Orders
                .Include(o => o.OrderLines
                    .Select(ol => ol.Product))
                .Where(o => o.OrderLines
                    .Count(ol => ol.Product.ProductID == product.ProductID) > 0).ToArray();
            foreach (Order order in orders)
            {
                context.Orders.Remove(order);
            }
            context.Products.Remove(product);
            context.SaveChanges();
        }






        /// <summary>
        /// Orders属性对表进行枚举
        /// </summary>
        public IEnumerable<Order> Orders
        {
            get
            {/// IEnumerable<Order> Orders
                return context.Orders
                    .Include(o => o.OrderLines.Select(ol => ol.Product));
            }
        }
        /// <summary>
        /// 存储或修改Order对象
        /// </summary>
        /// <param name="order"></param>
        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {//储——新对象的属性OrderId为0
                order = context.Orders.Add(order);

                foreach (OrderLine line in order.OrderLines)
                {
                    context.Entry(line.Product).State 
                        = System.Data.EntityState.Modified;
                }
            }
            else
            {//改
                Order dbOrder = context.Orders.Find(order.OrderId);
                if (dbOrder != null)
                {
                    dbOrder.Name = order.Name;
                    dbOrder.Phone = order.Phone;
                    dbOrder.Email = order.Email;
                    dbOrder.Comments = order.Comments;
                    dbOrder.Addrinfo = order.Addrinfo;
                    dbOrder.City = order.City;
                    dbOrder.State = order.State;
                    dbOrder.GiftWrap = order.GiftWrap;
                    dbOrder.Dispatched = order.Dispatched;

                    dbOrder.State = order.State;
                }
            }
            context.SaveChanges();

        }
    }
}