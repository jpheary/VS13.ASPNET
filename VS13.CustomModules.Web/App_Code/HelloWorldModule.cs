using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VS13 {
    //
    public class HelloWorldModule:IHttpModule {
        //Members

        //Interface
        public HelloWorldModule() { }
        public void Dispose() { }
        public string ModuleName { get { return "HelloWorldModule"; } }
        public void Init(HttpApplication application) {
            // In the Init function, register for HttpApplication events by adding handlers
            application.BeginRequest += OnBeginRequest;
            application.AuthenticateRequest += OnAuthenticateRequest;
            application.PostAuthenticateRequest += OnPostAuthenticateRequest;
            application.AuthorizeRequest += OnAuthorizeRequest;
            application.PostAuthorizeRequest += OnPostAuthorizeRequest;
            application.ResolveRequestCache += OnResolveRequestCache;
            application.PostResolveRequestCache += OnPostResolveRequestCache;
            application.MapRequestHandler += OnMapRequestHandler;
            application.PostMapRequestHandler += OnPostMapRequestHandler;
            application.AcquireRequestState += OnAcquireRequestState;
            application.PostAcquireRequestState += OnPostAcquireRequestState;
            application.PreRequestHandlerExecute += OnPreRequestHandlerExecute;
            //application.RequestCompleted += OnRequestCompleted;
            application.PostRequestHandlerExecute += OnPostRequestHandlerExecute;
            application.ReleaseRequestState += OnReleaseRequestState;
            application.PostReleaseRequestState += OnPostReleaseRequestState;
            application.UpdateRequestCache += OnUpdateRequestCache;
            application.PostUpdateRequestCache += OnPostUpdateRequestCache;
            application.LogRequest += OnLogRequest;
            application.PostLogRequest += OnPostLogRequest;
            application.EndRequest += OnEndRequest;
            application.PreSendRequestHeaders += OnPreSendRequestHeaders;
            application.PreSendRequestContent += OnPreSendRequestContent;
        }
        private void OnBeginRequest(Object sender,EventArgs e) { logEvent("BeginRequest",(HttpApplication)sender); }
        private void OnAuthenticateRequest(object sender,EventArgs e) { logEvent("AuthenticateRequest",(HttpApplication)sender); }
        private void OnPostAuthenticateRequest(object sender,EventArgs e) {
            HttpApplication app = (HttpApplication)sender;
            logEvent("PostAuthenticateRequest",app);
            app.Context.Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name= " + app.Context.User.Identity.Name + "; AuthenticationType= " + app.Context.User.Identity.AuthenticationType + "; IsAuthenticated= " + app.Context.User.Identity.IsAuthenticated.ToString() + "</br>");
        }
        private void OnAuthorizeRequest(object sender,EventArgs e) { logEvent("AuthorizeRequest",(HttpApplication)sender); }
        private void OnPostAuthorizeRequest(object sender,EventArgs e) {
            HttpApplication app = (HttpApplication)sender;
            logEvent("PostAuthorizeRequest",app);
            app.Context.Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsAdministrator= " + app.Context.User.IsInRole("Administrator").ToString() + "</br>");
        }
        private void OnResolveRequestCache(object sender,EventArgs e) { logEvent("ResolveRequestCache",(HttpApplication)sender); }
        private void OnPostResolveRequestCache(object sender,EventArgs e) { logEvent("PostResolveRequestCache",(HttpApplication)sender); }
        private void OnMapRequestHandler(object sender,EventArgs e) { logEvent("MapRequestHandler",(HttpApplication)sender); }
        private void OnPostMapRequestHandler(object sender,EventArgs e) { logEvent("PostMapRequestHandler",(HttpApplication)sender); }
        private void OnAcquireRequestState(object sender,EventArgs e) { logEvent("AcquireRequestState",(HttpApplication)sender); }
        private void OnPostAcquireRequestState(object sender,EventArgs e) { logEvent("PostAcquireRequestState",(HttpApplication)sender); }
        private void OnPreRequestHandlerExecute(object sender,EventArgs e) { logEvent("PreRequestHandlerExecute",(HttpApplication)sender); }
        private void OnRequestCompleted(object sender,EventArgs e) { logEvent("RequestCompleted",(HttpApplication)sender); }
        private void OnPostRequestHandlerExecute(object sender,EventArgs e) { logEvent("PostRequestHandlerExecute",(HttpApplication)sender); }
        private void OnReleaseRequestState(object sender,EventArgs e) { logEvent("ReleaseRequestState",(HttpApplication)sender); }
        private void OnPostReleaseRequestState(object sender,EventArgs e) { logEvent("PostReleaseRequestState",(HttpApplication)sender); }
        private void OnUpdateRequestCache(object sender,EventArgs e) { logEvent("UpdateRequestCache",(HttpApplication)sender); }
        private void OnPostUpdateRequestCache(object sender,EventArgs e) { logEvent("PostUpdateRequestCache",(HttpApplication)sender); }
        private void OnLogRequest(object sender,EventArgs e) { logEvent("LogRequest",(HttpApplication)sender); }
        private void OnPostLogRequest(object sender,EventArgs e) { logEvent("PostLogRequest",(HttpApplication)sender); }
        private void OnEndRequest(Object sender,EventArgs e) { logEvent("EndRequest",(HttpApplication)sender); }
        private void OnPreSendRequestContent(object sender,EventArgs e) { logEvent("PreSendRequestContent",(HttpApplication)sender); }
        private void OnPreSendRequestHeaders(object sender,EventArgs e) { logEvent("PreSendRequestHeaders",(HttpApplication)sender); }

        private void logEvent(string eventName,HttpApplication application) {
            if (application.Context != null) {
                string fileExtension = VirtualPathUtility.GetExtension(application.Context.Request.FilePath);
                if (fileExtension.Equals(".aspx")) application.Context.Response.Write(DateTime.Now.ToString("hh:mm:ss:fff") + "\t HttpApplication::" + eventName + "</br>");
            }
        }

    }
}