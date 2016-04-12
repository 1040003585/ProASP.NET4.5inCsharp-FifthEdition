<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PartyInvites.Default" %>

<!-- Web窗体文本是一个增强性的HTML文体。<br/>
     特性(Attribute)：带有 < % 和 %> 标签元素,head和form元素中的runat
-->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="~/css/Partystyles.css"/>
</head>
<body>
    <form id="rsvpform" runat="server">
    <!--rsvp(Respondez sil vous plait)：请回复 -->
        <div>
            <h1>New Year's Eve at Jacqui's!</h1>
            <p>We're going to have an excing party, And you're invited!</p>
        </div>
        <asp:ValidationSummary ID="validationSummray" runat="server" ShowModelStateErrors="true"/>
        <!--模型绑定过程与Required验证存在某种可以利用的有用交互-->
        <div><label>Your name :</label><input type="text" id="name" runat="server"/></div>
        <div><label>Your email:</label><input type="email" id="email" runat="server"/></div>
        <div><label>Your phone:</label><input type="number" id="phone" runat="server"/></div>
        <div>
            <label>Will you attent?</label> 
            <select id="willattend" runat="server"> 
                <option value="">Choose an Option</option>
                <option value="true">Yes</option>
                <option value="false">No</option>
            </select>
        </div>
        <div>
            <button type="submit">Submit RSVP</button>   &nbsp;  <a href="Summary.aspx">summary</a>
        </div>
   
        
    </form>
</body>
</html>
<!--
    1、用户请求访问添加到项目中的Web窗体文件的URL；
    2、IIS Express 收到这些请求，并定位请求文件；
    3、IIS Express 处理Web窗体文件，生成标准的HTML页面；
    4、该HTML页面将被返回给浏览器，向用户显示。
 -->
