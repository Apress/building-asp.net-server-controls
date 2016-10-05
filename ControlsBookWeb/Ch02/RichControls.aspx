<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Page language="c#" Codebehind="RichControls.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch02.RichControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch02 Rich Controls</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body>
    <form id="RichControls" method="post" runat="server">   
      <apressUC:ControlsBookHeader id="Header" runat="server" />
      <h3>Ch02 Rich Controls</h3>
      <P>
        <asp:Calendar id="Calendar1" runat="server" BackColor="White" Width="220px" ForeColor="#003399" Height="200px" Font-Size="8pt" Font-Names="Verdana" BorderColor="#3366CC" BorderWidth="1px" DayNameFormat="FirstLetter" CellPadding="1">
          <TodayDayStyle ForeColor="White" BackColor="#99CCCC"></TodayDayStyle>
          <SelectorStyle ForeColor="#336666" BackColor="#99CCCC"></SelectorStyle>
          <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF"></NextPrevStyle>
          <DayHeaderStyle Height="1px" ForeColor="#336666" BackColor="#99CCCC"></DayHeaderStyle>
          <SelectedDayStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedDayStyle>
          <TitleStyle Font-Size="10pt" Font-Bold="True" Height="25px" BorderWidth="1px" ForeColor="#CCCCFF" BorderStyle="Solid" BorderColor="#3366CC" BackColor="#003399"></TitleStyle>
          <WeekendDayStyle BackColor="#CCCCFF"></WeekendDayStyle>
          <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
        </asp:Calendar></P>
      <P>
      <asp:Label id="Label1" runat="server"></asp:Label></P>
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
