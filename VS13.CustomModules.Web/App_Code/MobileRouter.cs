using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VS13 {
    //From MSDN Cutting Edge: Mobilize An Existing Web Site by Dino Esposito
    public class MobileRouter:IHttpModule {
        //Members
        private const String FullSiteModeCookie = "FullSiteMode";

        //Interface
        public MobileRouter() { }
        public void Dispose() { }
        public void Init(HttpApplication context) {
            // In the Init function, register for HttpApplication events by adding handlers
            context.BeginRequest += OnBeginRequest;
        }
        
        private static void OnBeginRequest(Object sender,EventArgs e) {
            var app = sender as HttpApplication;
            if (app == null) throw new ArgumentNullException("sender");

            if (app.Context.Request.Browser.IsMobileDevice && HasFullSiteFlag(app)) {
                //Mobile on desktop site, but FULL-SITE flag on the query string
                app.Response.AppendCookie(new HttpCookie(FullSiteModeCookie));
                return;
            }
            if (app.Context.Request.Browser.IsMobileDevice && HasFullSiteCookie(app)) {
                //Mobile on desktop site, but FULL-SITE cookie
                return;
            }
            if (app.Context.Request.Browser.IsMobileDevice) {
                //Mobile on desktop site => landing page
                ToMobileLandingPage(app);
            }
        }
        private static Boolean HasFullSiteFlag(HttpApplication app) {
            //
            var fullSiteFlag = app.Context.Request.QueryString["m"];
            if (!String.IsNullOrEmpty(fullSiteFlag))
                return String.Equals(fullSiteFlag,"f");
            return false;
        }
        private static Boolean HasFullSiteCookie(HttpApplication app) {
            //
            return app.Context.Request.Cookies[FullSiteModeCookie] != null;
        }
        private static void ToMobileLandingPage(HttpApplication app) {
            //
            var landingPage = ConfigurationManager.AppSettings["MobileLandingPage"];
            if (!String.IsNullOrEmpty(landingPage)) app.Context.Response.Redirect(landingPage);
        }
    }
}
