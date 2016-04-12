using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites
{
    /*设定场景
     * 1、一个页面，用于显示晚会相关信息及出席回函；
     * 2、验证出席回函，此时将显示确认页面；
     * 3、列出受邀请者回函的页面。
     */

    /// <summary>
    /// 存储库提供了各种用于创建、读取、更新和删除数据对象的方法——CRUD方法（create read update delete）
    /// </summary>
    public class ResponseRepository
    {
        private static ResponseRepository repository = new ResponseRepository();
        private List<GuestResponse> responses = new List<GuestResponse>();

        /// <summary>
        /// static !!!!!!
        /// </summary>
        /// <returns></returns>
        public static ResponseRepository GetRespository()
        {
            return repository;
        }
        public IEnumerable<GuestResponse> GetAllResponses()
        {
            return responses;
        }
        public Boolean AddResponses(GuestResponse response)
        {
            try
            {
                responses.Add(response);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}