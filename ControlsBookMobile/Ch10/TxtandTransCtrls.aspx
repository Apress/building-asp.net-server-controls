<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Page language="c#" Codebehind="TxtandTransCtrls.aspx.cs" Inherits="ControlsBookMobile.Ch10.TextandTransCtrls" AutoEventWireup="false" %>
<HEAD>
  <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
  <meta name="CODE_LANGUAGE" content="C#">
  <meta name="vs_targetSchema" content="http://schemas.microsoft.com/Mobile/Page">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
  <mobile:Form id="Form1" runat="server">
    <mobile:Label id="Label1" runat="server">Password</mobile:Label>
    <mobile:TextBox id="TextBox1" runat="server" Password="True"></mobile:TextBox>
    <mobile:Command id="Command1" runat="server">Submit</mobile:Command>
  </mobile:Form>
  <mobile:Form id="Form2" runat="server">
    <mobile:Label id="Label2" runat="server"></mobile:Label>
    <mobile:TextView id="TextView1" runat="server"></mobile:TextView>
    <mobile:PhoneCall id="PhoneCall1" runat="server" PhoneNumber="555-1212" AlternateUrl="http://www.microsoft.com"
      AlternateFormat="{0} ">Contact Microsoft</mobile:PhoneCall>
    <mobile:Link id="Link1" runat="server" NavigateUrl="#Form1">Back Link</mobile:Link>
  </mobile:Form>
</body>
