<%@ Page language="c#" Codebehind="TableUserControlDemo.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch03.TableUserControlDemo" %>
<%@ Register TagPrefix="apressUC" TagName="TableUserControl" Src="TableUserControl.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch03 Table User Control Demo</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body MS_POSITIONING="FlowLayout">
    <form id="TableUserControlDemo" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber="3" ChapterTitle="Building Server Controls" />
      <h3>Ch03 Table User Control</h3>
      <apressUC:tableusercontrol id="TableUserControl1" runat="server" Y="1" X="1" />
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
