using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SportsStore.Controls
{
    public class VInput2:WebControl
    {
        private String nspace = "SportsStore.Models";
        private String model = "Order";

        public String Model
        {
            get { return model; }
            set { model = value; }
        }
        public String Namespace
        {
            get { return nspace; }
            set { nspace = value; }
        }

        public String Property { get; set; }

        protected override void RenderContents(HtmlTextWriter output)
        {
            //base.RenderContents(output);
            output.AddAttribute(HtmlTextWriterAttribute.Id, Property.ToLower());
            output.AddAttribute(HtmlTextWriterAttribute.Name, Property.ToLower());

            Type modelType = Type.GetType(String.Format("{0}.{1}", Namespace, Model));
            PropertyInfo propInfo = modelType.GetProperty(Property);
            var attr = propInfo.GetCustomAttribute<RequiredAttribute>(false);
            if (attr != null)
            {
                output.AddAttribute("data-val", "true");
                output.AddAttribute("data-val-required", attr.ErrorMessage);

            }
            output.RenderBeginTag("input");
            output.RenderEndTag();
           
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            //base.RenderBeginTag(writer);
        }
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            //base.RenderEndTag(writer);
        }
    }
}