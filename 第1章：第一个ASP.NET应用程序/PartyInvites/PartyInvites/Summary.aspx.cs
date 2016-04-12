using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;

namespace PartyInvites
{
    public partial class Summary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected String GetNoShowHtml()
        {
            StringBuilder html = new StringBuilder();
            var noData = ResponseRepository.GetRespository().GetAllResponses()
                .Where(r => r.WillAttend.HasValue && !r.WillAttend.Value);

            foreach (var rsvp in noData)
            {
                html.Append(String.Format("<tr><th>{0}</th><th>{1}</th><th>{2}</th></tr>",
                rsvp.Name, rsvp.Email, rsvp.Phone));
            }

            return html.ToString();
        }
     
    }
}