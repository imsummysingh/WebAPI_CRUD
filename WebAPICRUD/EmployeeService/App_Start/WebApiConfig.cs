using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Web.Http.Cors;

namespace EmployeeService
{
    //Approach 2: To change xml to jsom in browser whenever we issue a request and it will also change the contnet-type in header
    //public class CustomJsonFormatter: JsonMediaTypeFormatter
    //{
    //    public CustomJsonFormatter()
    //    {
    //        this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
    //    }
    //    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
    //    {
    //        base.SetDefaultContentHeaders(type, headers, mediaType);
    //        headers.ContentType = new MediaTypeHeaderValue("applocation/json");
    //    }
    //}
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Enable cors
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors();

            //Http to https
            //config.Filters.Add(new RequireHttpsAttribute());

            //basic authentication
            //config.Filters.Add(new BasicAuthenticationAttribute());

            //camelcase data formatter
            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //media type formatter
            //config.Formatters.Remove(config.Formatters.JsonFormatter);  //to remove json formatter
            //config.Formatters.Remove(config.Formatters.XmlFormatter);   //to remove xml formatter

            //Approach 1: To change xml to json in broswer whenever we issue a request.
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            //Approach 2
            //config.Formatters.Add(new CustomJsonFormatter());
        }
    }
}
