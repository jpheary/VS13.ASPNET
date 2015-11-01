using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS13 {
    public partial class TimeSpinner:System.Web.UI.Page {
        //Members

        //Interface
        protected void Page_Load(object sender,EventArgs e) {
            //Page load event handler
            if (!Page.IsPostBack) {
                //Set default time
                //this.txtTime.Text = DateTime.Now.ToString("HH:mm tt");

                this.txtFrom.Text = "09:00 AM";
                this.txtTo.Text = "05:00 PM";
                OnWindowChanged(null,EventArgs.Empty);
            }
        }
        protected void OnWindowChanged(object sender,EventArgs e) {
            //Event handler for change in selected dates
            this.lblWindow.Text = this.txtFrom.Text + " - " + this.txtTo.Text;
        }
    }
}