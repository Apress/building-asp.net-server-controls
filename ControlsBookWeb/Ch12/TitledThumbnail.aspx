<%@ Page language="c#" Codebehind="TitledThumbnail.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch12.TitledThumbnail" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch12" Assembly="ControlsBookLib" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TitledThumbnail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<apressuc:controlsbookheader id="Header" runat="server" chapternumber="12" chaptertitle="Design-Time Support"></apressuc:controlsbookheader>
			<br>
			<apress:titledthumbnail id="TitledThumbnail1" title="Clear Winter Day" runat="server" ImageInfo-ImageLocation="76N,102W"
				Align="center" ImageInfo-PhotographerFullName="Robert Cameron" ImageInfo-ImageLongDescription="Winter outdoor scene in Februrary"
				ImageInfo-ImageDate="2003-04-01" BorderStyle="Outset" Font-Size="XX-Small" Font-Names="Tahoma" ImageUrl="Outdoors.jpg"
				Height="88px" Width="88px" ImageInfo-IsEmpty="False"></apress:titledthumbnail><br>
			<apress:titledthumbnail id="Titledthumbnail2" title="Lizard on the Prowl" runat="server" ImageInfo-ImageLocation="34S,150E"
				Align="center" ImageInfo-PhotographerFullName="Rob Cameron" ImageInfo-ImageLongDescription="A lizard on the side of a wooden deck."
				ImageInfo-ImageDate="2003-04-08" BorderStyle="Outset" Font-Size="XX-Small" Font-Names="Tahoma" ImageUrl="Lizard.jpg"
				Height="88px" Width="88px" ImageInfo-IsEmpty="False"></apress:titledthumbnail><br>
			<apressuc:controlsbookfooter id="Footer" runat="server"></apressuc:controlsbookfooter>
			<br>
		</form>
		</FORM>
	</body>
</HTML>
