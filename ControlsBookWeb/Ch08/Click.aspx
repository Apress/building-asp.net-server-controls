<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Page language="c#" Codebehind="Click.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch08.Click" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch08" Assembly="ControlsBookLib" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch08 Click Event Handling</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body MS_POSITIONING="FlowLayout">
    <form id="Click" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" chapternumber="8" chaptertitle="Integrating Client-Side Script" runat="server" />
      <h3>Ch08 Click Event Handling</h3>
      <asp:Label ID="TopLabel" Runat="server" Text="Click the TopLabel" onclick="alert('TopLabel clicked!');" />
      <br>
      <apress:ClickLabel ID="MiddleLabel" Runat="server" Text="Click the MiddleLabel" ClickText="MiddleLabel clicked!" />
      <br>
      <asp:Label ID="BottomLabel" Runat="server" Text="Click the BottomLabel" />
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
