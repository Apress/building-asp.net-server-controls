<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch07" Assembly="ControlsBookLib" %>
<%@ Page language="c#" Codebehind="AdvancedRepeater.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch07.AdvancedRepeater" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch07 Advanced Repeater Control</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
  <body MS_POSITIONING="FlowLayout">
    <form id="AdvancedRepeater" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber="7" ChapterTitle="Templates and Databinding" />
      <h3>Ch07 Advanced Repeater Control</h3>
      <b>
        <asp:label id="status" runat="server"></asp:label></b><br>
      <apress:repeater id="repeaterRdrCust" runat="server">
        <ITEMTEMPLATE>
          <%# DataBinder.Eval(Container.DataItem,"ContactName") %>
          <asp:button id="contact1" runat="server"></asp:button>
        </ITEMTEMPLATE>
        <SEPARATORTEMPLATE>
          <BR>
        </SEPARATORTEMPLATE>
      </apress:repeater>
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
