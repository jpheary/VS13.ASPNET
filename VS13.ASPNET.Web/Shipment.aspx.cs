using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS13 {
    //
    public partial class Shipment:System.Web.UI.Page {
        //Members
        protected string mClientName = "Speedy Logistics, Inc.",mClientNumber = "001";

        //Interface
        protected void Page_Load(object sender,EventArgs e) {
            //Page load event handler
            if (!Page.IsPostBack) {
                //Client info
                ViewState.Add("ClientName",this.mClientName);
                ViewState.Add("ClientNumber",this.mClientNumber);

                this.lblClientName.Text = this.mClientName;
            }
            else {
                this.mClientName = ViewState["ClientName"].ToString();
                this.mClientNumber = ViewState["ClientNumber"].ToString();
            }
        }
    }
}