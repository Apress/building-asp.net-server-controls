<%@ Page language="c#" Codebehind="ImageAdCalendar.aspx.cs" Inherits="ControlsBookMobile.Ch10.ImageAddCalendar" AutoEventWireup="false" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<HEAD>
   <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
   <meta name="CODE_LANGUAGE" content="C#">
   <meta name="vs_targetSchema" content="http://schemas.microsoft.com/Mobile/Page">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
   <mobile:Form id="MainForm" runat="server">
      <mobile:Link id="Link1" runat="server" NavigateUrl="#ImageAdForm">Image AdRotator Form</mobile:Link>
      <mobile:Link id="Link2" runat="server" NavigateUrl="#CalendarForm">Calendar Form</mobile:Link>
   </mobile:Form>
   <mobile:Form id="ImageAdForm" runat="server">
      <mobile:AdRotator id="AdRotator1" runat="server" AdvertisementFile="ads.xml"></mobile:AdRotator>
      <mobile:Image id="Image1" runat="server" AlternateText="Microsoft" ImageUrl="mslogo.bmp"></mobile:Image>
   </mobile:Form>
   <mobile:Form id="CalendarForm" runat="server">
      <mobile:Label id="CalResult" runat="server"></mobile:Label>
      <mobile:Calendar id="Calendar1" runat="server"></mobile:Calendar>
   </mobile:Form>
</body>
