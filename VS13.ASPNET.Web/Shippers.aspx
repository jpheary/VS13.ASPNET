<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shippers.aspx.cs" Inherits="VS13.Shippers" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shippers</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/jscript" src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.2.js"></script>
    <script type="text/jscript" src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.3/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.3/themes/blitzer/jquery-ui.css" />
    <script type="text/jscript" src="scripts/jquery.inputmask.js"></script>
    <link rel="stylesheet" href="content/site.css" />
</head>
<body>
<form id="idForm" runat="server" >
    <asp:ScriptManager ID="smPage" runat="server" EnableCdn="false" EnablePartialRendering="true" AsyncPostBackTimeout="600" ScriptMode="Auto" LoadScriptsBeforeUI="false"></asp:ScriptManager>
    <script type="text/jscript">
        $(document).ready(function () {
            $("#<%=txtContactPhone.ClientID %>").inputmask({ "mask": "999-999-9999" });
        });

        function returnShipperID() {
            window.returnValue = "SH001";
            window.close();
        }
    </script>
    <div id="page">
        <div id="header">
            <div id="logo">
                <img id="Img1" runat="server" src="~/Images/logo.gif" alt="Corporate logo" style="border: 0;" />
                <asp:UpdatePanel runat="server" ID="pnlMsg" UpdateMode="Always"><ContentTemplate><asp:Label ID="lblMsg" runat="server" Text="" /></ContentTemplate></asp:UpdatePanel>
            </div>
        </div>
        <div id="head"></div>
        <asp:MultiView runat="server" ID="mvwPage" ActiveViewIndex="0">
        <asp:View ID="vwShippers" runat="server">
            <div class="subtitle">Shippers for <asp:Label ID="lblShippersClient" runat="server" Text="" /></div>
            <br />
            <div style="width:880px; height:250px; margin:0px 0px 0px 0px; padding:0px 0px 0px 0px; overflow:scroll; white-space:nowrap;">
                <asp:UpdatePanel runat="server" ID="upnlShippers" UpdateMode="Conditional">
                <ContentTemplate>
                <asp:GridView ID="grdShippers" runat="server" Width="100%" DataSourceID="odsShippers" DataKeyNames="ShipperNumber" AutoGenerateColumns="false" Font-Size="11px" BorderStyle="Inset" BorderWidth="1px" CellPadding="2" CellSpacing="0" GridLines="Both" BackColor="White" OnSelectedIndexChanged="OnShipperSelected" >
                    <HeaderStyle BorderStyle="None" BorderWidth="0px" BorderColor="Window" BackColor="#d4d0c8" ForeColor="#000000" Wrap="True" />
                    <FooterStyle BackColor="#ffffff" ForeColor="#000000" Wrap="false" />
                    <RowStyle BorderStyle="None" BorderWidth="0px" />
                    <SelectedRowStyle BorderStyle="None" BorderWidth="0px" BackColor="#0a246a" ForeColor="#ffffff" />
                    <EmptyDataRowStyle BackColor="#ffffff" ForeColor="#000000" Wrap="false"  />
                    <Columns>
                        <asp:CommandField HeaderStyle-Width="16px" ButtonType="Image" ShowSelectButton="True" SelectImageUrl="~/Images/select.gif" />
                        <asp:BoundField DataField="ShipperNumber" HeaderText="Number" ItemStyle-Wrap="False" ItemStyle-Width="50px" Visible="True" />
                        <asp:BoundField DataField="ClientNumber" HeaderText="Client#" ItemStyle-Wrap="False" ItemStyle-Width="50px" Visible="False" />
                        <asp:BoundField DataField="ClientName" HeaderText="Client" ItemStyle-Wrap="False" ItemStyle-Width="100px" Visible="False" />
                        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Wrap="False" ItemStyle-Width="125px" Visible="True" />
                        <asp:BoundField DataField="AddressLine1" HeaderText="Address" ItemStyle-Wrap="False" ItemStyle-Width="125px" Visible="True" />
                        <asp:BoundField DataField="City" HeaderText="City" ItemStyle-Wrap="False" ItemStyle-Width="75px" Visible="True" />
                        <asp:BoundField DataField="State" HeaderText="State" ItemStyle-Wrap="False" ItemStyle-Width="40px" Visible="True" />
                        <asp:BoundField DataField="Zip" HeaderText="Zip" ItemStyle-Wrap="False" ItemStyle-Width="50px" Visible="True" />
                        <asp:BoundField DataField="ContactName" HeaderText="Contact" ItemStyle-Wrap="False" ItemStyle-Width="75px" Visible="True" />
                        <asp:BoundField DataField="ContactPhone" HeaderText="Phone" ItemStyle-Wrap="False" ItemStyle-Width="75px" Visible="True" />
                        <asp:BoundField DataField="ContactEmail" HeaderText="Email" ItemStyle-Wrap="False" ItemStyle-Width="100px" Visible="True" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsShippers" runat="server" TypeName="VS13.ShipperGateway" SelectMethod="ViewShippers">
                    <SelectParameters>
                        <asp:Parameter Name="clientNumber" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <br />
            <div>
                <asp:UpdatePanel ID="upnlShippersCommands" runat="server" UpdateMode="Always" >
                <ContentTemplate>
                <asp:Button ID="btnNew" runat="server" Text="  New  " CssClass="submit" CommandName="New" OnCommand="OnCommand" />
                <asp:Button ID="btnOk" runat="server" Text="  Ok  " CssClass="submit" OnClientClick="returnShipperID();" />
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="submit" OnClientClick="javascript: window.close();" />
                </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </asp:View>
        <asp:View ID="vwShipper" runat="server">
            <div class="subtitle">Shipper for <asp:Label ID="lblClientName" runat="server" Text="" /></div>
            <div style="float:left">
                <table>
                    <tr><td class="label">Name</td></tr>
                    <tr><td><asp:TextBox ID="txtName" runat="server" Width="275px" MaxLength="40" ReadOnly="true" /></td></tr>
                    <tr><td class="label">Address</td></tr>
                    <tr><td><asp:UpdatePanel runat="server" ID="upnlAddress" UpdateMode="Always" RenderMode="Inline"><ContentTemplate>
                            <asp:TextBox ID="txtStreet" runat="server" Width="275px" MaxLength="40" onchange="javascript: updateMap();" />
                            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtCity" runat="server" Width="175px" MaxLength="40" onchange="javascript: updateMap();" />
                            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtState" runat="server" Width="50px" MaxLength="2" onchange="javascript: updateMap();" />
                            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtZip" runat="server" Width="75px" MaxLength="5" onchange="javascript: updateMap();" />
                    </ContentTemplate></asp:UpdatePanel></td></tr>
                    <tr><td><div class="sublabel" style="float:left; width:275px; margin-right:17px">Street</div><div class="sublabel" style="float:left; width:175px; margin-right:17px">City</div><div class="sublabel" style="float:left; width:50px; margin-right:17px">State</div><div class="sublabel" style="float:left; width:75px;">Zip</div></td></tr>
                    <tr><td class="label">Contact Info</td></tr>
                    <tr><td><asp:TextBox ID="txtContactName" runat="server" Width="275px" MaxLength="40" />
                            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtContactPhone" runat="server" Width="100px" MaxLength="24" />
                            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtContactEmail" runat="server" Width="175px" MaxLength="50" />
                    </td></tr>
                    <tr><td><div class="sublabel" style="float:left; width:275px; margin-right:17px">Name</div><div class="sublabel" style="float:left; width:100px; margin-right:17px">Phone Number</div><div class="sublabel" style="float:left; width:175px">Email Address</div></td></tr>
                </table>
                <br />
                <br />
                <div>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="vgShipper" CssClass="submit" CommandName="Submit" OnCommand="OnCommand" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="submit" CommandName="Cancel" OnCommand="OnCommand" />
                </div>
                <br />
            </div>
            <div style="float:left; margin-left:25px; margin-top:10px; padding:0 0 0 0; border-style:solid; border-color:#ee2a24">
                <div id='myMap' style="position:relative; width:265px; height:325px"></div>
            </div>
            <div style="clear:both"></div>

            <script type="text/javascript">
                var map = new VEMap('myMap');
                map.LoadMap();
                updateMap();

                function updateMap() {
                    var street = document.getElementById('<%=txtStreet.ClientID %>').value;
                    var city = document.getElementById('<%=txtCity.ClientID %>').value;
                    var state = document.getElementById('<%=txtState.ClientID %>').value;
                    var zip = document.getElementById('<%=txtZip.ClientID %>').value;

                    var address = street + ' ' + city + ', ' + state + ' ' + zip;
                    MapLocation(address);
                }
                function MyHandleCredentialsError() { alert("The Bing Map credentials are invalid."); }
                function UnloadMap() { if (myMap != null) myMap.Dispose(); }
                function MapLocation(address) {
                    var points = new Array(address);
                    for (var i = 0; i < points.length; i++)
                        map.Find(null, points[i], null, null, 0, 10, false, false, false, true, ProcessStore);
                }
                function ProcessStore(layer, results, places, hasmore) {
                    //Create a custom pin
                    if (places != null && places[0].LatLong != 'Unavailable') {
                        var spec = new VECustomIconSpecification();
                        spec.CustomHTML = "<div style='font-size:8px; border:solid 1px Black; background-color:red; width:8px;'>&nbsp;<div>";
                        var pin = new VEShape(VEShapeType.Pushpin, places[0].LatLong);
                        pin.SetCustomIcon(spec);
                        map.AddShape(pin);
                    }
                }
                function callWebService(url) {
                    //Calls web service with url and callback function; callback will be executed when XMLHttpRequest object returns from web service call
                    var xmlDoc = new XMLHttpRequest();
                    if (xmlDoc) {
                        //Execute synchronous call to web service; asynchronous never returns a readystate > 1 with POST
                        xmlDoc.onreadystatechange = function () { stateChange(xmlDoc); };
                        xmlDoc.open("GET", url, true);
                        //params = "name=" + document.infoForm.name.value + "&email=" + document.infoForm.email.value + "&phone=" + document.infoForm.phone.value + "&company=" + document.infoForm.company.value + "&address=" + document.infoForm.address.value + "&state=" + document.infoForm.state.value + "&options=" + document.infoForm.options.value;
                        //xmlDoc.setRequestHeader("Content-length", params.length);
                        xmlDoc.send(null);
                    }
                    else
                        alert("Unable to create XMLHttpRequest object.");
                }
                function stateChange(xmlDoc) {
                    //Updates readystate by callback
                    if (xmlDoc.readyState == 4) {
                        var text = "";
                        if (xmlDoc.status == 200) {
                            //sSelect node containing data
                            var nd = xmlDoc.responseXML.getElementsByTagName("mail");
                            if (nd && nd.length == 1) {
                                //IE use .text, others .textContent
                                text = !nd[0].text ? nd[0].textContent : nd[0].text;
                                if (text != "") alert(text); else alert("Web service call failed: " + text);
                            }
                        }
                        else
                            alert("Bad response: status code=" + xmlDoc.status);
                    }
                }
            </script>
        </asp:View>
        </asp:MultiView>
    </div>
</form>
</body>
</html>
