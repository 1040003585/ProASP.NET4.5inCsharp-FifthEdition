using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//要先安装Nuget包
using System.Web.Optimization;

namespace SportsStore
{
    public class BundleConfig
    {
        /// <summary>
        /// 创建脚本捆绑包
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/validation").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js"

                ));
        }
    }
}