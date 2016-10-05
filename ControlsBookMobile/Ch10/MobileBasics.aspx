<%@ Page language="c#" Codebehind="MobileBasics.aspx.cs" Inherits="ControlsBookMobile.Ch10.MobileBasics" AutoEventWireup="false" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<HEAD>
   <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
   <meta name="CODE_LANGUAGE" content="C#">
   <meta name="vs_targetSchema" content="http://schemas.microsoft.com/Mobile/Page">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
   <mobile:Form id="Form1" runat="server">
      <mobile:Label id="Label1" runat="server">Enter your name:</mobile:Label>
      <mobile:TextBox id="TextBox1" runat="server"></mobile:TextBox>
      <mobile:Command id="cmdHello" runat="server">Submit</mobile:Command>
   </mobile:Form>
   <mobile:Form id="Form2" runat="server">
      <mobile:Label id="Label2" runat="server">Label</mobile:Label>
      <mobile:Link id="Link1" runat="server" NavigateUrl="#Form1">Back Link</mobile:Link>
   </mobile:Form>
</body>
