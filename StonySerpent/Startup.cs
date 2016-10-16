using System.Reflection;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StonySerpent.Startup))]

namespace StonySerpent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var webApiConfiguration = new HttpConfiguration();
            //webApiConfiguration.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional, controller = "values" });

            //app.UseNinjectMiddleware(CreateKernel);
            //app.UseNinjectWebApi(webApiConfiguration);



            ConfigureAuth(app);
        }
    }
}
