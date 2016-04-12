using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using System.Web.Routing;
using System.Web.Optimization;

namespace SportsStore
{
    /*      全局应用程序类
     * 该类用于在应用程序生命周期中响应各种事件，
     * 并常用于执行一次性设置任务。
     */
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //静态的Routes属性会提供执行配置所需的RouteCollection对象
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            //注册捆绑包，还需要在Store.Master添加脚本捆绑包
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }





        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}