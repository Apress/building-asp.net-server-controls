<%@ Page language="c#" Codebehind="UpDown.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch08.UpDown" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch08" Assembly="ControlsBookLib" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
   <HEAD>
      <title>UpDown</title>
      <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
      <meta content="C#" name="CODE_LANGUAGE">
      <meta content="JavaScript" name="vs_defaultClientScript">
      <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
   </HEAD>
   <body MS_POSITIONING="FlowLayout">
      <form id="UpDown" method="post" runat="server">
         <apressuc:controlsbookheader id="Header" runat="server" chapternumber="8" chaptertitle="Integrating Client-Side Script"></apressuc:controlsbookheader><br>
         <br>
         <apress:updown id="updown1" runat="server" MinValue="1" MaxValue="15" Increment="3" Value="6" EnableClientScript="False"></apress:updown><br>
         <br>
         Time:<asp:label id="timelabel" Runat="server"></asp:label><br>
         <br>
         Changes:<asp:label id="changelabel" Runat="server"></asp:label><br>
         <br>
         <asp:button id="submitbtn" Runat="server" Text="Submit"></asp:button><apressuc:controlsbookfooter id="Footer" runat="server"></apressuc:controlsbookfooter></form>
   </body>
</HTML>
