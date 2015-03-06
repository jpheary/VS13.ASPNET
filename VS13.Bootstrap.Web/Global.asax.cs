using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace VS13 {
    //
    public class Global:HttpApplication {
        void Application_Start(object sender,EventArgs e) {
            //Code that runs on application startup
            //Add routes by adding them to the static RouteTable::Routes class property; the Routes property is a 
            //RouteCollection object that stores all the routes for the application.
            RouteCollection routes = RouteTable.Routes;
            routes.MapPageRoute("Default","Default/{*subPage}","~/Default.aspx");
        }
    }
}