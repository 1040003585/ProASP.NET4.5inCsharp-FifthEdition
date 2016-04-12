using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures
{
    /*显式实现接口*/
    /*
     * 显式实现接口可以创建一个类来实现多个定义在同一方法的签名接口
     */
    public class MyInterfaces
    {
    }

    public interface IMonthProvider
    {
        string GetCurrent();
    }
    public interface IYearProvider
    {
        string GetCurrent();
    }

    public class TimeProvider : IMonthProvider, IYearProvider
    {
        private DateTime now = DateTime.Now;
        string IMonthProvider.GetCurrent()
        {
            return now.ToString("MMM");
        }
        string IYearProvider.GetCurrent()
        {
            return now.Year.ToString();
        }
    }

}