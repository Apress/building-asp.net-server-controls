<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Page language="c#" Codebehind="CustDemo.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch01.CustDemo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Customers</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body>
    <form id="Customers" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber="1" ChapterTitle="User Interface Reuse" />
      <h3>CustDemo</h3>
      <h3>Customer Search</h3>Contact
      Name<BR>
      <asp:textbox id="CustName" runat="server"></asp:textbox><BR>
      <asp:button id="QueryButton" runat="server" Text="Submit Query"></asp:button><BR>
      <BR>
      <H4>Results</H4>
      <asp:datagrid id="DataGrid1" runat="server" />
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
