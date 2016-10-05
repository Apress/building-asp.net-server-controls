<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Page language="c#" Codebehind="StyleSheetInline.aspx.cs" Inherits="ControlsBookMobile.Ch11.StyleSheetInline" AutoEventWireup="false" %>
<HEAD>
  <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
  <meta content="C#" name="CODE_LANGUAGE">
  <meta content="http://schemas.microsoft.com/Mobile/Page" name="vs_targetSchema">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
  <mobile:form id="MainForm" runat="server">
    <mobile:Link id="Link1" runat="server" NavigateUrl="#LabelForm">Label Styles</mobile:Link>
    <mobile:Link id="Link2" runat="server" NavigateUrl="#QueryForm">Paging Style</mobile:Link>
  </mobile:form>
  <mobile:form id="LabelForm" runat="server">
    <mobile:Label id="Label3" runat="server" StyleReference="SimpleTextStyle1">Some simple text.(BoldTimes)</mobile:Label>
    <mobile:Label id="Label5" runat="server" StyleReference="title">Some Title text.(title default style)</mobile:Label>
    <mobile:Label id="Label4" runat="server" StyleReference="SimpleTextStyle2">More simple text.(ItalicVerdana)</mobile:Label>
    <mobile:Label id="Label6" runat="server" StyleReference="subcommand">Some subcommand Text.(subcommand default style)</mobile:Label>
    <mobile:Label id="Label7" runat="server" StyleReference="error">Error: Some error text.(error default style)</mobile:Label>
  </mobile:form>
  <mobile:form id="QueryForm" runat="server" StyleReference="QueryStyle">
    <mobile:Label id="Label1" runat="server">Query by Contact Name:</mobile:Label>
    <mobile:TextBox id="NameTextBox" runat="server"></mobile:TextBox>
    <mobile:Command id="QueryCmd" runat="server">Submit</mobile:Command>
  </mobile:form>
  <mobile:form id="ResultsForm" runat="server" Paginate="True" StyleReference="ResultsStyle" PagerStyle-NextPageText="Go To Next"
    PagerStyle-PreviousPageText="Go to Previous">
    <mobile:List id="CustList" runat="server" ItemsPerPage="10" Decoration="Numbered"></mobile:List>
  </mobile:form>
  <mobile:stylesheet id="InlineStyleSheet" runat="server">
    <mobile:Style Font-Size="Small" Font-Name="Times" Font-Bold="True" ForeColor="Black" Wrapping="NoWrap"
      Name="SimpleTextStyle1"></mobile:Style>
    <mobile:Style Font-Size="Small" Font-Name="Verdana" Font-Italic="True" ForeColor="Black" Wrapping="NoWrap"
      Name="SimpleTextStyle2"></mobile:Style>
    <mobile:Style Font-Size="Small" Font-Name="Verdana" Font-Bold="True" ForeColor="Black" Wrapping="NoWrap"
      Name="QueryStyle"></mobile:Style>
    <mobile:Style Font-Size="Small" Font-Name="Tahoma" Font-Bold="False" Font-Italic="True" ForeColor="Black"
      Wrapping="NoWrap" Name="ResultsStyle"></mobile:Style>
  </mobile:stylesheet>
</body>
