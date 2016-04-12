using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures
{
    /* 使用泛型类 */

    public class MyContainers
    {
    }
    public class StringContainer
    {
        public string Value { get; set; }
        public bool HasValue
        {
            get { return Value != null; }
        }

    }
    public class DateTimeContainer
    {
        public DateTime Value { get; set; }
        public bool HasValue
        {
            get { return Value != null; }
        }
    }

    /*定义通用基类*/
    public class BaseContainer
    {
        public object Value { get; set; }
        public bool HasValue
        {
            get { return Value != null; }
        }
    }

    /*定义泛型类型*/
    /*          可维护性和稳定性
     * 解决代码重复问题，避免运行时转换问题带来的风险
     */
    public class ValueContainer<T>
    {//TKey 或 TValue
        public T Value { get; set; }
        public bool HasValue
        {
            get { return Value != null; }
        }
    }

}