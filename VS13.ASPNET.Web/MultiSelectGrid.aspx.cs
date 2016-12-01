using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS13 {
    public partial class MultiSelectGrid:System.Web.UI.Page {
        //Members
        private int mPublicationID = 100;
        private DataTable mCategories = null;

        //Interface
        protected void Page_Load(object sender, EventArgs e) {
            //Page load event handler
            try {
                if (!Page.IsPostBack) {
                    //Get the publication (new or existing)
                    ViewState.Add("PublicationID",this.mPublicationID);
                    this.mCategories = getPublicationCategories();
                    ViewState.Add("Categories", this.mCategories);

                    bindCategoryGrid();
                }
                else {
                    this.mPublicationID = ViewState["PublicationID"] != null ? (int)ViewState["PublicationID"] : 0;
                    this.mCategories = ViewState["Categories"] != null ? (DataTable)ViewState["Categories"] : null;
                }
            }
            catch (Exception ex) { reportError("MultiSelectGrid.aspx", "Page_Load", ex, 3); }
            finally { OnValidateForm(null, EventArgs.Empty); }
        }
        protected void OnCategorySelected(object sender, EventArgs e) {
            //Event handler for selecting categories
            DataTable tblremoved,tbladded;
            try {
                CheckBox chkSelect = (CheckBox)sender;
                GridViewRow gvRow = (GridViewRow)chkSelect.Parent.Parent;
                //string categoryID = gvRow.Cells[1].Text;                  //NOTE: Can go by cell value but then column needs to be visible
                string categoryID = this.grdCategories.DataKeys[gvRow.RowIndex].Value.ToString();
                if (chkSelect.Checked) {
                    this.mCategories.Rows.Add(new object[] { this.mPublicationID, categoryID});
                }
                else {
                    DataRow[] rows = this.mCategories.Select("CategoryID='" + categoryID + "'");
                    if (rows.Length > 0) rows[0].Delete();
                }
                //Debug
                tblremoved = this.mCategories.GetChanges(DataRowState.Deleted);
                if (tblremoved != null && tblremoved.Rows.Count > 0) {
                    foreach (DataRow row in tblremoved.Rows) Debug.WriteLine("D: 0=" + row[0,DataRowVersion.Original].ToString() + "; 1=" + row[1,DataRowVersion.Original].ToString() + "; 2=" + row[2,DataRowVersion.Original].ToString());
                }
                tbladded = this.mCategories.GetChanges(DataRowState.Added);
                if (tbladded != null && tbladded.Rows.Count > 0) {
                    foreach (DataRow row in tbladded.Rows) Debug.WriteLine("A: 0=" + row[0].ToString() + "; 1=" + row[1].ToString() + "; 2=" + row[2].ToString());
                }
                Debug.WriteLine("");
            }
            catch (Exception ex) { reportError("MultiSelectGrid.aspx","OnCategorySelected",ex,3); }
            finally { OnValidateForm(null, EventArgs.Empty); }
        }
        protected void OnValidateForm(object sender, EventArgs e) {
            //Set state
            try {
            }
            catch (Exception ex) { reportError("MultiSelectGrid.aspx", "OnValidateForm", ex, 3); }
        }
        protected void OnCommand(object sender, CommandEventArgs e) {
            //
            try {
                switch (e.CommandName) {
                    case "Save":
                        Page.Validate();
                        if (Page.IsValid) {
                            //Save deleted categories
                            this.txtResults.Text = "";
                            string results = "";
                            DataTable tblremoved = this.mCategories.GetChanges(DataRowState.Deleted);
                            if (tblremoved != null && tblremoved.Rows.Count > 0) {
                                foreach (DataRow row in tblremoved.Rows) 
                                    results += "DeleteCategory(" + row[0,DataRowVersion.Original].ToString() + ", " + row[1,DataRowVersion.Original].ToString() + ")\r\n";
                            }

                            //Save added categories
                            DataTable tbladded = this.mCategories.GetChanges(DataRowState.Added);
                            if (tbladded != null && tbladded.Rows.Count > 0) {
                                foreach (DataRow row in tbladded.Rows) results += "AddCategory(" + row[0].ToString() + ", " + row[1].ToString() + ")\r\n";
                            }

                            //Display results
                            this.txtResults.Text = results;
                        }
                        break;
                }
            }
            catch (Exception ex) { reportError("MultiSelectGrid.aspx", "OnCommand", ex, 4); }
        }
        private void bindCategoryGrid() {
            //
            try {
                //Bind categories
                this.grdCategories.DataSource = getCategories();
                this.grdCategories.DataBind();

                //Check current categories for this pub
                DataTable cats = this.mCategories;
                for (int j = 0;j < this.grdCategories.Rows.Count;j++) {
                    CheckBox chkSelect = (CheckBox)this.grdCategories.Rows[j].FindControl("chkSelect");
                    //chkSelect.Checked = cats.Select("CategoryID='" + this.grdCategories.Rows[j].Cells[1].Text + "'").Length > 0;  //NOTE: Can go by cell value but then column needs to be visible
                    chkSelect.Checked = cats.Select("CategoryID='" + this.grdCategories.DataKeys[j].Value.ToString() + "'").Length > 0;
                }
            }
            catch (Exception ex) { reportError("MultiSelectGrid.aspx", "bindCategories", ex, 3); }
        }
        private DataTable getCategories() { 
            //
            DataTable cats = new DataTable();
            cats.TableName = "CategoryTable";
            cats.Columns.AddRange(new DataColumn[] { new DataColumn("CategoryID"),new DataColumn("Description") });

            cats.Rows.Add(new object[] { "0","Unknown" });
            cats.Rows.Add(new object[] { "1","School and Campus Safety" });
            cats.Rows.Add(new object[] { "2","Community Partnerships" });
            cats.Rows.Add(new object[] { "3","Nonviolent Crime" });
            cats.Rows.Add(new object[] { "4","Police Operations" });
            cats.Rows.Add(new object[] { "5","Homeland Security" });
            cats.Rows.Add(new object[] { "6","Technology" });
            cats.Rows.Add(new object[] { "7","Alternatives to Incarceration" });
            cats.Rows.Add(new object[] { "8","Data and Analysis" });
            cats.Rows.Add(new object[] { "9","Other" });
            return cats;

        }
        private DataTable getPublicationCategories() { 
            //
            DataTable cats = new DataTable();
            cats.TableName = "CategoryTable";
            cats.Columns.AddRange(new DataColumn[] { new DataColumn("PublicationID"),new DataColumn("CategoryID"),new DataColumn("Description") });
            cats.Rows.Add(new object[] { "100","6","Technology" });
            cats.AcceptChanges();
            return cats;

        }
        private void reportError(string pageName, string methodName, Exception ex, int logLevel) {
            //
        }
    }
}