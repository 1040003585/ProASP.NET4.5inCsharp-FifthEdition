<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" 
    Inherits="SportsStore.Pages.Checkout"
    MasterPageFile="~/Pages/Store.Master" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <div id="checkoutForm" class="checkout" runat="server">
            <h2>正在结账</h2>
            请输入您的具体信息，我们将可以送货到门，货到付款。

            <div id="errors" data-valmsg-summary="true">
                <!--设置客户端验证-->
                <ul>
                    <li style="display: none"></li>
                </ul>
                <!--设置服务端验证-->
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </div>

            <h3>收件人</h3>
            <div>
                <label for="name">姓名：</label>
                <SX:VInput Property="Name" runat="server" />
                <!--input id="name" name="name"
                     data-val="true" data-val-required="请输入姓名!" />
                <!--客户端这里只设置验证name-->
            </div>

            <h3>地址</h3>

            <div>
                <label for="state">省：</label>
                <SX:VInput Property="State" runat="server" />
            </div>
            <div>
                <label for="city">市：</label>
                <SX:VInput Property="City" runat="server" />

            </div>
            <div>
                <label for="addrinfo">具体地址：</label>
                <SX:VInput Property="Addrinfo" runat="server" />
            </div>
            <div>
                <label for="phone">电话：</label>
                <SX:VInput Property="Phone" runat="server" />
                <!--textarea rows="1" id="phone" name="phone"></!--textarea-->
                <!--input type="number" id="phone3" name="phone3" /-->
            </div>
            <div>
                <label for="email">邮箱：</label>
                <SX:VInput Property="Email" runat="server" />
                <!--textarea rows="1" id="email" name="email"></!--textarea>
                <input type="email" id="email3" name="email3" /-->
            </div>
            <div>
                <label for="comments">留言备注：</label>
                <SX:VInput Property="Comments" runat="server" />
                <!--textarea rows="3" id="comments" name="comments"></!--textarea-->
            </div>

            <h3>选项</h3>
            <input type="checkbox" id="giftwrap" name="giftwrap" value="true" />
            是否需要打包？
             <p class="actionButtons">
                 <button class="actionButtons" type="submit">提交订单</button>
             </p>
        </div>
        <div id="checkoutMessage" runat="server">
            <h2>谢谢</h2>
            谢谢在我们网店的消费，我们将会去进货，货到会有邮箱提示，请注意查收！

        </div>
    </div>
</asp:Content>

