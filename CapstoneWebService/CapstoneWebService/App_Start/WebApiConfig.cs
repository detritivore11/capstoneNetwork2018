using CapstoneWebService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace CapstoneWebService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            VehicleDB.Init();
            string initInfo = "{\"version\": \"0.01\", \"params\": [{\"name\": \"Oil Level\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"mm\", \"message\": \"\", \"type\": \"float\", \"id\": 0}, {\"name\": \"Air Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 2}, {\"name\": \"Engine Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 1}], \"id\": 1, \"key\": \"asdf\"}";
            VehicleInfo vInfo = JsonConvert.DeserializeObject<VehicleInfo>(initInfo);
            VehicleDB.Add(vInfo);
            initInfo = "{\"version\": \"0.01\", \"params\": [{\"name\": \"Oil Level\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"mm\", \"message\": \"\", \"type\": \"float\", \"id\": 0}, {\"name\": \"Air Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 2}, {\"name\": \"Engine Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 1}], \"id\": 2, \"key\": \"asdf\"}";
            vInfo = JsonConvert.DeserializeObject<VehicleInfo>(initInfo);
            VehicleDB.Add(vInfo);
            initInfo = "{\"version\": \"0.01\", \"params\": [{\"name\": \"Oil Level\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"mm\", \"message\": \"\", \"type\": \"float\", \"id\": 0}, {\"name\": \"Air Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 2}, {\"name\": \"Engine Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 1}], \"id\": 3, \"key\": \"asdf\"}";
            vInfo = JsonConvert.DeserializeObject<VehicleInfo>(initInfo);
            VehicleDB.Add(vInfo);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
