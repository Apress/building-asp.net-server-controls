<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch03" Assembly="ControlsBookLib" %>
<%@ Page language="c#" Codebehind="TableCustomControlDemo.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch03.TableCustomControlDemo" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
   <HEAD>
      <title>Ch03 Table Custom Control Demo</title>
      <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
      <meta content="C#" name="CODE_LANGUAGE">
      <meta content="JavaScript" name="vs_defaultClientScript">
      <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
   </HEAD>
   <body MS_POSITIONING="FlowLayout">
      <form id="TableCustomControlDemo" method="post" runat="server">
         <apressuc:controlsbookheader id="Header" runat="server" ChapterTitle="Building Server Controls" ChapterNumber="3"></apressuc:controlsbookheader>
         <h3>Ch03 Table Custom Controls</h3>
         <table>
            <tr>
               <td width="50%"><apress:tablecustomcontrol id="TableCust1" runat="server" Y="2" X="2"></apress:tablecustomcontrol></td>
               <td><apress:tablecompcustomcontrol id="TableCompCust1" runat="server" X="2" Y="2"></apress:tablecompcustomcontrol></td>
            </tr>
         </table>
         <apressuc:controlsbookfooter id="Footer" runat="server"></apressuc:controlsbookfooter></form>
   </body>
</HTML>
