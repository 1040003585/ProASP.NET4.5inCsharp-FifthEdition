using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures
{
    /*
     *      使用自动实现的属性
     * 使用C#属性，能够通过将数据与它的设置和检索方法分离的方式公开类中的一段数据
     */
    public class Product
    {
        /*定义属性*/
        //对数据读写可控，但臃肿、低效、难于阅读代码
        private String name;

        public String Name
        {
            get {
                return ProductID + " " + name;
            }
            set { name = value; }
        }

        /*使用自动属性的实现*/
        public int ProductID { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public String Category { get; set; }
    }


}