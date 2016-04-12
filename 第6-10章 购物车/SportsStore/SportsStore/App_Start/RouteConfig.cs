using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Routing;
/*创建路由配置类*/

//namespace SportsStore.App_Start
namespace SportsStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            /*路由定义顺序很重要
             * 还要在项目属性的Web设置启动特定页:list
            /*http://172.17.32.100/list/2    {page}为路由段变量*/

            routes.MapPageRoute(null, "list/{category}/{page}", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "list/{page}", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "", "~/Pages/Listing.aspx");      //http://172.17.32.100/
            routes.MapPageRoute(null, "list", "~/Pages/Listing.aspx");  //http://172.17.32.100/list
            
            /*第一个参数指定路由的名称。
             * 我们不会命名应用程序中的主要路由（因此它们全为null）
             * 但在将用户从应用程序的一个部分重定向到另一人部分时，这样会有所帮助
             *第二个参数是输出的url
             * 如:list/水果/2,
                      如果route没category则/list/1?category=水果
                      都没则:/?category=水果&page=1  
             * 来自String path = RouteTable.Routes.GetVirtualPath(null, null,
                  new RouteValueDictionary() { { "category", CurrentCategory }, { "page", i } }).VirtualPath;
               Response.Write(String.Format("<a href='{0}' {1}>{2}</a>",
                  path, i == CurrentPage ? "class='selected'" : "", i));
             * 供(String)RouteData.Values["category"] ?? Request.QueryString["category"];收取
             *
             *///在Listing.cs路由名cart直接找到下面的物理路径
            routes.MapPageRoute("cart", "cart", "~/Pages/CartView.aspx");

            routes.MapPageRoute("checkout", "checkout", "~/Pages/Checkout.aspx");


            routes.MapPageRoute("admin_products", "admin/products", "~/Pages/Admin/Products.aspx");
            routes.MapPageRoute("admin_orders", "admin/orders", "~/Pages/Admin/Orders.aspx");

        }
    }
}