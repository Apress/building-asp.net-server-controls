<%@ Page language="c#" Codebehind="ListControls.aspx.cs" Inherits="ControlsBookMobile.Ch10.ListControls" AutoEventWireup="false" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<HEAD>
   <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
   <meta content="C#" name="CODE_LANGUAGE">
   <meta content="http://schemas.microsoft.com/Mobile/Page" name="vs_targetSchema">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
   <mobile:form id="MainForm" runat="server">
      <mobile:Link id="Link1" runat="server" NavigateUrl="#ListForm">List control</mobile:Link>
      <mobile:Link id="Link2" runat="server" NavigateUrl="#SelectionListForm">SelectionList control</mobile:Link>
      <mobile:Link id="Link3" runat="server" NavigateUrl="#ObjectListForm">ObjectList control</mobile:Link>
   </mobile:form>
   <mobile:form id="ListForm" runat="server">
      <mobile:Label id="ListResult" runat="server"></mobile:Label>
      <mobile:List id="List1" runat="server" Decoration="Bulleted"></mobile:List>
      <mobile:Link id="Link4" runat="server" NavigateUrl="#MainForm">Back</mobile:Link>
   </mobile:form>
   <mobile:form id="SelectionListForm" runat="server">
      <mobile:Label id="SelectionListResults" runat="server"></mobile:Label>
      <mobile:SelectionList id="SelectionList1" runat="server" SelectType="MultiSelectListBox"></mobile:SelectionList>
      <mobile:Command id="SelListCmd" runat="server">Submit</mobile:Command>
      <mobile:Link id="Link5" runat="server" NavigateUrl="#MainForm">Back</mobile:Link>
   </mobile:form>
   <mobile:form id="ObjectListForm" runat="server">
      <mobile:ObjectList id="ObjectList1" runat="server" CommandStyle-StyleReference="subcommand" LabelStyle-StyleReference="title"></mobile:ObjectList>
      <mobile:Link id="Link6" runat="server" NavigateUrl="#MainForm">Back</mobile:Link>
   </mobile:form>
</body>
