using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Routing;
using SportsStore.Models.Respository;

namespace SportsStore.Controls
{
    public partial class CategoryList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 生成不包含类别的URL，便于向用户提供未过滤的产品列表
        /// </summary>
        /// <returns>未过滤的产品列表</returns>
        protected String CreateHomeLinkHtml()
        {
            String path = RouteTable.Routes.GetVirtualPath(null, null).VirtualPath;
            //Response.Write(path);//    /
            return String.Format("<a href='{0}'>Home</a>", path);
            
        }
        

        /// <summary>
        /// 用LINQ生成按字母顺序排列并且无重复的类别列表 
        /// </summary>
        /// <returns>按字母顺序排列并且无重复的类别列表</returns>
        protected IEnumerable<String> GetCategories()
        {//
            return new Repository().Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(x => x);
        }
        /// <summary>
        /// 使用路由系统生成包含类别组件的URL
        /// </summary>
        /// <param name="category">分类类别</param>
        /// <returns>类别过滤的产品列表</returns>
        protected String CreateLinkHtml(String category)
        {
            String seletedCategory = (String)Page.RouteData.Values["category"]
                ?? Request.QueryString["category"];

            String path = RouteTable.Routes.GetVirtualPath(null, null,
                new RouteValueDictionary() { { "category", category }, { "page", "1" } })
                .VirtualPath;
            //Response.Write(path);  /*  /list/蔬菜/1   */
            return String.Format("<a href='{0}' {1}>{2}</a>", path
                , category == seletedCategory ? "class='selected'" : "", category);
        }
    }
}