<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Page language="c#" Codebehind="HelloWorld.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch02.HelloWorld" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch02 HelloWorld</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body>
    <form id="HelloWorld" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber=2 ChapterTitle="Server Control Basics" />
      <H3><%# GetTitle() %></H3>
      <asp:DropDownList id="DropDownList1" runat="server"></asp:DropDownList>
      <asp:TextBox id="TextBox1" runat="server" Font-Italic="True"></asp:TextBox><br>
      <br>
      <asp:Button id="Button1" runat="server" Text="Button"></asp:Button><br>
      <br>
      <asp:Label id="Label1" runat="server">Result Label</asp:Label>
      <br>
      <asp:Label id="Label2" runat="server">Change Label</asp:Label>
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
