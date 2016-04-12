using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//执行验证
using System.ComponentModel.DataAnnotations;

namespace PartyInvites
{
    public class GuestResponse
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Phone { get; set; }

        /// <summary>
        /// Boolean? 可null
        /// </summary>
        [Required(ErrorMessage="Please tell us if you will attend")]
        public Boolean? WillAttend { get; set; }
        /*
         *      bool?安全强制转换为bool

         * bool? 可为true,false,null，在if,for,while无法编译
         * 
            bool? test = null;
            if (!test.HasValue)
            {   //Assume that isInitialized
                //return either true or false
            }
            if ((bool)test)//now this is safe
            {
                //Do something
            }
            else
            {
                //Do another thing
            }
         * 
         */
    }
}