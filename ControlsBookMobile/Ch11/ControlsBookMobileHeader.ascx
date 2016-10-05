<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ControlsBookMobileHeader.ascx.cs" Inherits="ControlsBookMobile.Ch11.ControlsBookMobileHeader" TargetSchema="http://schemas.microsoft.com/Mobile/WebUserControl" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<mobile:label id="Label2" runat="server" Font-Name="Arial Narrow" Font-Bold="False" Font-Size="Small">Building ASP.NET Server Controls</mobile:label>
<mobile:label id="Label1" runat="server" Font-Name="Arial Narrow" Font-Bold="False" Font-Size="Small">
<DeviceSpecific>
		<Choice Filter="isWML11" Visible="False"></Choice>
	</DeviceSpecific>Chapter</mobile:label>
<mobile:label id="Label4" runat="server" Font-Name="Arial Narrow" Font-Bold="False" Font-Size="Small">
<DeviceSpecific>
		<Choice Filter="isWML11" Visible="False"></Choice>
	</DeviceSpecific>Chapter Title</mobile:label>
<mobile:Image id="Image1" runat="server" ImageUrl="/ControlsBookMobile/Ch11/line.bmp">
	<DeviceSpecific>
		<Choice Filter="isWML11"></Choice>
	</DeviceSpecific>
</mobile:Image>
