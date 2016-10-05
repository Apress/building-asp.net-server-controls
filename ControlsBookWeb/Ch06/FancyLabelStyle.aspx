<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch06" Assembly="ControlsBookLib" %>
<%@ Page language="c#" Codebehind="FancyLabelStyle.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch06.FancyLabelStyle" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch06 FancyLabelStyle</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <LINK href="WebControlStyle.css" type="text/css" rel="stylesheet">
  </HEAD>
  <body MS_POSITIONING="FlowLayout">
    <form id="FancyLabelStyle" method="post" runat="server">
      <apressuc:controlsbookheader id="Header" runat="server" ChapterTitle="Control Styles" ChapterNumber="6"></apressuc:controlsbookheader>
      <H3>Ch06 FancyLabelStyle</H3>
      <apress:fancylabel id="DefaultLabel" runat="server" CssClass="grayborder" Text="No cursor set"></apress:fancylabel><br>
      <br>
      <apress:fancylabel id="AutoLabel" runat="server" CssClass="grayborder" Text="Auto cursor set"></apress:fancylabel><br>
      <br>
      <apress:fancylabel id="CrosshairLabel" runat="server" CssClass="grayborder" Text="Crosshair cursor set"></apress:fancylabel><br>
      <br>
      <apress:fancylabel id="HandLabel" runat="server" CssClass="grayborder" Text="Hand cursor set"></apress:fancylabel><br>
      <br>
      <apress:fancylabel id="HelpLabel" runat="server" CssClass="grayborder" Text="Help cursor set"></apress:fancylabel><br>
      <br>
      <apress:fancylabel id="MoveLabel" runat="server" CssClass="grayborder" Text="Move cursor set"></apress:fancylabel><br>
      <br>
      <apress:fancylabel id="TextLabel" runat="server" CssClass="grayborder" Text="Text cursort set"></apress:fancylabel><br>
      <br>
      <apress:fancylabel id="WaitLabel" runat="server" CssClass="grayborder" Text="Wait cursor set"></apress:fancylabel>
      <P><asp:button id="Button1" runat="server" Text="Submit"></asp:button></P>
      <apressuc:controlsbookfooter id="Footer" runat="server"></apressuc:controlsbookfooter></form>
  </body>
</HTML>
