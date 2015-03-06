<%@ Page Title="Calendar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Treeview.aspx.cs" Inherits="VS13.Treeview" %>

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

<div class="row">
    <div class="col-md-3 treeview">
        <div>Arrows</div>
        <asp:TreeView ID="TreeView0" runat="server" ImageSet="Arrows" Width="100%" DataSourceID="xmlRpts" Target="_self" PopulateNodesFromClient="False" EnableTheming="True" ExpandDepth="1" >
            <DataBindings>
                <asp:TreeNodeBinding DataMember="reports" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="department" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="report" TextField="Text" ValueField="Value" NavigateUrlField="NavigateUrl" ToolTipField="ToolTip" />
            </DataBindings>
        </asp:TreeView>
    </div>
    <div class="col-md-3 treeview">
        <div>BulletedList</div>
        <asp:TreeView ID="TreeView1" runat="server" ImageSet="BulletedList" Width="100%" DataSourceID="xmlRpts" Target="_self" PopulateNodesFromClient="False" EnableTheming="True" ExpandDepth="1" >
            <DataBindings>
                <asp:TreeNodeBinding DataMember="reports" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="department" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="report" TextField="Text" ValueField="Value" NavigateUrlField="NavigateUrl" ToolTipField="ToolTip" />
            </DataBindings>
        </asp:TreeView>
    </div>
    <div class="col-md-3 treeview">
        <div>Contacts</div>
        <asp:TreeView ID="TreeView2" runat="server" ImageSet="Contacts" Width="100%" DataSourceID="xmlRpts" Target="_self" PopulateNodesFromClient="False" EnableTheming="True" ExpandDepth="1" >
            <DataBindings>
                <asp:TreeNodeBinding DataMember="reports" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="department" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="report" TextField="Text" ValueField="Value" NavigateUrlField="NavigateUrl" ToolTipField="ToolTip" />
            </DataBindings>
        </asp:TreeView>
    </div>
    <div class="col-md-3 treeview">
        <div>Events</div>
        <asp:TreeView ID="TreeView3" runat="server" ImageSet="Events" Width="100%" DataSourceID="xmlRpts" Target="_self" PopulateNodesFromClient="False" EnableTheming="True" ExpandDepth="1" >
            <DataBindings>
                <asp:TreeNodeBinding DataMember="reports" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="department" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="report" TextField="Text" ValueField="Value" NavigateUrlField="NavigateUrl" ToolTipField="ToolTip" />
            </DataBindings>
        </asp:TreeView>
    </div>
</div>
<div class="row">
    <div class="col-md-3 treeview">
        <div>Faq</div>
        <asp:TreeView ID="TreeView4" runat="server" ImageSet="Faq" Width="100%" DataSourceID="xmlRpts" Target="_self" PopulateNodesFromClient="False" EnableTheming="True" ExpandDepth="1" >
            <DataBindings>
                <asp:TreeNodeBinding DataMember="reports" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="department" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="report" TextField="Text" ValueField="Value" NavigateUrlField="NavigateUrl" ToolTipField="ToolTip" />
            </DataBindings>
        </asp:TreeView>
    </div>
    <div class="col-md-3 treeview">
        <div>Inbox</div>
        <asp:TreeView ID="TreeView5" runat="server" ImageSet="Inbox" Width="100%" DataSourceID="xmlRpts" Target="_self" PopulateNodesFromClient="False" EnableTheming="True" ExpandDepth="1" >
            <DataBindings>
                <asp:TreeNodeBinding DataMember="reports" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="department" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="report" TextField="Text" ValueField="Value" NavigateUrlField="NavigateUrl" ToolTipField="ToolTip" />
            </DataBindings>
        </asp:TreeView>
    </div>
    <div class="col-md-3 treeview">
        <div>Msdn</div>
        <asp:TreeView ID="TreeView6" runat="server" ImageSet="Msdn" Width="100%" DataSourceID="xmlRpts" Target="_self" PopulateNodesFromClient="False" EnableTheming="True" ExpandDepth="1" >
            <DataBindings>
                <asp:TreeNodeBinding DataMember="reports" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="department" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="report" TextField="Text" ValueField="Value" NavigateUrlField="NavigateUrl" ToolTipField="ToolTip" />
            </DataBindings>
        </asp:TreeView>
    </div>
    <div class="col-md-3 treeview">
        <div>News</div>
        <asp:TreeView ID="TreeView7" runat="server" ImageSet="News" Width="100%" DataSourceID="xmlRpts" Target="_self" PopulateNodesFromClient="False" EnableTheming="True" ExpandDepth="1" >
            <DataBindings>
                <asp:TreeNodeBinding DataMember="reports" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="department" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="report" TextField="Text" ValueField="Value" NavigateUrlField="NavigateUrl" ToolTipField="ToolTip" />
            </DataBindings>
        </asp:TreeView>
    </div>
</div>
<div class="row">
    <div class="col-md-3 treeview">
        <div>Simple</div>
        <asp:TreeView ID="TreeView8" runat="server" ImageSet="Simple" Width="100%" DataSourceID="xmlRpts" Target="_self" PopulateNodesFromClient="False" EnableTheming="True" ExpandDepth="1" >
            <DataBindings>
                <asp:TreeNodeBinding DataMember="reports" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="department" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="report" TextField="Text" ValueField="Value" NavigateUrlField="NavigateUrl" ToolTipField="ToolTip" />
            </DataBindings>
        </asp:TreeView>
    </div>
    <div class="col-md-3 treeview">
        <div>Simple2</div>
        <asp:TreeView ID="TreeView9" runat="server" ImageSet="Simple2" Width="100%" DataSourceID="xmlRpts" Target="_self" PopulateNodesFromClient="False" EnableTheming="True" ExpandDepth="1" >
            <DataBindings>
                <asp:TreeNodeBinding DataMember="reports" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="department" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="report" TextField="Text" ValueField="Value" NavigateUrlField="NavigateUrl" ToolTipField="ToolTip" />
            </DataBindings>
        </asp:TreeView>
    </div>
    <div class="col-md-3 treeview">
        <div>WindowsHelp</div>
        <asp:TreeView ID="TreeView10" runat="server" ImageSet="WindowsHelp" Width="100%" DataSourceID="xmlRpts" Target="_self" PopulateNodesFromClient="False" EnableTheming="True" ExpandDepth="1" >
            <DataBindings>
                <asp:TreeNodeBinding DataMember="reports" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="department" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="report" TextField="Text" ValueField="Value" NavigateUrlField="NavigateUrl" ToolTipField="ToolTip" />
            </DataBindings>
        </asp:TreeView>
    </div>
    <div class="col-md-3 treeview">
        <div>XPFileExplorer</div>
        <asp:TreeView ID="TreeView11" runat="server" ImageSet="XPFileExplorer" Width="100%" DataSourceID="xmlRpts" Target="_self" PopulateNodesFromClient="False" EnableTheming="True" ExpandDepth="1" >
            <DataBindings>
                <asp:TreeNodeBinding DataMember="reports" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="department" TextField="Text" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="report" TextField="Text" ValueField="Value" NavigateUrlField="NavigateUrl" ToolTipField="ToolTip" />
            </DataBindings>
        </asp:TreeView>
    </div>
</div>
<asp:XmlDataSource ID="xmlRpts" runat="server" DataFile="~/App_Data/Reports.xml" EnableCaching="true" CacheExpirationPolicy="Absolute" CacheDuration="Infinite" />
</asp:Content>
