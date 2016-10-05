<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Page language="c#" Codebehind="HtmlControls.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch02.HtmlControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch02 HtmlControls</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body>
    <form id="HtmlControls" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber=2 ChapterTitle="Server Control Basics"/>
      <h3>Ch02 HTML Controls</h3>
      X <input type="text" id="XTextBox" runat="server"><br>
      <br>
      Y <input type="text" id="YTextBox" runat="server"><br>
      <br>
      <input type="submit" id="Button1" runat="server" Value="Build Table"><br>
      <br>
      <span id="Span1" runat="server"></span>
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
