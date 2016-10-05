<%@ Page language="c#" Codebehind="RolloverImage.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch08.RolloverImage" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch08" Assembly="ControlsBookLib" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>RolloverImage</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body MS_POSITIONING="FlowLayout">
    <form id="RolloverImage" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" chapternumber="8" chaptertitle="Integrating Client-Side Script" runat="server" />
      <apress:RolloverImageLink id="image1" runat="server" ImageURL="ex1.gif" OverImageURL="ex1_selected.gif" NavigateUrl="http://www.apress.com" />
      <apress:RolloverImageLink id="image2" runat="server" ImageURL="ex2.gif" OverImageURL="ex2_selected.gif" NavigateUrl="http://asp.net"
        EnableClientScript="True" /><br>
      <hr>
      <apress:BrowserCaps Font-Name="Arial" Font-Size="12px" id="caps1" runat="server" />
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
