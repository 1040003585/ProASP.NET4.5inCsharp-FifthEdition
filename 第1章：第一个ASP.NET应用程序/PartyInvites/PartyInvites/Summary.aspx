<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="PartyInvites.Summary" %>

<%@ Import Namespace="PartyInvites" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="PartyStyles.css" />
</head>
<body>
    <h2>RSVP Summary</h2>

    <h3>People Who Will Attend</h3>
    <table>
        <caption>People Who Will Attend</caption>
        <thead>
            <tr>
                <th>Name</th>
                <th>Email</th>
                <th>Phone</th>
            </tr>
        </thead>
        <tbody>
            <!-- 服务器脚本分隔符 or 代码片段code nugget-->
            <% 
                var yesData = ResponseRepository.GetRespository().GetAllResponses()
                   .Where(r => r.WillAttend.HasValue && r.WillAttend.Value);
                foreach (var rsvp in yesData)
                {
                    String htmlString =
                        String.Format("<tr><th>{0}</th><th>{1}</th><th>{2}</th></tr>",
                        rsvp.Name, rsvp.Email, rsvp.Phone);
                    Response.Write(htmlString);
                }              
            %>
        </tbody>
    </table>

    <h3>People Who Will Not Attend</h3>
    <table>
        <thead>
            <tr>
                <th>Name</th>
                <th>Email</th>
                <th>Phone</th>
            </tr>
        </thead>
        <tbody>
            <!-- 服务器脚本分隔符 or 代码片段code nugget-->
            <% =GetNoShowHtml()  %>
        </tbody>
    </table>

</body>
</html>
