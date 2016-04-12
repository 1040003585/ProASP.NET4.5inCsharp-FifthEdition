<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="SportsStore.Pages.Listing"
    MasterPageFile="~/Pages/Store.Master" %>

<%@ Import Namespace="System.Web.Routing" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <!--应用母版页-->
    <!--    1、添加MasterPageFile属性-->
    <!--    2、删除母版页已定义的html元素-->

    <div id="content">
        <%--<%foreach (SportsStore.Models.Product prod in GetProducts())
          {
              Response.Write("<div class='item'>");
              Response.Write(String.Format("<h3>{0}</h3>", prod.Name));
              Response.Write(prod.Description);
              Response.Write(String.Format("<h4>{0:c}</h4>", prod.Price));
              Response.Write(String.Format("<button name='add' type='submit'"
                  + "value='{0}'>添加到购物车</button>", prod.ProductID));
              Response.Write("</div>");
          }
        %>--%>
        <!--使用服务器控件和数据绑定-->
        <asp:Repeater ItemType="SportsStore.Models.Product"
            SelectMethod="GetProducts" runat="server">
            <ItemTemplate>
                <!--Repeater控件用于为数据对象集中的每个项生成一组相同的元素-->
                <!--ItemType特性处理哪种类型的数据对象，SelectMothod在cs获取数据对象
                    ItemType和SelectMethod特性是asp.net4.5新数据绑定功能——强类型数据控件
                -->
                <div class="item">
                    <h3><%#Item.Name %></h3>
                    <%#Item.Description %>
                    <h4><%#Item.Price.ToString("c") %>/斤，剩余：<%#Item.Store.ToString() %>斤</h4>
                    <button name="add" type="submit" value="<%#Item.ProductID %>">
                        添加到购物车
                    </button>
                </div>

            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="pager">
        <%for (int i = 1; i <= MaxPage; i++)
          {
              //Response.Write(String.Format("<a href='/Pages/Listing.aspx?page={0}' {1}>{2}</a>",
              //    i, i == CurrentPage ? "class='selected'" : "", i));

              /*要完全支持路由配置,Import Routing*/
              String path = RouteTable.Routes.GetVirtualPath(null, null,
                  new RouteValueDictionary() { { "category", CurrentCategory }, { "page", i } }).VirtualPath;
              //Response.Write(path);
              /*  ++"自己改正的"/list/水果/1  
                  如果route没category则/list/1?category=水果
                  都没则:/?category=水果&page=1  
              */
              Response.Write(String.Format("<a href='{0}' {1}>{2}</a>",
                  path, i == CurrentPage ? "class='selected'" : "", i));
          } %>
    </div>

</asp:Content>
