<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch04" Assembly="ControlsBookLib" %>
<%@ Page language="c#" Codebehind="LabelControls.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch04.LabelControls" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch04 Label Controls</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body MS_POSITIONING="FlowLayout">
    <form id="Labels" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber="4" ChapterTitle="State Management" />
      <h3>Ch04 Label Controls</h3>
      Enter your name:<br>
      <asp:textbox id="NameTextBox" runat="server"></asp:textbox><br>
      <br>
      <asp:button id="SetLabelButton" runat="server" Text="Set Labels"></asp:button>&nbsp;
      <asp:button id="SubmitPageButton" runat="server" Text="Submit Page"></asp:button><br>
      <br>
      <h3>StatelessLabel</h3>
      <apress:StatelessLabel id="StatelessLabel1" Text="StatelessLabel" runat="server" />
      <br>
      <h3>StatefulLabel</h3>
      <apress:StatefulLabel id="StatefulLabel1" Text="StatefulLabel" runat="server" />
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
