<%@ Page language="c#" Codebehind="MCTextBoxDemo.aspx.cs" Inherits="ControlsBookMobile.Ch11.MCTextBox" AutoEventWireup="false" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Register TagPrefix="ApressMC" Namespace="ControlsBookLib.Ch11" Assembly="ControlsBookLib" %>
<HEAD>
  <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
  <meta content="C#" name="CODE_LANGUAGE">
  <meta content="http://schemas.microsoft.com/Mobile/Page" name="vs_targetSchema">
</HEAD>
<body>
  <mobile:form id="Form1" runat="server">
    <mobile:Label id="Label1" runat="server">Change the value:</mobile:Label>
    <ApressMC:MCTextBox id="MCTextBox1" runat="server" Text="Hi There!" Maxlength="15" Numeric="False" Password="False"
      Size="10"></ApressMC:MCTextBox>
    <mobile:Command id="Command1" runat="server">Command</mobile:Command>
    <mobile:Label id="ChangeLabel" runat="server">Message</mobile:Label>
  </mobile:form>
</body>
