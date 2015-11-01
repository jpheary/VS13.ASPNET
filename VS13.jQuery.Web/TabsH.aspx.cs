using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS13 {
    //
    public partial class TabsH:System.Web.UI.Page {
        //Members
        public int mView = 0;

        //Interface
        protected void Page_Load(object sender,EventArgs e) {
            //Event handler for page load event
            if (!Page.IsPostBack) {
                //Starting tab?
                this.mView = Request.QueryString["view"] != null ? int.Parse(Request.QueryString["view"]) : 0;
                ViewState.Add("View",this.mView);
            }
            else {
                this.mView = Convert.ToInt32(ViewState["View"]);
            }
        }
    }
}