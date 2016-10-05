<%@ Page language="c#" Codebehind="Focus.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch08.Focus" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch08" Assembly="ControlsBookLib" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Focus</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
  <body MS_POSITIONING="FlowLayout">
    <form id="Focus" method="post" runat="server">
      <apressuc:controlsbookheader id="Header" runat="server" chaptertitle="Integrating Client-Side Script" chapternumber="8"></apressuc:controlsbookheader><apress:focus id="focus1" runat="server"></apress:focus><asp:button id="Button1" runat="server" Text="Cycle Page"></asp:button><br>
      <asp:dropdownlist id="DropDownList1" runat="server" AutoPostBack="True">
        <asp:ListItem Value="TopLabel">TopLabel</asp:ListItem>
        <asp:ListItem Value="BottomLabel">BottomLabel</asp:ListItem>
      </asp:dropdownlist><br>
      <br>
      <asp:label id="TopLabel" tabIndex="1" Text="TopLabel" Runat="server"></asp:label><br>
      <br>
      <asp:datagrid id="dataGrid1" Runat="server" GridLines="Vertical" CellPadding="3" BackColor="White"
        BorderWidth="1px" BorderStyle="None" BorderColor="#999999">
        <SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
        <AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
        <ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
        <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
        <FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
        <PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
      </asp:datagrid><br>
      <br>
      <asp:dropdownlist id="DropDownList2" runat="server" AutoPostBack="True">
        <asp:ListItem Value="TopLabel">TopLabel</asp:ListItem>
        <asp:ListItem Value="BottomLabel">BottomLabel</asp:ListItem>
      </asp:dropdownlist><br>
      <br>
      <asp:label id="BottomLabel" tabIndex="2" Text="BottomLabel" Runat="server">BottomLabel</asp:label><apressuc:controlsbookfooter id="Footer" runat="server"></apressuc:controlsbookfooter></form>
  </body>
</HTML>
