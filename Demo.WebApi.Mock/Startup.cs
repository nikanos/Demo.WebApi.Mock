using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;
using System.Net.Http.Formatting;
using System.Web.Http;

[assembly: OwinStartup(typeof(Demo.WebApi.Mock.Startup))]
namespace Demo.WebApi.Mock
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureWebApi(app);
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();

            httpConfig.Formatters.Clear();
            httpConfig.Formatters.Add(new JsonMediaTypeFormatter()); // Keep only JSON formatter
            httpConfig.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            httpConfig.MapHttpAttributeRoutes(); // Use attribute-based routing

            app.UseWebApi(httpConfig);
            ConfigureSwagger(httpConfig);
        }

        private void ConfigureSwagger(HttpConfiguration httpConfig)
        {
            httpConfig.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Demo WebApi Mock");
            }).EnableSwaggerUi(x =>
            {
                x.EnableDiscoveryUrlSelector();
                x.DisableValidator();
            });
        }
    }
}
