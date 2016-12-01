using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS13 {
    //
    public partial class Shippers:System.Web.UI.Page {
        //Members
        private string mClientName = "",mClientNumber = "";

        //Interface
        protected void Page_Load(object sender,EventArgs e) {
            //Event handler for page load event
            try {
                if (!Page.IsPostBack) {
                    //Client info
                    this.mClientName = Request.QueryString["clientname"];
                    ViewState.Add("ClientName",this.mClientName);
                    this.mClientNumber = Request.QueryString["clientnumber"];
                    ViewState.Add("ClientNumber",this.mClientNumber);

                    //Setup UI
                    this.mvwPage.ActiveViewIndex = 0;
                    this.lblShippersClient.Text = this.mClientName;
                    this.odsShippers.SelectParameters["clientNumber"].DefaultValue = this.mClientNumber;
                    this.grdShippers.DataBind();
                }
                else {
                    this.mClientName = ViewState["ClientName"].ToString();
                    this.mClientNumber = ViewState["ClientNumber"].ToString();
                }
            }
            catch (Exception ex) { reportError(ex); }
            finally { OnValidateForm(null,EventArgs.Empty); }
        }
        protected void OnShipperSelected(object sender,EventArgs e) { OnValidateForm(null,EventArgs.Empty); }
        protected void OnValidateForm(object sender,EventArgs e) {
            //Event handler for changes in parameter data
            try {
                this.btnNew.Enabled = true;
                this.btnOk.Enabled = this.grdShippers.SelectedDataKey != null;
                this.btnClose.Enabled = true;

                this.btnSubmit.Enabled = true;
                this.btnCancel.Enabled = true;
            }
            catch (Exception ex) { reportError(ex); }
        }
        protected void OnCommand(object sender,CommandEventArgs e) {
            //
            try {
                switch (e.CommandName) {
                    case "New":
                        this.mvwPage.ActiveViewIndex = 1;
                        break;
                    case "Ok":
                        break;
                    case "Close":
                        break;
                    case "Submit":
                        //New
                        //Shipper shipper = new Shipper();
                        //shipper.ClientNumber = this.mClientNumber;
                        //shipper.Name = this.txtName.Text;
                        //shipper.AddressLine1 = this.txtStreet.Text;
                        //shipper.City = this.txtCity.Text;
                        //shipper.State = this.txtState.Text;
                        //shipper.Zip = this.txtZip.Text;
                        //shipper.ContactName = this.txtContactName.Text;
                        //shipper.ContactPhone = this.txtContactPhone.Text;
                        //shipper.ContactEmail = this.txtContactEmail.Text;
                        //string number = new ShipperGateway().CreateShipper(shipper);
                        showMessageBox("New shipper has been created.");

                        this.mvwPage.ActiveViewIndex = 0;
                        this.grdShippers.DataBind();
                        break;
                    case "Cancel":
                        this.mvwPage.ActiveViewIndex = 0;
                        break;
                }
            }
            catch (Exception ex) { reportError(ex); }
        }

        private void reportError(Exception ex) {
            try {
                string msg = ex.Message;
                if (ex.InnerException != null) msg = ex.Message + "\n\n NOTE: " + ex.InnerException.Message;
                showMessageBox(msg);
            }
            catch (Exception) { }
        }
        private void showMessageBox(string message) {
            message = message.Replace("'","").Replace("\n"," ").Replace("\r"," ");
            ScriptManager.RegisterStartupScript(this.lblMsg,typeof(Label),"Error","alert('" + message + "');",true);
        }
    }
}