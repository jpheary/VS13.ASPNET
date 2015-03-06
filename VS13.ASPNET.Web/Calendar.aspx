<%@ Page Title="Calendar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="VS13.Calendar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/jscript" src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.2.js"></script>
    <script type="text/jscript" src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.3/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.3/themes/smoothness/jquery-ui.css" />
	<style type="text/css" media="screen">
		<!-- 
        .title {
            margin: 25px 0px 25px 0px; padding: 0px 0px 0px 0px; font-size: 24px; font-weight: bold; text-align: center; color: #000000;
        }
        .label {
            width: 100px; padding: 0px 10px 0px 0px; font-size: 12px; font-weight: bold; text-align: right; color: #000000;
        }
        .input {
            text-align: left;
        }
        -->
	</style>
    <script type="text/jscript">
        $(document).ready(function () {
            $("#<%=txtCalDate.ClientID %>").datepicker({ minDate: +1, maxDate: +30, beforeShowDay: $.datepicker.noWeekends });

            $("#<%=txtFrom.ClientID %>").datepicker({
                defaultDate: "1", onClose: function (selectedDate) { $("#<%=txtTo.ClientID %>").datepicker("option", "minDate", selectedDate); }
            });
            $("#<%=txtTo.ClientID %>").datepicker({
                defaultDate: "1", onClose: function (selectedDate) { $("#<%=txtFrom.ClientID %>").datepicker("option", "maxDate", selectedDate); }
            });
        });
    </script>
    <div class="title">jQuery Calendar</div>
    <table>
        <tr><td class="label">Date:</td><td class="input"><asp:TextBox ID="txtCalDate" runat="server" Width="100px" /></td></tr>
    </table>
    <div class="title">jQuery From-To Calendar</div>
    <table>
        <tr><td class="label">From:</td><td class="input"><asp:TextBox ID="txtFrom" runat="server" Width="100px" /></td></tr>
        <tr><td class="label">To:</td><td class="input"><asp:TextBox ID="txtTo" runat="server" Width="100px" /></td></tr>
    </table>
</asp:Content>
