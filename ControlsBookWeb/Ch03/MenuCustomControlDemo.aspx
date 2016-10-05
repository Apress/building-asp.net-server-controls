<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch03" Assembly="ControlsBookLib" %>
<%@ Page language="c#" Codebehind="MenuCustomControlDemo.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch03.MenuCustomControlDemo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch03 Menu Custom Control Demo</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body MS_POSITIONING="FlowLayout">
    <form id="MenuCustomControlDemo" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" />
      <h3>Ch03 Menu Custom Control</h3>
      <apress:MenuCustomControl id="menu1" runat="server" /><br>
      <br>
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
