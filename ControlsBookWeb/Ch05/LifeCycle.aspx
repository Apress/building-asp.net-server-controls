<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch05" Assembly="ControlsBookLib" %>
<%@ Page Trace="true" language="c#" Codebehind="LifeCycle.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch05.LifeCycle" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Ch05 Lifecycle</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="LifeCycle" method="post" runat="server">
			<apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber="5" ChapterTitle="Event-based Programming" />
			<h3>Ch05 Lifecycle</h3>
			<apress:Lifecycle id="life1" runat="server" />
			<asp:Button id="Button1" runat="server" Text="Button"></asp:Button>
			<apressUC:ControlsBookFooter id="Footer" runat="server" />
		</form>
	</body>
</HTML>
