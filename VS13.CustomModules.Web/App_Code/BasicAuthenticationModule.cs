//VS13.CustomModules.Web
//This module performs basic authentication. For details on basic authentication see RFC 2617.
//BasicAuthenticationModule::OnAuthenticateRequest()
//  Extract and verify the basic authentication credentials; if succesfull, create the user principal with these credentials.
//BasicAuthenticationModule::OnEndRequest()
//  If the request has been rejected with unauthorized status code (401), add a basic authentication challenge to trigger basic authentication.
//
//Debugging
//It will be necessary use local IIS, not IIS Express; this is changed in the project properties Web - Servers settings.
//
//Deployment
//In web.config, add the custom module and disable all other authentication modules; it may be necessary to unlock the configuration 
//sections in the IIS configuration store (i.e. applicationHost.config) using AppCmd.exe:
//  c:\windows\system32\inetsrv\appcmd.exe unlock config /section:windowsAuthentication
//<system.webServer>
//  <modules>
//    <add name="VS13BasicAuthenticationModule" type="VS13.BasicAuthenticationModule" />
//  </modules>
//  <security>
//    <authentication>
//      <windowsAuthentication enabled="false" />
//      <basicAuthentication enabled="false" />
//      <anonymousAuthentication enabled="false" />
//    </authentication>
//  </security>
//</system.webServer>
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Security.Principal;

namespace VS13 {
    //
    public class BasicAuthenticationModule:IHttpModule {
        //Members
        public const string HTTP_AUTHORIZATIONHEADER = "Authorization";         //HTTP1.1 Authorization header
        public const string HTTP_BASICSCHEMENAME = "Basic";                     //HTTP1.1 Basic Challenge Scheme Name
        public const char HTTP_CREDENTIALSEPARATOR = ':';                       //HTTP1.1 Credential username and password separator
        public const int HTTP_NOTAUTHORIZEDSTATUSCODE = 401;                    //HTTP1.1 Not authorized response status code
        public const string HTTP_WWWAUTHENTICATEHEADER = "WWW-Authenticate";    //HTTP1.1 Basic Challenge Scheme Name
        public const string REALM = "VS13";                                     //HTTP1.1 Basic Challenge Realm

        //Interface
        public BasicAuthenticationModule() { }
        public void Dispose() { }
        public void Init(HttpApplication application) {
            //Register for HttpApplication events
            application.AuthenticateRequest += new EventHandler(this.OnAuthenticateRequest);
            application.EndRequest += new EventHandler(this.OnEndRequest);
        }
        private void OnAuthenticateRequest(object sender,EventArgs e) {
            //Authenticate the request by returning an object that implements System.Security.Principal.IPrincipal
            HttpApplication app = (HttpApplication)sender;
            string userName = null, password = null, realm = null;
            string authorizationHeader = app.Context.Request.Headers[HTTP_AUTHORIZATIONHEADER];

            //Extract and validate the basic authentication credentials from the request
            if(!extractBasicCredentials(authorizationHeader, ref userName, ref password)) return;
            if(!validateCredentials(userName, password, realm)) return;

            //Create the user principal and associate it with the request
            app.Context.User = new GenericPrincipal(new GenericIdentity(userName),null);
        }
        private void OnEndRequest(Object sender,EventArgs e) {
            //Issue a basic challenge if necessary
            HttpApplication app = (HttpApplication)sender;
            if (app.Context.Response.StatusCode == HTTP_NOTAUTHORIZEDSTATUSCODE) app.Context.Response.AddHeader(HTTP_WWWAUTHENTICATEHEADER,"Basic realm =\"" + REALM + "\"");
        }
        private bool extractBasicCredentials(string authorizationHeader, ref string username, ref string password) {
            //authorizationHeader will be similiar to "Basic anBoZWFyeTpwYXNzd29yZA==" after the basic challenge
            if ((authorizationHeader == null) || (authorizationHeader.Equals(string.Empty))) return false;
            string header = authorizationHeader.Trim();
            if (header.IndexOf(HTTP_BASICSCHEMENAME) != 0) return false;

            //Get the credential payload and decode the base 64 encoded credential payload
            header = header.Substring(HTTP_BASICSCHEMENAME.Length, header.Length - HTTP_BASICSCHEMENAME.Length).Trim();
            byte[] credentialBase64DecodedArray = Convert.FromBase64String(header);
            string decodedAuthorizationHeader = new UTF8Encoding().GetString(credentialBase64DecodedArray,0,credentialBase64DecodedArray.Length);

            //Get the username, password, and realm 
            int separatorPosition = decodedAuthorizationHeader.IndexOf(HTTP_CREDENTIALSEPARATOR);
            if(separatorPosition <= 0) return false;
            username = decodedAuthorizationHeader.Substring(0,separatorPosition).Trim();
            password = decodedAuthorizationHeader.Substring(separatorPosition + 1,(decodedAuthorizationHeader.Length - separatorPosition - 1)).Trim();
            if(username.Equals(string.Empty) || password.Equals(string.Empty)) return false;

            return true;
        }
        private bool validateCredentials(string userName, string password, string realm) {
            //Validate the credentials using Membership provider
            //return Membership.ValidateUser(userName, password); 
            return (userName.Equals("jpheary") && password.Equals("password"));
        }
    }
}