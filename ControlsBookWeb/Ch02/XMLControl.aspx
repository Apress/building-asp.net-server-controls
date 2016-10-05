<%@ Page language="c#" Codebehind="XMLControl.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch02.XMLControl" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch02 XML Control</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body>
    <form id="XMLControl" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber=2 ChapterTitle="Server Control Basics" />
      <h3>Ch02 XML Control</h3>
      <asp:Xml id="Xml1" runat="server"></asp:Xml>
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
