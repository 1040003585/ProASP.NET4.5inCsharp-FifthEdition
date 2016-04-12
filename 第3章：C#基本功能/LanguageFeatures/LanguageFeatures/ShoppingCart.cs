using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections;

namespace LanguageFeatures
{
    /*
     *      使用扩展方法
     * 扩展方法可以向 不为你所有或无法直接修改的类中 添加方法
     *   ——class MyExtensionMethods
     */
    
    //public class ShoppingCart
    //{
    //    public List<Product> Products { get; set; }
    //}

    /*将扩展方法应用于接口*/
    public class ShoppingCart : IEnumerable<Product>
    {
        public List<Product> Products { get; set; }
        public IEnumerator<Product> GetEnumerator(){
            return Products.GetEnumerator();
        }

        //返回接口
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
    }
}