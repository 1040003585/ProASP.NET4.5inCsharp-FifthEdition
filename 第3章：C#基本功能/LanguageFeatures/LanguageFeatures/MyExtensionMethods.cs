using System;
using System.Linq;
using System.Web;
//泛型
using System.Collections.Generic;

namespace LanguageFeatures
{
    /*
     *      使用扩展方法
     * 扩展方法可以向 不为你所有或无法直接修改的类中 添加方法
     */

    /*定义扩展方法*/
    public static class MyExtensionMethods
    {//扩展方法必须是static的，在static类中中定义
        //public static decimal TotalPrices(this ShoppingCart cartParam)
        //{//this关键字将TotalPrices标注为扩展方法(扩展)
        //    decimal total = 0;
        //    foreach (Product prod in cartParam.Products)
        //    {
        //        total += prod.Price;
        //    }
        //    return total;
        //}
        public static decimal TotalPrices(this IEnumerable<Product> productEnum)
        {
            decimal total = 0;
            foreach (Product prod in productEnum)
            {
                total += prod.Price;
            }
            return total;
        }

        /*创新过滤式扩展方法*/
        public static IEnumerable<Product> FilterByCategory(
            this IEnumerable<Product> productEnum, string categoryParam)
        {
            foreach (Product prod in productEnum)
            {
                if (prod.Category == categoryParam)
                {
                    yield return prod;                    
                }
            }
        }

        /*在扩展方法中使用委托*/
        /*
         * 委托（delegate）可以提高FilterByCategory方法的通用性。
         * 可以针对每个Product调用委托，从而便于以任意方式过滤对象
         */
        public static IEnumerable<Product>Filter(
            this IEnumerable<Product> productEnum, Func<Product, bool> selectorParam)
        {
            foreach (Product prod in productEnum)
            {
                if (selectorParam(prod))
                {
                    yield return prod;
                }
            }
        }
    }
}