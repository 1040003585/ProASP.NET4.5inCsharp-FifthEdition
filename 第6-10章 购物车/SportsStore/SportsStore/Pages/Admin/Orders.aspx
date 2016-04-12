<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="SportsStore.Pages.Admin.Orders"
     EnableViewState="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="outerContainer">
        <table id="ordersTable">
            <tr>
                <th>姓名</th>
                <th>电话号码</th>
                <th>省份</th>
                <th>城市</th>
                <th>具体地址</th>
                <th>件数</th>
                <th>客户留言</th>
                <th>总计</th>
                <th>状态</th>
            </tr>
            <asp:Repeater SelectMethod="GetOrders" ItemType="SportsStore.Models.Order" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Name %></td><!--加:是已编码(encode)可确保显示的值是安全的-->
                        <td><%#: Item.Phone %></td>
                        <td><%#: Item.State %></td>
                        <td><%#: Item.City %></td>
                        <td><%#: Item.Addrinfo %></td>
                        <td><%# Item.OrderLines.Sum(ol=>ol.Quantity) %></td>
                        <td><%#:Item.Comments %></td>
                        <td><%# Total(Item.OrderLines).ToString("c") %></td>
                        <td>
                            <asp:PlaceHolder Visible="<%#!Item.Dispatched %>" runat="server">
                                <button type="submit" name="dispatch" value="<%#Item.OrderId %>">发货</button>
                            </asp:PlaceHolder>
                        </td>

                    </tr>
                </ItemTemplate>

            </asp:Repeater>
        </table>
    </div>

    <div id="ordersCheck">
        <asp:CheckBox ID="showDispatched" runat="server" Checked="false" AutoPostBack="true" />
        显示已发货的订单？
    </div>
</asp:Content>
