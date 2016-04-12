<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SportsStore.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ValidationSummary runat="server" DisplayMode="SingleParagraph" CssClass="error" />

    <div class="loginContainer">
         <div>
             <label for="name">姓名：</label>
             <input name="name" />
         </div>
         <div>
             <label for="password">密码：</label>
             <input type="password" name="password" />
         </div>
        <button type="submit">登录</button>
    </div>

</asp:Content>
