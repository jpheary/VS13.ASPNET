using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
//using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
//using Microsoft.Practices.EnterpriseLibrary.Data;

namespace VS13.Reports {
    //
    public class SSRSGateway {
        //Members
        private const string ITEM_SUBPATH = "/VS13.Reports";

        //Interface
        public SSRSGateway() { }
        public Stream GetReportDefinition(string report) {
            //Return a report definition from the SQL reporting server
            //microsoft.ReportingService2010 rs = new microsoft.ReportingService2010();
            //rs.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            //byte[] bytes = rs.GetItemDefinition(ITEM_SUBPATH + report);
            //return new System.IO.MemoryStream(bytes);
            return new System.IO.MemoryStream(new byte[] { });
        }
    }
}