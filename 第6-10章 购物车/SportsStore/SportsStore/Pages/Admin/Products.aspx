<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="SportsStore.Pages.Admin.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ListView ItemType="SportsStore.Models.Product" SelectMethod="GetProducts"
        DataKeyNames="ProductID" UpdateMethod="UpdateProduct"
        DeleteMethod="DeleteProduct" InsertMethod="InsertProduct"
        InsertItemPosition="LastItem" EnableViewState="false" runat="server">

        <LayoutTemplate>
            <div class="outerContainer">
                <table id="productsTable">
                    <tr>
                        <th>商品名字</th>
                        <th>描述</th>
                        <th>类别</th>
                        <th>价格</th>
                        <th>储存</th>
                        <th>操作</th>

                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </div>
        </LayoutTemplate>

        <ItemTemplate>
            <tr>
                <td><%#Item.Name %></td>
                <td class="description"><span><%#Item.Description %></span></td>
                <td><%#Item.Category %></td>
                <td><%#Item.Price.ToString() %></td>
                <td><%#Item.Store %></td>
                <td>
                    <asp:Button CommandName="Edit" Text="编辑" runat="server" />
                    <asp:Button CommandName="Delete" Text="删除" runat="server" />
                </td>
            </tr>
        </ItemTemplate>

        <EditItemTemplate>
            <tr>
                <td>
                    <input name="name" value="<%#Item.Name %>" />
                    <input name="ProductID" type="hidden" value="<%#Item.ProductID%>" />
                </td>
                <td>
                    <input name="description" value="<%#Item.Description %>" /></td>
                <td>
                    <input name="category" value="<%#Item.Category %>" /></td>
                <td>
                    <input name="price" value="<%#Item.Price %>" /></td>
                <td>
                    <input name="store" value="<%#Item.Store %>" /></td>
                <td>
                    <asp:Button CommandName="Update" Text="更新" runat="server" />
                    <asp:Button CommandName="Cancel" Text="取消" runat="server" />
                </td>
            </tr>
        </EditItemTemplate>

        <InsertItemTemplate>
            <tr>
                <td>
                    <input name="name" />
                    <input name="ProductID" type="hidden" value="0" />
                </td>
                <td>
                    <input name="description" /></td>
                <td>
                    <input name="category" /></td>
                <td>
                    <input name="price" /></td>
                <td>
                    <input name="store" /></td>

                <td>
                    <asp:Button CommandName="Insert" Text="添加" runat="server" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>

</asp:Content>
