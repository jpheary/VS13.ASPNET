<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TimeSpinner.aspx.cs" Inherits="VS13.TimeSpinner" %>

<asp:Content ID="cMeta" ContentPlaceHolderID="cphMeta" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/jscript">
        $.widget("ui.timespinner", $.ui.spinner, {
            options: { step: 60000, page: 60 }, 
            _parse: function (value) {
                if (typeof value === "string") {
                    if (Number(value) == value) {
                        return Number(value);
                    }
                    return +Globalize.parseDate(value);
                }
                return value;
            },
            _format: function (value) {
                return Globalize.format(new Date(value), "t");
            }
        });
        $(document).ready(function () {
            $("#spinner").timespinner();

            $("#<%=txtFrom.ClientID %>").timespinner({
                change: function (event, ui) {
                    var f = $("#<%=txtFrom.ClientID %>").timespinner("value");
                    var t = $("#<%=txtTo.ClientID %>").timespinner("value");
                    if (f > t) {
                        $("#<%=txtFrom.ClientID %>").timespinner("value", t);
                        alert("From cannot be after To.");
                    }
                }
            });
            $("#<%=txtTo.ClientID %>").timespinner({
                change: function (event, ui) {
                    var f = $("#<%=txtFrom.ClientID %>").timespinner("value");
                    var t = $("#<%=txtTo.ClientID %>").timespinner("value");
                    if (t < f) {
                        $("#<%=txtTo.ClientID %>").timespinner("value", f);
                        alert("To cannot be before From.");
                    }
                }
            });
        });
    </script>
    <div class="timespinner">
        <div class="subtitle">jQuery Time Spinner</div>
        <p>A simple time spinner.</p>
        <label for="spinner">Time&nbsp;</label>
        <input id="spinner" type="text" name="spinner" value="08:30 PM">
    </div>
    <hr />
    <div class="timespinner">
        <div class="subtitle">jQuery Time Window Spinner</div>
        <p>A simple time window spinner.</p>
        <label for="txtFrom">Window&nbsp;</label>
        <asp:TextBox ID="txtFrom" runat="server" AutoPostBack="true" OnTextChanged="OnWindowChanged" />
        &nbsp;-&nbsp;
        <asp:TextBox ID="txtTo" runat="server" AutoPostBack="true" OnTextChanged="OnWindowChanged" />
        <br /><br />
        <asp:UpdatePanel runat="server" ID="upnlWindow" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr><td>The selected time window is:&nbsp;</td><td><asp:Label ID="lblWindow" runat="server" Text="" /></td></tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtFrom" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtTo" EventName="TextChanged" />
        </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
