<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Page language="c#" Codebehind="GoogleSearch.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch13.GoogleSearch" %>
<%@ Register TagPrefix="google" Namespace="Apress.GoogleControls" Assembly="Apress.GoogleControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9d0e1a77378e3a88" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GoogleSearch</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<apressuc:controlsbookheader id="Header" runat="server" chaptertitle="Packaging and Deploying Controls" chapternumber="13"></apressuc:controlsbookheader>
			<h3>Ch13 Google Search</h3>
			<google:search id="search" runat="server" RedirectToGoogle="false" ResultControl="result" PageSize="2"></google:search><br>
			<br>
			<google:result id="result" runat="server" PagerStyle="TextWithImages" PagerBarRange="10" PageSize="8"
				TotalResultsCount="2" EndIndex="4">
				<StatusStyle Font-Bold="True" ForeColor="Blue"></StatusStyle>
			</google:result><apressuc:controlsbookfooter id="Footer" runat="server"></apressuc:controlsbookfooter>
			<P>&nbsp;</P>
		</form>
	</body>
</HTML>
