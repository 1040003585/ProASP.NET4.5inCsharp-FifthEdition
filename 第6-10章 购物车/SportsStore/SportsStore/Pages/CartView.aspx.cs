using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SportsStore.Models;
using SportsStore.Pages.Helpers;
using SportsStore.Models.Respository;

namespace SportsStore.Pages
{
    public partial class CartView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Repository repo = new Repository();
                int productId;
                if (int.TryParse(Request.Form["remove"], out productId))
                {
                    Product productToRemove = repo.Products
                        .Where(p => p.ProductID == productId).FirstOrDefault();
                    if (productToRemove != null)
                    {
                        SessionHelper.GetCart(Session).RemoveLine(productToRemove);
                    }
                }

            }
            /*
             *  还要去CartViem.aspx的Repeater设置EnableViewState="false"
             *      视图状态
             * Web应用程序的状态将包含在一个隐藏的input元素中，并作为响应的一问他发送给浏览器。
             * 视图状态数据用于多个请求之间提供连续性，它与会话状态类似，但由客户端存储，
             * 并作为发送给服务器窗体数据的一部分。(F12的<input type="hidden" ...>)
             */
            /*
                <form method="post" action="cart" id="form1">
                <div class="aspNetHidden">
                <input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="M5IDUMxidoRNtVa4bo63fYf7ahyHwXrCSIZojvSNjN8FOEQhT84ASdJYdv+MfeyDJjCUp0l66Xqs9w7IxgxfdnUPCBk8w756T1TO2gbgmYH+etKLicveWNS1wg3TtN+WGSTJoheT5E01CLDsV9vwaLRS7UBDwmFp0m4WWn2wxV7w2PFxRoKPAIARzJr5fI02TGFknhlNHZPMARV/nugzZViHfnMap++L113z7pNryqHW7xaCbH3TdvzJCzvwTUYDUviLHm3I0sBJV3UUHWVP4g==" />
                </div>
            */
            /*
             * 此数据被添加到发送给浏览器的HTML中，以便Repeater控件缓存显示的购物车数据，
             * 而不是会话状态中的最新Cart对象请求该数据。Cart对象已被正确修改，因为购物车中产品总计已正确更新
             * ——些值未缓存在视图状态中，因为它是Respeater控件以外生成的。
             * 
             */
            /*
             * 如果许多控件都用视图状态，那么添加到每个请求的数据会相当大，会复制HTML已包含的数据，
             * 这样需要更大的带宽才能向用户传送内容。要小心谨慎地用，第32章会继续讨论
             */
        }

        public IEnumerable<CartLine> GetCartLines()
        {
            return SessionHelper.GetCart(Session).Lines;
        }

        public decimal CartTotal
        {
            get
            {
                return SessionHelper.GetCart(Session).ComputeTotalValue();
            }
        }

        public String ReturnUrl
        {
            get
            {
                return SessionHelper.Get<String>(Session, SessionKey.RETURN_RUL);
            }
        }
        public String CheckoutUrl
        {
            get
            {
                return System.Web.Routing.RouteTable.Routes.GetVirtualPath(null, "checkout", null).VirtualPath;
            }
        }

       
    }
}