<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Page language="c#" Codebehind="ValidationControls.aspx.cs" Inherits="ControlsBookMobile.Ch10.ValidationControls" AutoEventWireup="false" %>
<HEAD>
  <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
  <meta name="CODE_LANGUAGE" content="C#">
  <meta name="vs_targetSchema" content="http://schemas.microsoft.com/Mobile/Page">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
  <mobile:Form id="InputForm" runat="server">
    <mobile:Label id="Label1" runat="server">Enter a number between 1 and 10</mobile:Label>
    <mobile:TextBox id="NumberTextBox" runat="server"></mobile:TextBox>
    <mobile:Command id="Command1" runat="server">Submit</mobile:Command>
    <mobile:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Number entry is required."
      ControlToValidate="NumberTextBox"></mobile:RequiredFieldValidator>
    <mobile:RangeValidator id="RangeValidator1" runat="server" ErrorMessage="Number must be between 1 and 10."
      ControlToValidate="NumberTextBox" MaximumValue="10" MinimumValue="1" Type="Integer"></mobile:RangeValidator>
  </mobile:Form>
  <mobile:Form id="ErrorForm" runat="server">
    <P>An Error Occurred:
<mobile:ValidationSummary id="ValidationSummary1" runat="server" FormToValidate="InputForm"></mobile:ValidationSummary></P>
  </mobile:Form>
  <mobile:Form id="SuccessForm" runat="server">You have successfully entered:
<mobile:Label id="ResultNumber" runat="server"></mobile:Label></mobile:Form>
</body>
