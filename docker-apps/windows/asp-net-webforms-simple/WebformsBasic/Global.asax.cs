using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace WingtipToys
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void RegisterCustomRoutes(RouteCollection routes)
        {
          routes.MapPageRoute(
              "ProductsByCategoryRoute",
              "Category/{categoryName}",
              "~/ProductList.aspx"
          );
          routes.MapPageRoute(
              "ProductByNameRoute",
              "Product/{productName}",
              "~/ProductDetails.aspx"
          );
        }

        void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();

            throw ex;
        }
    }
}