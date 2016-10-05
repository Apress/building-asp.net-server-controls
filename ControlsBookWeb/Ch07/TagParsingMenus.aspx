<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Page language="c#" Codebehind="TagParsingMenus.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch07.TagParsingMenuControls" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch07" Assembly="ControlsBookLib" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
   <HEAD>
      <title>Ch07 Tag-Parsing Menu Controls</title>
      <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
      <meta content="C#" name="CODE_LANGUAGE">
      <meta content="JavaScript" name="vs_defaultClientScript">
      <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
   </HEAD>
   <body MS_POSITIONING="FlowLayout">
      <form id="TagParsingMenuControls" method="post" runat="server">
         <apressuc:controlsbookheader id="Header" runat="server" ChapterTitle="Templates and Databinding" ChapterNumber="7"></apressuc:controlsbookheader>
         <h3>Ch07 Tag-Parsing Menu Controls</h3>
         <apress:tagdatamenu id="menu1" runat="server">
            <apress:MenuItemData Title="Apress" ImageUrl="" Url="http://www.apress.com" Target=""></apress:MenuItemData>
            <apress:MenuItemData Title="Microsoft" ImageUrl="" Url="http://www.microsoft.com" Target=""></apress:MenuItemData>
            <apress:MenuItemData Title="GotDotNet" ImageUrl="" Url="http://www.gotdotnet.com" Target=""></apress:MenuItemData>
         </apress:tagdatamenu>
         <apress:buildermenu id="menu2" runat="server">
            <data title="Apress" url="http://www.apress.com" imageurl="" target="" />
            <data title="Microsoft" url="http://www.microsoft.com" imageurl="" target="" />
            <data title="GotDotNet" url="http://www.gotdotnet.com" imageurl="" target="" />
         </apress:buildermenu>
         <apressuc:controlsbookfooter id="Footer" runat="server"></apressuc:controlsbookfooter></form>
   </body>
</HTML>
