<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Page language="c#" Codebehind="WebControlStyle.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch06.WebControlStyle" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch06" Assembly="ControlsBookLib" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch06 Web Control Style</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <LINK href="WebControlStyle.css" type="text/css" rel="stylesheet">
  </HEAD>
  <body>
    <form id="WebControlStyle" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber="6" ChapterTitle="Control Styles" />
      <h3>Ch06 Web Control Style</h3>
      <span id="Prompt">Enter your first name:</span><br>
      <apress:textbox id="NameTextbox" runat="server" Font-Bold="True" BackColor="#E0E0E0" Font-Italic="True"
        Font-Names="Tahoma"></apress:textbox><br>
      <br>
      Font-Name:
      <asp:dropdownlist id="FontDropDownList" Runat="server">
        <asp:ListItem Value="Arial">Arial</asp:ListItem>
        <asp:ListItem Value="Courier New">Courier New</asp:ListItem>
        <asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
        <asp:ListItem Value="Monotype Corsiva">Monotype Corsiva</asp:ListItem>
      </asp:dropdownlist><br>
      ForeColor:
      <asp:dropdownlist id="ForeColorDropDownList" Runat="server">
        <asp:ListItem Value="Blue">Blue</asp:ListItem>
        <asp:ListItem Value="Red">Red</asp:ListItem>
        <asp:ListItem Value="Black">Black</asp:ListItem>
      </asp:dropdownlist><br>
      <asp:checkbox id="BoldCheckbox" runat="server" Text="Bold: " TextAlign="Left"></asp:checkbox><br>
      <asp:checkbox id="ItalicCheckbox" runat="server" Text="Italic: " TextAlign="Left"></asp:checkbox><br>
      <asp:checkbox id="UnderlineCheckbox" runat="server" Text="Underline: " TextAlign="Left"></asp:checkbox><br>
      CSS class:
      <asp:textbox id="CssClassTextBox" Runat="server" Text=""></asp:textbox><br>
      <br>
      <asp:button id="SetStyleButton" runat="server" Text="Set Style"></asp:button>&nbsp;
      <asp:button id="SubmitPageButton" runat="server" Text="Submit Page"></asp:button><br>
      <br>
      <apress:label id="NameLabel" runat="server" Text="blank"></apress:label><br>
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
