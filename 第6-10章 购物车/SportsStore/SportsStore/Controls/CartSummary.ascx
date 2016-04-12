<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartSummary.ascx.cs" Inherits="SportsStore.Controls.CartSummary" %>

<div id="cartSummary">
    <span id="caption">
        <b>您的购物车：</b>
        <span id="csQuantity" runat="server"></span> 件，
        <span id="csTotal" runat="server"></span>
    </span>
    <a id="csLink" runat="server">去结账</a>
</div>