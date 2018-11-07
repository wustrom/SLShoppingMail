using System.Web.Http;
using WebActivatorEx;
using SLSM.MoblieWeb;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SLSM.MoblieWeb
{
    /// <summary>
    /// SwaggerConfig
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// 注册
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "SLSM.MoblieWeb");
                        //添加XML解析
                        c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi(c =>
                    {
                        
                    });
        }

        /// <summary>
        /// 添加XML解析
        /// </summary>
        /// <returns></returns>
        private static string GetXmlCommentsPath()
        {
            return string.Format("{0}/bin/SLSM.MoblieWeb.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
