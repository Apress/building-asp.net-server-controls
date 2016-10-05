<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ControlsBookMobileFooter.ascx.cs" Inherits="ControlsBookMobile.Ch11.ControlsBookMobileFooter" TargetSchema="http://schemas.microsoft.com/Mobile/WebUserControl" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<mobile:Image id="Image1" runat="server" ImageUrl="/ControlsBookMobile/Ch11/line.bmp">
	<DeviceSpecific>
		<Choice Filter="isWML11"></Choice>
	</DeviceSpecific>
</mobile:Image>
<mobile:label id="Label1" runat="server" Font-Bold="False" Font-Size="Small" Font-Name="Tahoma">
<DeviceSpecific>
		<Choice Filter="isWML11" Visible="False"></Choice>
	</DeviceSpecific>Building ASP.NET Server Controls</mobile:label>
<mobile:label id="Label2" runat="server" Font-Size="Small" Font-Name="Arial Narrow">
<DeviceSpecific>
		<Choice Filter="isWML11" Visible="False"></Choice>
	</DeviceSpecific>By Dale Michalk and Robert Cameron</mobile:label>
<mobile:label id="Label3" runat="server" Font-Bold="False" Font-Size="Small" Font-Name="Tahoma">Copyright © 2003, Apress L.P. </mobile:label>
