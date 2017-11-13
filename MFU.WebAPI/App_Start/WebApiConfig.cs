using MFU.WebAPI.Security;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MFU.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();

            // Configure the authentication filter to run on every request marked with the AuthorizeAttribute
            config.Filters.Add(new BearerAuthenticationFilter());

            // Configure the sliding expiration handler to run on every request
            config.MessageHandlers.Add(new SlidingExpirationHandler());

            // Help our JSON look professional using camelCase
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
