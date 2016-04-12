using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections.Generic;

namespace LanguageFeatures
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //冗长的属性定义
        protected String GetMessage()
        {
            //create a new Product object
            Product myProduct = new Product();
            //set the property values
            myProduct.Name = "Kayak";
            myProduct.ProductID = 100;
            myProduct.Description = "A boat for one person";
            myProduct.Price = 275M;
            myProduct.Category = "Watersports";

            return String.Format("Product name: {0}", myProduct.Name);
        }


        /*使用对象初始化器的功能*/
        protected String GetMessage_init()
        {
            //create a new Product object and initialized
            Product myProduct = new Product()
            {
                Name = "Kayak",
                ProductID = 100,
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };

            return String.Format("(使用对象初始化功能)Category: {0}", myProduct.Category);
        }

        /*对集合和数组进行初始化*/
        protected String GetMessage_initSetAndArray()
        {
            //构造和初始化泛型集合库中的一个数组和两个类
            string[] stringArray = { "apple", "orange", "plum" };
            List<int> intlist = new List<int> { 10, 20, 30, 40 };
            Dictionary<String, int> myDict = new Dictionary<String, int>{
                {"apple",10},{"orange",20},{"plum",30}
            };

            return String.Format("Fruit: {0}", (object)stringArray[1]);
        }

        /*使用扩展方法*/
        protected String GetMessage_Prices()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>{
                    new Product{Name="Kayak",Price=275M},
                    new Product{Name="Lifejackt",Price=48.95M},
                    new Product{Name="Soccer ball",Price=19.50M},
                    new Product{Name="Corner flag",Price=34.95M}
                }
            };
            /*
             *     代码对ShoppingCart对象(cart)调用了TotalPrices方法
             * （实际是其他类(MyExtensionMethods)定义的扩展方法）,
             * 就好像它是ShoppingCart类的一部分。
             *     扩展类和扩展和方法要在同一命名空间
             */
            decimal cartTotal = cart.TotalPrices();
            return String.Format("(扩展方法)Total: {0:c}", cartTotal);
            //{0:c}，¥378.40（中国）
            //{0:c}，$378.40（美国）
            //{0:c}因位置而异的货币字符串格式
        }

        protected String GetMessage_IEnum()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>{
                    new Product{Name="Kayak",Price=275M},
                    new Product{Name="Lifejackt",Price=48.95M},
                    new Product{Name="Soccer ball",Price=19.50M},
                    new Product{Name="Corner flag",Price=34.95M}
                  }
            };
            Product[] productArray ={
                    new Product{Name="Kayak",Price=275M},
                    new Product{Name="Lifejackt",Price=48.95M},
                    new Product{Name="Soccer ball",Price=19.50M},
                    new Product{Name="Corner flag",Price=34.95M}
                                  };
            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();
            return String.Format("（接口）Cart Total: {0:c}, Array Total: {0:c}",
                cartTotal, arrayTotal);
        }

        /*使用过滤式扩展方法*/
        protected String GetMessage_Filter()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>{
                    new Product{Name="Kayak",Price=275M,Category="Watersports"},
                    new Product{Name="Lifejackt",Price=48.95M,Category="Watersports"},
                    new Product{Name="Soccer ball",Price=19.50M,Category="Soccer"},
                    new Product{Name="Corner flag",Price=34.95M,Category="Soccer"}
                  }
            };
            //TotalPrices扩展方法来计算由FilterByCategory扩展方法返回的Product对象
            //!!!!!!好难理解!!!!!!
            decimal total = products.FilterByCategory("Soccer").TotalPrices();

            return string.Format("(过滤式扩展)Soccer Total: {0:c}", total);

        }

        /*结合使用过滤式扩展方法+Fun<>*/
        protected String GetMessage_FilterFun()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>{
                    new Product{Name="Kayak",Price=275M,Category="Watersports"},
                    new Product{Name="Lifejackt",Price=48.95M,Category="Watersports"},
                    new Product{Name="Soccer ball",Price=19.50M,Category="Soccer"},
                    new Product{Name="Corner flag",Price=34.95M,Category="Soccer"}
                  }
            };
            //!!!!!!好难理解!!!!!!
            Func<Product, bool> categoryFilter = delegate(Product prod)
            {
                return prod.Category == "Soccer";
            };
            decimal total = products.Filter(categoryFilter).TotalPrices();
            return string.Format("(过滤式扩展+Fun)Soccer Total: {0:c}", total);
        }

        /*用lambda表达式替换委托定义*/
        protected String GetMessage_FilterLambda()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>{
                    new Product{Name="Kayak",Price=275M,Category="Watersports"},
                    new Product{Name="Lifejackt",Price=48.95M,Category="Watersports"},
                    new Product{Name="Soccer ball",Price=19.50M,Category="Soccer"},
                    new Product{Name="Corner flag",Price=34.95M,Category="Soccer"}
                  }
            };
            //prod => prod.Category == "Soccer"
            //Func<Product, bool> categoryFilter = prod => prod.Category == "Soccer";

            decimal total = products.Filter(prod => prod.Category == "Soccer").TotalPrices();
            return string.Format("(Lambda 过滤式扩展)Soccer Total: {0:c}", total);
        }
        
        /*扩展lambda表达式的过滤方式*/
        protected String GetMessage_FilterLambdaPlus()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>{
                    new Product{Name="Kayak",Price=275M,Category="Watersports"},
                    new Product{Name="Lifejackt",Price=48.95M,Category="Watersports"},
                    new Product{Name="Soccer ball",Price=19.50M,Category="Soccer"},
                    new Product{Name="Corner flag",Price=34.95M,Category="Soccer"}
                  }
            };
            //prod => prod.Category == "Soccer"
            //Func<Product, bool> categoryFilter = prod => prod.Category == "Soccer";

            decimal total = products.Filter(prod => prod.Category == "Soccer"||prod.Price>20).TotalPrices();
            return string.Format("(扩展Lambda 过滤式扩展)Soccer Total: {0:c}", total);
        }
        /*
         *      其他形式的lambda表达式
         *      
         * 在lambda表达式中不需要表达委托的逻辑，可简单调用一个方法：
         *      prod=>EvaluateProduct(prod)
         * 多个参数的委托使用lambda表达式：
         *      (prod,count)=>prod.Price>20&&count>0
         * 包含多个语句的lambda表达式，用（{}）并以return结束：
         *      (prod,count)=>{
         *          //...mutiple code statements
         *          return result;
         *      }
         */



        /*使用自动类型推断*/
        protected void VariableType()
        {
            var myVariable = new Product { Name = "kayak", Category = "watersports", Price = 275M };
            String name = myVariable.Name;
            
        }

        /*使用匿名类型*/
        protected String AnonType()
        {
            var myAnonType = new
            {//（没Product）
                NameA = "kayak",
                CategoryA = "watersports"
            };//a is new {string NameA,string CategoryA}
            return string.Format("Name: {0}, Type: {1}", 
                myAnonType.NameA, myAnonType.CategoryA);
        }
        /*创建匿名类型对象数组*/
        protected String AnonType_Array()
        {  
            var oddsAndEnds = new[]{
                new{NaneA="blue",CategoryA="color"},
                new{NaneA="Hat",CategoryA="Clothing"},
                new{NaneA="Apple",CategoryA="Fruit"}
            };
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            foreach (var item in oddsAndEnds)
            {
                result.Append(item.NaneA).Append(" ");
            }
            return result.ToString();
            //Blue Hat Apple
        }


        /*使用通用基类*/
        protected string UseBaseClass()
        {
            BaseContainer stringContainer = new BaseContainer();
            stringContainer.Value = "Hello";

            BaseContainer dtContainer = new BaseContainer();
            dtContainer.Value = DateTime.Now;
            if (stringContainer.HasValue && dtContainer.HasValue)
            {//var 后要对相应类型强制转换（不要转错）
                return string.Format("Char:{0},Year:{1}",
                    ((string)stringContainer.Value).ToCharArray().First(),
                    ((DateTime)dtContainer.Value).Year);
            }
            else
            {
                return "No Values";
            }
        }

        /*使用泛型类型*/
        protected string Generic()
        {
            ValueContainer<string> stringContainer = new ValueContainer<string>();
            stringContainer.Value = "hello";
            return string.Format("Char first:{0}", 
                stringContainer.Value.ToArray().First());
        }


        /*使用显式实现的接口*/
        protected String InterfaceFunc()
        {
            TimeProvider provider = new TimeProvider();
            IMonthProvider monthProvider = (IMonthProvider)provider;
            IYearProvider yearProvider = (IYearProvider)provider;

            return String.Format("(接口)Month:{0}, Year{1}",
                monthProvider.GetCurrent(),
                yearProvider.GetCurrent());
        }


        /*执行语言集成查询*/
        //不使用LINQ进行查询(选择最高价格的前3个)
        protected string NonLinq()
        {
            Product[] products ={
                                   new Product{Name="Kayak",Category="Watersports",Price=275M},
                                   new Product{Name="Lifejacket",Category="Watersports",Price=48.95M},
                                   new Product{Name="Soccer ball",Category="Soccer",Price=19.50M},
                                   new Product{Name="Cornet flag",Category="Soccer",Price=34.95M}
                               };
            Product[] foundProducts3 = new Product[3];
            Array.Sort(products,(item1,item2)=>{
                return Comparer<decimal>.Default.Compare(item1.Price, item2.Price);
            });
            Array.Copy(products, foundProducts3, 3);

            System.Text.StringBuilder result = new System.Text.StringBuilder();
            foreach (Product p in foundProducts3)
            {
                result.AppendFormat("Price: {0}", p.Price);
            }
            return result.ToString();
        }
        ////使用LINQ查询语句(选择最高价格的前3个)
        //protected String UseLinq()
        //{
        //    Product[] products ={
        //                           new Product{Name="Kayak",Category="Watersports",Price=275M},
        //                           new Product{Name="Lifejacket",Category="Watersports",Price=48.95M},
        //                           new Product{Name="Soccer ball",Category="Soccer",Price=19.50M},
        //                           new Product{Name="Cornet flag",Category="Soccer",Price=34.95M}
        //                       };
        //    //编译出错
        //    var foundProducts=form match in products
        //                        orderby match.Price descending
        //                        Select match.Price;
        //    int count=0;
        //    System.Text.StringBuilder result=new System.Text.StringBuilder();
        //    foreach(var price in foundProducts){
        //        result.AppendFormat("Price: {0}",price);
        //        if(++count==3){break;}
        //    }
        //    return result.ToString();
        //}
        //使用LINQ点表达法(选择最高价格的前3个)
        protected String UseLinqDot()
        {
            Product[] products ={
                                   new Product{Name="Kayak",Category="Watersports",Price=275M},
                                   new Product{Name="Lifejacket",Category="Watersports",Price=48.95M},
                                   new Product{Name="Soccer ball",Category="Soccer",Price=19.50M},
                                   new Product{Name="Cornet flag",Category="Soccer",Price=34.95M}
                               };
            var foundProducts = products.OrderByDescending(e => e.Price)
                .Take(3)    //foundProducts总共大小为3个
                .Select(e => e.Price);
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            //在枚举结果之前并没有执行查询，所做的更改（把products[2]替换）在输出反映出来
            products[2] = new Product { Name = "Stadium", Price = 27500M };
           
            decimal totalPrice = products.OrderByDescending(e => e.Price)
                .Take(3)
                .Select(e => e.Price)
                .Sum(e => e);
            products[3] = new Product { Name = "TotalPrice", Price = totalPrice };
          
            foreach (var price in foundProducts)
            {
                result.AppendFormat("Price: {0}", price);
            }
            return result.ToString();
        }

    }
}