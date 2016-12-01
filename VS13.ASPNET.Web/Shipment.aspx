<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shipment.aspx.cs" Inherits="VS13.Shipment" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shipment</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/jscript" src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.2.js"></script>
    <script type="text/jscript" src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.3/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.3/themes/blitzer/jquery-ui.css" />
    <webopt:BundleReference runat="server" Path="~/Content/css" />
</head>
<body>
    <script type="text/jscript">
        $(document).ready(function () {
            $("#<%=txtShipDate.ClientID %>").datepicker({ minDate: +1, maxDate: +30, beforeShowDay: checkDate });
            function checkDate(date) {
                var day = date.getDay();
                return (day != 0 && day != 6) ? [true] : [false];
            }
        });

        function selectShipper() {
            var result = window.showModalDialog('Shippers.aspx?clientname=<%=this.mClientName %>&clientnumber=<%=this.mClientNumber %>', '', 'dialogWidth:940px;dialogHeight:600px;center:yes;resizable:yes;scroll:yes;status:no;unadorned:yes');
            if (result != null) alert(result); else alert("Cancelled");
        }
    </script>
    <form id="form1" runat="server">
    <div class="subtitle">Shipment for <asp:Label ID="lblClientName" runat="server" Text="" /></div>
    <div>
        <table>
            <tr><td class="label">Ship Date</td>
                <td class="input"><asp:TextBox ID="txtShipDate" runat="server" Width="100px" /></td>
                <td>&nbsp;</td>
            </tr>
            <tr><td class="label">Shipper</td>
                <td class="input"><asp:TextBox ID="txtShipper" runat="server" Width="300px" Height="75px" Rows="3" /></td>
                <td><a href="" onclick="selectShipper(); return false;" title="Select a shipper.">&nbsp;Select</a></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
