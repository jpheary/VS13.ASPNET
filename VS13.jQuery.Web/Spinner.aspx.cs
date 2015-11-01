using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS13 {
    public partial class Spinner:System.Web.UI.Page {
        //Members

        //Interface
        protected void Page_Load(object sender,EventArgs e) {
            //Page load event handler
            if (!Page.IsPostBack) {
                //Set default
                this.txtWeight.Text = "100";
                this.txtInsurance.Text = "$100";
            }
        }
    }
}