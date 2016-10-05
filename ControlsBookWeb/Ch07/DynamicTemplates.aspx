<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Page language="c#" Codebehind="DynamicTemplates.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch07.DynamicTemplates" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch07" Assembly="ControlsBookLib" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>CustomTemplates</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body MS_POSITIONING="FlowLayout">
    <form id="CustomTemplates" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber="7" ChapterTitle="Templates and Databinding" />
      <h3>Ch07 Dynamic Templates</h3>
      <b>Template: </b>
      <br>
      <br>
      <asp:DropDownList id="templateList" Runat="server" AutoPostBack="True">
        <asp:ListItem>FileTemplate.ascx</asp:ListItem>
        <asp:ListItem>CustCodeTemplate</asp:ListItem>
        <asp:ListItem>CustFileTemplate.ascx</asp:ListItem>
      </asp:DropDownList>
      <br>
      <br>
      <b>Repeater:</b><br>
      <br>
      <apress:repeater id="repeaterRdrCust" runat="server"></apress:repeater>
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
