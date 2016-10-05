<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Page language="c#" Codebehind="ContainerControls.aspx.cs" Inherits="ControlsBookMobile.Ch10.ContainerControls" AutoEventWireup="false" %>
<HEAD>
  <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
  <meta name="CODE_LANGUAGE" content="C#">
  <meta name="vs_targetSchema" content="http://schemas.microsoft.com/Mobile/Page">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
  <mobile:Form id="PanelForm" runat="server" Paginate="True">
    <mobile:Panel id="QueryPanel" runat="server">
      <mobile:Label id="Label1" runat="server">Query by Contact Name:</mobile:Label>
      <mobile:TextBox id="PanelFormTextBox" runat="server"></mobile:TextBox>
      <mobile:Command id="PanelFormCmd" runat="server">Submit</mobile:Command>
    </mobile:Panel>
    <mobile:Panel id="ResultsPanel" Paginate="True" runat="server" Visible="False">
      <mobile:List id="PanelList" runat="server" Decoration="Numbered" ItemsPerPage="10"></mobile:List>
    </mobile:Panel>
  </mobile:Form>
</body>
