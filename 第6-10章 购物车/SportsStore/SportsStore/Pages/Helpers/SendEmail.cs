using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SportsStore.Models;

namespace SportsStore.Pages.Helpers
{
    public class SendEmail
    {
        static int num = 0;
        public void SendEmailToAdmin(Order yourOrder)
        {

            System.Threading.Thread.Sleep(2000);

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.163.com";//使用163的SMTP服务器发送邮件
            client.UseDefaultCredentials = true;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

            //client.Credentials = new System.Net.NetworkCredential("用户名", "密码");
            client.Credentials = new System.Net.NetworkCredential("15767956729@163.com", "15767956729@");
            //163的SMTP服务器需要用163邮箱的用户名和密码作认证，如果没有需要去163申请个, 

            System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
            //Message.From = new System.Net.Mail.MailAddress("上述用户名密码所对应的邮箱地址");
            //这里需要注意，163似乎有规定发信人的邮箱地址必须是163的，而且发信人的邮箱用户名必须和上面SMTP服务器认证时的用户名相同
            Message.From = new System.Net.Mail.MailAddress("15767956729@163.com");
            //因为上面用的用户名abc作SMTP服务器认证，所以这里发信人的邮箱地址也应该写为abc@163.com

            //Message.To.Add("目标邮箱地址");//将邮件发送给Gmail
            Message.To.Add("1040003585@qq.com");//将邮件发送给QQ邮箱

            Message.Subject = (++num).ToString() + "新订单(" + DateTime.Now.ToString() + ")";
            string body = "<b>姓名：" + yourOrder.Name.ToString() + "</b><br />"
                + "电话：" + yourOrder.Phone.ToString() + "<br />"
                + "邮箱：" + yourOrder.Email.ToString() + "<br />"
                + "<b>地址：" + yourOrder.State.ToString() + yourOrder.City.ToString() + yourOrder.Addrinfo.ToString() + "</b><br />";
            //myOrder.OrderLines = new List<OrderLine>();
            //Cart myCart = SessionHelper.GetCart(session);
            decimal total = 0;
            foreach (OrderLine line in yourOrder.OrderLines)
            {
                body += "商品：" + line.Product.Name.ToString() + "，"
                      + "价格:" + line.Product.Price.ToString() + "元/斤，"
                      + "数量:" + line.Quantity.ToString() + "斤；<br />";
                total += line.Product.Price * line.Quantity;
            }
            body += "<b>客户留言：" + yourOrder.Comments + "</b><br/>";
            body += "<b>总计：" + total.ToString() + " ¥</b><br/>";
            Message.Body = body;

            Message.SubjectEncoding = System.Text.Encoding.UTF8;
            Message.BodyEncoding = System.Text.Encoding.UTF8;
            Message.Priority = System.Net.Mail.MailPriority.High;
            Message.IsBodyHtml = true;

            client.Send(Message);

        }


        public void SendEmailToClient(Order youOrder)
        {

            System.Threading.Thread.Sleep(2000);

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.163.com";//使用163的SMTP服务器发送邮件
            client.UseDefaultCredentials = true;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

            //client.Credentials = new System.Net.NetworkCredential("用户名", "密码");
            client.Credentials = new System.Net.NetworkCredential("15767956729@163.com", "15767956729@");
            //163的SMTP服务器需要用163邮箱的用户名和密码作认证，如果没有需要去163申请个, 

            System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
            //Message.From = new System.Net.Mail.MailAddress("上述用户名密码所对应的邮箱地址");
            //这里需要注意，163似乎有规定发信人的邮箱地址必须是163的，而且发信人的邮箱用户名必须和上面SMTP服务器认证时的用户名相同
            Message.From = new System.Net.Mail.MailAddress("15767956729@163.com");
            //因为上面用的用户名abc作SMTP服务器认证，所以这里发信人的邮箱地址也应该写为abc@163.com

            //Message.To.Add("目标邮箱地址");//将邮件发送给Gmail
            Message.To.Add(youOrder.Email);//将邮件发送给QQ邮箱

            Message.Subject = "您的商品已发货(" + DateTime.Now.ToString() + ")";
            String body = "<h1>惠大在线商城</h1><br />";
            body += "<b>尊敬的"+youOrder.Name+"客户：</b><br />";
            body += "<b>&nbsp;&nbsp;您的购物货品已经发货，今天可以送货上门，<span style='color:red'>货到付款</span>。请注意查收！</b><br/>";
            body += "<b>送货地址：" + youOrder.State + youOrder.City + youOrder.Addrinfo + "</b><br />";
            //Cart myCart = SessionHelper.GetCart(session);
            decimal total = 0;
            foreach (OrderLine line in youOrder.OrderLines)
            {
                body += "商品：" + line.Product.Name.ToString() + "，"
                      + "价格:" + line.Product.Price.ToString() + "元/斤，"
                      + "数量:" + line.Quantity.ToString() + "斤；<br />";
                total += line.Product.Price * line.Quantity;
            }
            body += "<b>客户留言：" + youOrder.Comments + "</b><br/>";
            body += "<b><span style='color:red'>总计：" + total.ToString() + " 元</span></b><br/>";
            body += "<i>谢谢惠顾 惠大在线商城</i><br />";

            Message.Body = body;
            Message.SubjectEncoding = System.Text.Encoding.UTF8;
            Message.BodyEncoding = System.Text.Encoding.UTF8;
            Message.Priority = System.Net.Mail.MailPriority.High;
            Message.IsBodyHtml = true;

            client.Send(Message);

        }

    }
}