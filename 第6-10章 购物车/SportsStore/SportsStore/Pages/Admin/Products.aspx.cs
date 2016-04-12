using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SportsStore.Models;
using SportsStore.Models.Respository;
using System.Web.ModelBinding;

namespace SportsStore.Pages.Admin
{
    /// <summary>
    /// 设置GRUD方法
    /// </summary>
    public partial class Products : System.Web.UI.Page
    {
        private Repository repo = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Product> GetProducts()
        {
            return repo.Products;
        }

        public void UpdateProduct(int productID)
        {
            Product myProduct = repo.Products
                .Where(p => p.ProductID == productID).FirstOrDefault();
            if (myProduct != null &&
                TryUpdateModel(myProduct, new FormValueProvider(ModelBindingExecutionContext)))
            {
                repo.SaveProdutct(myProduct);
            }

        }

        public void DeleteProduct(int productID)
        {
            Product myProduct = repo.Products
                .Where(p => p.ProductID == productID).FirstOrDefault();
            if (myProduct != null)
            {
                repo.DeleteProduct(myProduct);
            }

        }

        public void InsertProduct()
        {//删除商品同时会删除包括该商品的所有订单
            Product myProduct = new Product();
            if(TryUpdateModel(myProduct,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repo.SaveProdutct(myProduct);
            }

        }
        /*没有下面的接口*/

        // 返回类型可以更改为 IEnumerable，但是为了支持
        // 分页和排序，必须添加以下参数:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<SportsStore.Models.Product> Unnamed_GetData()
        {
            return null;
        }
    }
}