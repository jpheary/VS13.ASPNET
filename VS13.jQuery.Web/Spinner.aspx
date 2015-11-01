<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Spinner.aspx.cs" Inherits="VS13.Spinner" %>

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
            $("#<%=txtWeight.ClientID %>").spinner({ min: 0, max: 1500 });
            $("#<%=txtInsurance.ClientID %>").spinner({ min: 0, max: 1000, numberFormat: "C", stop: function (event, ui) { reset(); } });
        });
        function isNumeric(control) {
            var val = document.getElementById(control.id).value.replace("$", "");
            if (!$.isNumeric(val)) {
                document.getElementById(control.id).value = '';
                document.getElementById(control.id).focus();
                alert("Numeric values only.");
            }
        }
        function reset() {
            alert("Reset form elements on insurance change.")
        }
    </script>
    <div class="spinner">
        <div class="subtitle">jQuery Integer Spinner</div>
        <p>A simple integer spinner: min=0, max=1500</p>
        <label for="txtWeight">Weight</label><asp:TextBox ID="txtWeight" runat="server" MaxLength="4" onchange="javascript: isNumeric(this);" />
    </div>
    <hr />
    <div class="spinner">
        <div class="subtitle">jQuery Currency Spinner</div>
        <p>A simple currrency spinner: min=$0, max=$1000</p>
        <label for="txtInsurance">Insurance</label><asp:TextBox ID="txtInsurance" runat="server" onchange="javascript: isNumeric(this);" />
    </div>
</asp:Content>
