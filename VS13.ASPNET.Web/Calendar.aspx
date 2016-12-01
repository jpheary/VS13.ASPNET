<%@ Page Title="Calendar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="VS13.Calendar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/jscript">
        var daysback = -30, daysforward = 0, daysspread = 7;
        $(function () {
            $("#<%=txtDate.ClientID %>").datepicker({ minDate: -30, maxDate: 0, beforeShowDay: $.datepicker.noWeekends });

            $("#<%=txtFrom.ClientID %>").datepicker({
                minDate: daysback, maxDate: 0, defaultDate: 0,
                onClose: function (selectedDate, instance) {
                    $("#<%=txtTo.ClientID %>").datepicker("option", "minDate", selectedDate);

                    var date = $.datepicker.parseDate("mm/dd/yy", selectedDate, instance.settings);
                    date.setDate(date.getDate() + daysspread);
                    var todate = $("#<%=txtTo.ClientID %>").datepicker("getDate");
                    if (todate > date) $("#<%=txtTo.ClientID %>").datepicker("setDate", date);
                }
            });
            $("#<%=txtTo.ClientID %>").datepicker({
                minDate: 0, maxDate: daysforward, defaultDate: 0,
                onClose: function (selectedDate, instance) {
                    $("#<%=txtFrom.ClientID %>").datepicker("option", "maxDate", selectedDate);

                    var date = $.datepicker.parseDate("mm/dd/yy", selectedDate, instance.settings);
                    date.setDate(date.getDate() - daysspread);
                    var fromdate = $("#<%=txtFrom.ClientID %>").datepicker("getDate");
                    if (fromdate < date) $("#<%=txtFrom.ClientID %>").datepicker("setDate", date);
                }
            });
        });
    </script>
    <div style="margin:50px 0px 0px 0px; font-size:24px">jQuery Calendar</div>
    <div style="margin:50px 0px 0px 25px">
        <label for="txtDate">Date&nbsp;</label>
        <asp:TextBox ID="txtDate" runat="server" Width="100px" />
    </div>
    <hr />
    <div style="margin:50px 0px 0px 0px; font-size:24px">jQuery From-To Calendar</div>
    <div style="margin:50px 0px 0px 25px">
        <label for="txtFrom">From&nbsp;</label>
        <asp:TextBox ID="txtFrom" runat="server" Width="100px" AutoPostBack="true" OnTextChanged="OnDatesChanged" />
        <label for="txtTo">&nbsp;-&nbsp;</label>
        <asp:TextBox ID="txtTo" runat="server" Width="100px" AutoPostBack="true" OnTextChanged="OnDatesChanged" />
    </div>
   <br /><br />
    <asp:UpdatePanel runat="server" ID="upnlDates" UpdateMode="Conditional">
    <ContentTemplate>
        <table>
            <tr><td>The selected date range is:&nbsp;</td><td><asp:Label ID="lblDates" runat="server" Text="" /></td></tr>
        </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="txtFrom" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtTo" EventName="TextChanged" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>
