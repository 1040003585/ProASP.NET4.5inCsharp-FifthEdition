using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.ModelBinding;

namespace PartyInvites
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {//IsPostBack属性，确定响应请求是否发回到服务器的窗体
                GuestResponse rsvp = new GuestResponse();
                if (TryUpdateModel(rsvp, new FormValueProvider(ModelBindingExecutionContext)))
                {//TryUpdateModel为数据绑定（model binding）
                    ResponseRepository.GetRespository().AddResponses(rsvp);
                    if (rsvp.WillAttend.HasValue && rsvp.WillAttend.Value)
                    {//<!--runat="server" 别缺少-->
                        Response.Redirect("seeyouthere.html");
                    }
                    else
                    {
                        if (!rsvp.WillAttend.HasValue) Response.Write("Null");
                        else Response.Redirect("sorryyoucantcome.html");
                    }
                }
                else
                {//最后要注释
                    Response.Write("TryUpdateModel failed");
                }
            }
            else
            {//最后要注释
                Response.Write("IsPostBack failed");
            }
        }

       

        


    }
}