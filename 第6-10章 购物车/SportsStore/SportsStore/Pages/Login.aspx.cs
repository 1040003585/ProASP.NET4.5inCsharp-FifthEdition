using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using System.Web.Security;

namespace SportsStore.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                String name = Request.Form["name"];
                String password = Request.Form["password"];

                if (name != null && password != null
                    && System.Web.Security.FormsAuthentication.Authenticate(name, password))
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(name, false);
                    Response.Redirect(Request["ReturnUrl"] ?? "/");
                }
                else
                {
                    ModelState.AddModelError("fail", "登录失败，请再试一次");
                }
            }
        }
    }
}