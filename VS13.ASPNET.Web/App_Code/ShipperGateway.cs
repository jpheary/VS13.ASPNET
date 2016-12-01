using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace VS13 {
    //
    public class ShipperGateway {
        //Members

        //Interface
        public ShipperGateway() { }
        public DataSet ViewShippers(string clientNumber) {
            //
            DataSet ds = new DataSet();
            ds.ReadXml(HttpRuntime.AppDomainAppPath + "\\App_Data\\shippers.xml",XmlReadMode.ReadSchema);
            return ds;
        }
    }
}