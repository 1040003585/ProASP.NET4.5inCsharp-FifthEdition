<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="SportsStore.Pages.CartView"
    MasterPageFile="~/Pages/Store.Master" %>

<asp:Content runat="server"  ContentPlaceHolderID="bodyContent">

    <div id="content">
        <h2>您的购物车</h2>
        <table id="cartTable">
            <thead>
                <tr>
                    <th>数量</th>
                    <th>条目</th>
                    <th>价格</th>
                    <th>小计</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ItemType="SportsStore.Models.CartLine"
                    SelectMethod="GetCartLines" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.Quantity %></td>
                            <td><%# Item.Product.Name %></td>
                            <td><%# Item.Product.Price.ToString("c") %></td>
                            <td><%# (Item.Product.Price*Item.Quantity).ToString("c") %></td>
                            <td>
                                <button type="submit" class="actionButtons" name="remove" 
                                    value="<%#Item.Product.ProductID %>">移除</button>
                            </td>
                        </tr>
                    </ItemTemplate>

                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3">总计：</td><!---跨3列-->
                    <td><%=CartTotal.ToString("c") %></td>
                </tr>
            </tfoot>
        </table>
        <p class="actionButtons">
            <a href="<%=ReturnUrl%>">继续购物</a>
            <a href="<%=CheckoutUrl%>">结账</a>
        </p>
    </div>

</asp:Content>
