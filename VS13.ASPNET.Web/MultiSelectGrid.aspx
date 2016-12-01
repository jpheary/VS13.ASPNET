<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultiSelectGrid.aspx.cs" Inherits="VS13.MultiSelectGrid" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Multi-Select Grid</title>
    <style type="text/css">
        body {
            background: #b6b7bc;
            font-size: 0.8em;
            font-family: "Helvetica Neue" , "Lucida Grande" , "Segoe UI" , Arial, Helvetica, Verdana, sans-serif;
            margin: 0px;
            padding: 0px;
            color: #696969;
            background-image: url(/images/background.jpg);
            width: 100%;
        }
        .page {
            width: 950px;
            background-color: #d9e3fc;
            border: 1px solid #496077;
            margin: 0px auto;
        }
        .subtitle  {
            display: block;
            margin: 5px 0px;
            padding: 0px 0px 10px 10px;
            border-bottom: 1px solid #696969;
            color: #203c5d;
            font-size: 1.2em;
            font-weight: 500;
            text-align: left;
        }
        .warehouse {
            width: 600px;
            margin: 0px auto;
        }
        .warehouse p {
            margin: 10px 20px;
        }
       .warehouse fieldset {
            margin: 20px auto;
            padding: 25px 5px 15px 0px;
            border: 1px solid #4e5766;
        }
        .warehouse fieldset legend {
            padding: 0px 5px;
            color: #4e5766;
        }
        .warehouse label {
            display:inline-block;
            width:150px;
            padding: 2px 5px 0px 0px;
            text-align:right;
            vertical-align: top;
            font-weight: bold;
        }
        .services {
            margin: 25px 0px;
            padding: 0px 50px;
            text-align:right;
        }
        .gridviewbody100 {
            height: 200px;
            margin:0px;
            padding:0px;
            border-bottom: 1px solid #c5c7c9;
            overflow-x:auto;
            overflow-y:auto;
            white-space:nowrap;
        }
   </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page">
            <div class="warehouse">
                <div class="subtitle">Multi-Select Grid</div>
                <p>A multi-select grid used to capture a many-to-many relationship, such as associating publications with one or more categories.</p>
                <fieldset>
                    <legend>Publication 100</legend>
                    <label for="lstCategories">Categories</label>
                    <div class="gridviewbody100" style="display:inline-block; width:290px">
                        <asp:GridView ID="grdCategories" runat="server" Width="100%" DataKeyNames="CategoryID" AutoGenerateColumns="False" ShowHeader="false" BorderStyle="Inset" BorderWidth="1px" CellPadding="2" CellSpacing="0" GridLines="Both" BackColor="White"  AllowSorting="True">
                            <HeaderStyle BorderStyle="None" BorderWidth="0px" BorderColor="Window" BackColor="#eeeeee" ForeColor="#000000" Wrap="True" />
                            <SelectedRowStyle BackColor="#203c5d" ForeColor="#ffffff" />
                            <EmptyDataRowStyle BackColor="#ffffff" ForeColor="#000000" Wrap="false"  />
                            <Columns>
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="25px" >
                                    <ItemTemplate><asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="OnCategorySelected" /></ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CategoryID" HeaderText="CatID" ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center" Visible="false" />
                                <asp:BoundField DataField="Description" HeaderText="Description" HeaderStyle-Width="200px" Visible="true" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <br />
                    <label for="txtResults">Results</label><asp:TextBox ID="txtResults" runat="server" TextMode="MultiLine" Rows="5" Width="290px" />
                    <br />
                </fieldset>
                <div class="services">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="true" CommandName="Save" OnCommand="OnCommand" />
               </div>
            </div>
        </div>
    </form>
</body>
</html>