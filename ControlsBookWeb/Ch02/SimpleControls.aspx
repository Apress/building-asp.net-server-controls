<%@ Page language="c#" Codebehind="SimpleControls.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch02.SimpleControls" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch02 Simple Controls</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
  <body>
    <form id="SimpleControls" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" />    
      <h3>Ch02 Simple Controls</h3>
      X
      <asp:textbox id="XTextBox" runat="server"></asp:textbox><br>
      <br>
      Y
      <asp:textbox id="YTextBox" runat="server"></asp:textbox><br>
      <br>
      <asp:button id="Button1" runat="server" Text="Build Table"></asp:button><br>
      <br>
      <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
