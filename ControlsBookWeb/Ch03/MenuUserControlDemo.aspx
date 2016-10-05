<%@ Register TagPrefix="apressUC" TagName="MenuUserControl" Src="MenuUserControl.ascx" %>
<%@ Page language="c#" Codebehind="MenuUserControlDemo.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch03.MenuUserControlDemo" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Ch03 Menu User Control</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="MenuUserControlDemo" method="post" runat="server">
			<apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber=3 ChapterTitle="Building Server Controls" />
			<h3>Ch03 Menu User Control</h3>
			<apressUC:MenuUserControl id="menu1" runat="server" /><br>
			<br>
			<apressUC:ControlsBookFooter id="Footer" runat="server" />
		</form>
	</body>
</HTML>
