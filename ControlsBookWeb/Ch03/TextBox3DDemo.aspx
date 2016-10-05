<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch03" Assembly="ControlsBookLib" %>
<%@ Page language="c#" Codebehind="TextBox3DDemo.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch03.TextBox3dDemo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Demo TextBox3d</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body MS_POSITIONING="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber="3" ChapterTitle="Building Server Controls" />
      <apress:TextBox3d id="TextBox3d1" runat="server" Width="159px" Height="22px">I look 3D!</apress:TextBox3d>
      <br>
      <br>
      <apress:TextBox3d id="Textbox3d2" runat="server" Width="159px" Height="22px" Enable3D="false">I don't!</apress:TextBox3d>
      <br>
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
