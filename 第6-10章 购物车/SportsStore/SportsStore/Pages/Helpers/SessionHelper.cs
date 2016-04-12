using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.SessionState;
using SportsStore.Models;

namespace SportsStore.Pages.Helpers
{
    /*
     * Session["Cart"]=cart;
     * Cart cart=(Cart)Session["Cart"];
     * 会话状态机制特别有用，但可能会导致一些常见问题：
     * 问题一：应用程序的不同组件会将同一个键用于不同的数据类型（会在转换object结果时造成问题），
     *          或在不同键用相同数据（这会在数据置于会话状态中，但却无法正确检索）
     * 问题二：代码重复，即在应用程序中多次实现相同的功能，应该避免重复，因为这会增加测试和维护应用程序的难度
     * 
     * 默认情况下会话数据对象存储在ASP.NET服务器内存中，也可存储在SQL数据库中
     * 
     * Cart cart(Cart)Session["cart"];
     * if(cart==null){cart=new Cart();Session["Cart"]=cart;}
     * 在需要Cart对象的Web窗体中，整个应用程序会多次用到这段代码。
     * 要使这段代码生效，需要确保始终使用Cart键来获取或设置会话数据值，并仅将Cart对象和Cart键关联。
     * 如果创建和管理Cart对象发生变化，那么就需要找到这个代码段的每个实例，并对它们进行更新。
     *      为了避免上述问题，我们要创建包含某些用于处理会话数据的静态方法的类：
     */
   
    /// <summary>
    /// CART将用于Cart对象；
    /// RETUREN_RUL将用于用户单击"继续购物"按键,会将该值返回给用户的URL 
    /// </summary>
    public enum SessionKey
    {
        CART, RETURN_RUL
    }
   
    public static class SessionHelper
    {
        /// <summary>
        /// 使用SessionKey值在会话中放置一个新数据对象
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set(HttpSessionState session, SessionKey key, object value)
        {
            session[Enum.GetName(typeof(SessionKey), key)] = value;
            //session.Timeout = 1;session默认有效时间为20min
        }

        /// <summary>
        /// 获取SessionKey值并返回对应的数据对象
        /// </summary>
        /// <typeparam name="T">泛型类型参数</typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(HttpSessionState session, SessionKey key)
        {
            object dataValue = session[Enum.GetName(typeof(SessionKey), key)];
            if (dataValue != null && dataValue is T) { return (T)dataValue; }
            else { return default(T); }
        }

        /// <summary>
        /// 在Get<T>和Set方法基础上，创建了GetCart方法，这样解决了代码重复问题
        /// 并在一个位置管理的Cart对象
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public static Cart GetCart(HttpSessionState session)
        {
            Cart mycart = Get<Cart>(session, SessionKey.CART);
            if (mycart == null)
            {
                mycart = new Cart();
                Set(session, SessionKey.CART, mycart);
            }
            return mycart;
        }


    }
}