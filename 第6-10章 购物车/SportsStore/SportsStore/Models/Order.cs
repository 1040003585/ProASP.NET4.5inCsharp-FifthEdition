using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

/* Order 和 OrderLine 类 */
namespace SportsStore.Models
{
    public class Order
    {
        /*
         *      服务器端验证，可防止恶意用户在数据库中插入无用的数据。
         * 如果服务器处于忙碌状态或可用带宽有限，该延迟可能长达娄秒钟
         * 为了解决这一问题，可以用客户端js验证，但不会取代服务器端验证。
         * 
         */
        public int OrderId { get; set; }

        [Required(ErrorMessage="请输入姓名，以便确认")]
        public String Name { get; set; }

        [Required(ErrorMessage = "请输入电话号码，以便联系")]
        public String Phone { get; set; }

        [Required(ErrorMessage = "请输入常用邮箱，以便收到信息提示")]
        public String Email { get; set; }
        public String Comments { get; set; }

        [Required(ErrorMessage = "请输入具体地址，以便送货到门")]
        public String Addrinfo { get; set; }

        [Required(ErrorMessage = "请选择地址，以便送货上门")]
        public String City { get; set; }

        [Required(ErrorMessage = "请选择地址，以便送货上门")]
        public String State { get; set; }
        public Boolean GiftWrap { get; set; }
        public Boolean Dispatched { get; set; }
        //!!!!这些字段要和数据库表中的一样！！！
        public virtual List<OrderLine> OrderLines { get; set; }
    }

    /// <summary>
    /// OrderLine类定义了Product和Order属性,而不是用int
    /// Entity Framework将自动使用外键查找其他表中的行,并用c#对象表示它们.
    /// Order类中的OrderLines属性应用的virtual关键字会使用Entity Framework加载
    ///     所有与订单关联的OrderLinet行,并使OrderLine对象列表表来表示它们.
    /// Entity Framework : http://msdn.microsoft.com/cn-gb/data/ef.aspx
    /// </summary>
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}