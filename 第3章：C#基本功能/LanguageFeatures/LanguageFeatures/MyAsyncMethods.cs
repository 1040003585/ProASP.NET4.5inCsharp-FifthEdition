using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * System.Net.Http.HttpClient类（该类会提出异步HTTP请求）
 * Visual Studio 的Project Add Reference 在Framework引出
 */
using System.Net.Http;
using System.Threading.Tasks;
/*使用异步方法*/
/*
 * 异步方法是打破代码瓶颈的重要工具，
 * 它允许应用程序利用多个处理器和处理器内核并行执行工作。
 */
namespace LanguageFeatures
{
    public class MyAsyncMethods
    {
        public static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpTask = client.GetAsync("http://apress.com");
            //httpTask是返回的长度，Task<HttpResponseMessage>类型

            /*在等待时，我们可以在些处执行其他操作
              便于完成HTTP请求*/

            return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) => {
                return antecedent.Result.Content.Headers.ContentLength;
            //第一个return 指定将返回一个Task<HttpResponseMessage>对象，
            //完成之后将return ContentLength标头的长度。（可null的long值）
            //GetPageLength 方法的结果为Task<long?>
            });
        }
    }

    /*应用async和await关键字*/
    //（专门用于简化异步方法（如HttpClient.GetAsync））
    public class MyAsyncMethods
    {
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://apress.com");
            return httpMessage.Content.Headers.ContentLength;
        }
    }
}