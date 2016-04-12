<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="SportsStore.Controls.CategoryList" %>
        
<!--Web用户控件-->
<!--还要将用户控件应用于Store.Master-->


<%=CreateHomeLinkHtml()%>
        
<% foreach (String cat in GetCategories())
   {
        Response.Write(CreateLinkHtml(cat));
   }
%>