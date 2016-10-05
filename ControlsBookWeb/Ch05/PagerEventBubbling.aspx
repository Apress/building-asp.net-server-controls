<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Page language="c#" Codebehind="PagerEventBubbling.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch05.PagerEventBubbling" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch05" Assembly="ControlsBookLib" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
   <HEAD>
      <title>Ch05 Pager Event Bubbling</title>
      <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
      <meta name="CODE_LANGUAGE" Content="C#">
      <meta name="vs_defaultClientScript" content="JavaScript">
      <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
   </HEAD>
   <body MS_POSITIONING="FlowLayout">
      <form id="PagerEventBubbling" method="post" runat="server">
         <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber="5" ChapterTitle="Event-based Programming" />
         <h3>Ch05 Pager Event Bubbling</h3>
         <apress:pager id="pager1" Display="Button" runat="server"></apress:pager><br>
         <br>
         <h3>Direction:&nbsp;<asp:Label ID="DirectionLabel" Runat="server"></asp:Label></h3>
         <apress:pager id="pager2" runat="server" Display="Hyperlink"></apress:pager><br>
         <br>
         <apressUC:ControlsBookFooter id="Footer" runat="server" />
      </form>
   </body>
</HTML>
