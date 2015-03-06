using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace VS13.Reports {
    //
    public partial class Report11:System.Web.UI.Page {
        //Members
        private string mTitle = "Report 11";
        private string mSource = "Reports\\Department1\\Report 11.rdlc";    //"/Department1/Report 1";
        private string mDSName = "DataSet1";
        private string mUSPName = "",mTBLName = "NewTable";

        //Interface
        protected void Page_Load(object sender,EventArgs e) {
            //Event handler for page load event
            try {
                if (!Page.IsPostBack && !ScriptManager.GetCurrent(Page).IsInAsyncPostBack) {
                    //Initialize control values
                    this.Title = Master.ReportTitle = this.mTitle + " Report";
                    OnValidateForm(null,EventArgs.Empty);
                }
                Master.ButtonCommand += new CommandEventHandler(OnButtonCommand);
            }
            catch (Exception ex) { Master.ReportError(ex); }
        }
        protected override void OnInit(EventArgs e) {
            //Event handler for page Init event
            if (!Page.IsPostBack && !ScriptManager.GetCurrent(Page).IsInAsyncPostBack) {
                //Get configuration values for this report
                System.Xml.XmlNode configuration = Master.ReportConfiguration;
                if (configuration != null) {
                    this.mTitle = configuration.Attributes["name"].Value;
                    this.mSource = configuration.Attributes["src"].Value;
                    this.mDSName = configuration.Attributes["ds"].Value;
                    this.mUSPName = configuration.Attributes["usp"].Value;
                    this.mTBLName = configuration.Attributes["tbl"].Value;
                }
            }
            base.OnInit(e);
        }
        protected void OnValidateForm(object sender,EventArgs e) {
            //Event handler for changes in parameter data
            Master.Validated = true;
        }
        protected void OnButtonCommand(object sender,CommandEventArgs e) {
            //Event handler for command button clicked
            try {
                //Change view to Viewer and reset to clear existing data
                Master.Viewer.Reset();

                //Get parameters
                //string _param1 = "";

                //Initialize control values and get report data
                LocalReport report = Master.Viewer.LocalReport;
                report.DisplayName = this.mTitle;
                report.EnableExternalImages = true;
                DataSet ds = null;  //new DataGateway().FillDataset(this.mUSPName,mTBLName,new object[] { _param1 });
                if (ds == null) ds = new DataSet();
                if (ds.Tables[mTBLName] == null) ds.Tables.Add(mTBLName);
                switch (e.CommandName) {
                    case "Run":
                        //Set local report and data source
                        if (this.mSource.Substring(0,1) == "/") 
                            report.LoadReportDefinition(Master.GetReportDefinition(this.mSource));
                        else 
                            report.ReportPath = this.mSource;
                        report.DataSources.Clear();
                        report.DataSources.Add(new ReportDataSource(this.mDSName,ds.Tables[mTBLName]));

                        //Set the report parameters for the report
                        //ReportParameter param1 = new ReportParameter("Param1",_param1);
                        //report.SetParameters(new ReportParameter[] { param1 });

                        //Update report rendering with new data
                        report.Refresh();

                        if (!Master.Viewer.Enabled) Master.Viewer.CurrentPage = 1;
                        break;
                }
            }
            catch (Exception ex) { Master.ReportError(ex); }
        }
    }
}