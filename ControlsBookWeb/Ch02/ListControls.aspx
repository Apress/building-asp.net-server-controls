<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Page language="c#" Codebehind="ListControls.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch02.ListControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch02 List Controls</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
  <body>
    <form id="ListControls" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber=2 ChapterTitle="Server Control Basics"/>
      <h3>Ch02 List Controls</h3>
      <asp:repeater id="Repeater1" runat="server">
        <HeaderTemplate>
          <table>
            <th>
              Customer ID</th><th>Contact Name</th><th>Contact Title</th><th>Company Name</th>
        </HeaderTemplate>
        <ItemTemplate>
          <tr bgcolor="Silver">
            <td><%# DataBinder.Eval(Container.DataItem,"CustomerID") %></td>
            <td><%# DataBinder.Eval(Container.DataItem,"ContactName") %></td>
            <td><%# DataBinder.Eval(Container.DataItem,"ContactTitle") %></td>
            <td><%# DataBinder.Eval(Container.DataItem,"CompanyName") %></td>
          </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
          <tr bgcolor="White">
            <td><%# DataBinder.Eval(Container.DataItem,"CustomerID") %></td>
            <td><%# DataBinder.Eval(Container.DataItem,"ContactName") %></td>
            <td><%# DataBinder.Eval(Container.DataItem,"ContactTitle") %></td>
            <td><%# DataBinder.Eval(Container.DataItem,"CompanyName") %></td>
          </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
          </table>
        </FooterTemplate>
      </asp:repeater><br>
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
