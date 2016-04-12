using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SportsStore.Models;
using SportsStore.Models.Respository;
using SportsStore.Pages.Helpers;
using System.Web.Routing;

namespace SportsStore.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repo = new Repository();
        private int pageSize = 5;//每页只显示5项

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int selectedProductId;
                if (int.TryParse(Request.Form["add"], out selectedProductId))
                {//Listing.aspx 的<button name="add" type="submit" value="<%#Item.ProductID %>">添加到购物车</button>
                    Product selectedProduct = repo.Products
                        .Where(p => p.ProductID == selectedProductId).FirstOrDefault();
                    if (selectedProduct != null)
                    {
                        SessionHelper.GetCart(Session).AddItem(selectedProduct, 1);
                        SessionHelper.Set(Session, SessionKey.RETURN_RUL, Request.RawUrl);
                        /*Response.Redirect是为了便于通过更改路由配置而不是依赖URL的窗体和代码隐藏类来更改映射到CartView.aspx页的URL*/
                        Response.Redirect(RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath);
                        
                        //路由配置类要加cart路由名
                    }
                    else { Response.Write("selectedProductId null"); }//注释
                }
                else { Response.Write("TryParse"); }//注释
            }
            //else { Response.Write("else IsPostBack"); }//注释
        }

        public IEnumerable<Product> GetProducts()
        {//private->public
            //return repo.Products
            return FilterProducts()
                .OrderBy(p => p.ProductID)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }


        private IEnumerable<Product> FilterProducts()
        {
            IEnumerable<Product> products = repo.Products;
            //String currentCategory = (String)RouteData.Values["category"] ??
            //    Request.QueryString["category"];
            return CurrentCategory == null ? products
                : products.Where(p => p.Category == CurrentCategory);
        }

        private int GetPageFromRequest()
        {
            int page = 1;
            String reqValue = (String)RouteData.Values["page"] ??
                Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }
        protected int MaxPage
        {
            get
            {
                //return (int)Math.Ceiling((Decimal)repo.Products.Count() / pageSize);
                int prodCount = FilterProducts().Count();
                return (int)Math.Ceiling((decimal)prodCount / pageSize);
            }
        }

        protected int CurrentPage
        {
            get
            {
                //int page = 1;
                //page = int.TryParse(Request.QueryString["page"], out page) ? page : 1;
                //return page > MaxPage ? MaxPage : page;
                int page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }
        /// <summary>
        /// Protected 可给父类aspx引用
        /// </summary>
        protected String CurrentCategory
        {///////// ++"自己改正的"/list/1
            get
            {
                return (String)RouteData.Values["category"] ?? Request.QueryString["category"];
            }
        }

    }
}