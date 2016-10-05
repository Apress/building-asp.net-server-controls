<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch04" Assembly="ControlsBookLib" %>
<%@ Page language="c#" Codebehind="PostbackData.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch04.PostbackData" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch04 Postback Data</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
  <body MS_POSITIONING="FlowLayout">
    <form id="PostbackData" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber="4" ChapterTitle="State Management" />
      <h3>Ch04 Postback Data</h3>
      Enter your name:<br>
      <apress:textbox id="NameTextBox" runat="server"></apress:textbox><br>
      <br>
      <asp:button id="SetLabelButton" runat="server" Text="Set Labels"></asp:button>&nbsp;
      <asp:button id="SubmitPageButton" runat="server" Text="Submit Page"></asp:button><br>
      <br>
      <h3>StatelessLabel</h3>
      <apress:statelesslabel id="StatelessLabel1" runat="server" Text="StatelessLabel"></apress:statelesslabel><br>
      <h3>StatefulLabel</h3>
      <apress:statefullabel id="StatefulLabel1" runat="server" Text="StatefulLabel"></apress:statefullabel>
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
