<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ExternalStyleSheetClass.ascx.cs" Inherits="ControlsBookMobile.Ch11.ExternalStyleSheetClass" TargetSchema="http://schemas.microsoft.com/Mobile/WebUserControl" %>
<mobile:stylesheet id="ExternalStyleSheet" runat="server">
  <mobile:Style Font-Size="Small" Font-Name="Times" Font-Bold="True" ForeColor="Black" Wrapping="NoWrap"
    Name="SimpleTextStyle1"></mobile:Style>
  <mobile:Style Font-Size="Small" Font-Name="Verdana" Font-Italic="True" ForeColor="Black" Wrapping="NoWrap"
    Name="SimpleTextStyle2"></mobile:Style>
  <mobile:Style Font-Size="Small" Font-Name="Verdana" Font-Bold="True" ForeColor="Black" Wrapping="NoWrap"
    Name="QueryStyle"></mobile:Style>
  <mobile:Style StyleReference="QueryStyle" Font-Bold="False" Font-Italic="True" Name="ResultsStyle"></mobile:Style>
</mobile:stylesheet>
