using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRDCLRazor
{
    public class RouteConstraints : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            int id;
            if(Int32.TryParse(values["Id"].ToString(), out id)){
                return true;
            }
            return false;
        }
    }
}
