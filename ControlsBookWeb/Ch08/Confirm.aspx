<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch08" Assembly="ControlsBookLib" %>
<%@ Page language="c#" Codebehind="Confirm.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch08.Confirm" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Confirm</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
  <body MS_POSITIONING="FlowLayout">
    <form id="Confirm" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" chapternumber="8" chaptertitle="Integrating Client-Side Script" runat="server" />
      <apress:formconfirmation id="confirm1" runat="server" Message="formconfirmation: Are you sure you want to submit?"></apress:formconfirmation>
      <br>
      <asp:Button ID="button1" Runat="server" Text="Button"></asp:Button><br>
      <asp:LinkButton ID="linkbutton1" Runat="server" Text="LinkButton"></asp:LinkButton><br>
      <apress:confirmedlinkbutton id="confirmlink1" runat="server" Message="confirmedlinkbutton: Are you sure you want to submit?">ConfirmedLinkButton</apress:confirmedlinkbutton><br>
      <br>
      <asp:Label ID="status" Runat="server" />
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
