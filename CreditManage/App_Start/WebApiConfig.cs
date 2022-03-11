using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CreditManage
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // customer route
            config.Routes.MapHttpRoute(
                name: "Customer",
                routeTemplate: "Customers/{id}",
                defaults: new { controller = "customer", id = RouteParameter.Optional }
    
                //constraints: new { id = "/d+" }
            );

            // customeraccounts route
            config.Routes.MapHttpRoute(
                name: "CustomerAccounts",
                routeTemplate: "CustomerAccounts/{id}",
                defaults: new { controller = "customeraccounts", id = RouteParameter.Optional }

            //constraints: new { id = "/d+" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
