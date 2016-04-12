using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EssentialTools
{
    public partial class Default : System.Web.UI.Page
    {
        public class FormData
        {
            public String Name { get; set; }
            public String City { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                FormData dataObject = new FormData();

                if (TryUpdateModel(dataObject, 
                    new System.Web.ModelBinding.FormValueProvider(ModelBindingExecutionContext)))
                {
                    if (dataObject.Name == "Bob")
                    {//调用该静态方法，会中断调试器，就像设置断点一样，
                        /*调试状态可改WEB代码，鼠标悬停于变量会显示值，可订挂会显示动态变化*/
                        //部署应用程序之后，调用Debugger.Break()方法交将会失效；
                        //最好在跟踪解决问题之后删除所有与调试器相关的代码。
                        System.Diagnostics.Debugger.Break();
                    }/*     开始执行（不调试）会快许多，
                      * 然后生成解决方案，并重新加载到浏览器。
                      * 重新编译项目应用程序将被IIS Express用于响应浏览器请求，
                      * 并且可以快速、轻松地查看更改的效果。
                      * 甚至不必编译项目即可更改查看WEB窗体和静态内容的效果，
                      * 如遇到问题再切换到调试器的状态进行单步调试
                      * （这是一种更加自然流畅的web窗体应用程序开发的方法）
                      */

                    target.InnerText = String.Format("Name :{0},City :{1}",
                        dataObject.Name, dataObject.City);
                }
                else
                {
                    Response.Write("TryUpdateModel Failed");
                }
            }
            else
            {
                Response.Write("IsPostBack Failed");
            }
        }


    }
}