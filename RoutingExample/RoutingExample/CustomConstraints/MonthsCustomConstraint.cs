
using System.Text.RegularExpressions;

namespace RoutingExample.CustomConstraints
{
    //Eg: sales-report/2020/apr
    public class MonthsCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //check whether the value exists, routeKey is the month
            if (!values.ContainsKey(routeKey))
            {
                return false; //not a match
            }
            Regex regex = new Regex("^(apr|jul|oct|jan)$");
            string monthValue = Convert.ToString(values[routeKey]);//it has to be converted to string because by default its of type object

            if (regex.IsMatch(monthValue!))
            {
                return true; //its a match
            }
            return false;
            throw new NotImplementedException();
        }
    }
}
