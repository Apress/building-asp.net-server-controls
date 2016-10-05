<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch05" Assembly="ControlsBookLib" %>
<%@ Page language="c#" Codebehind="CustomEventTextbox.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch05.CustomEventTextbox" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Ch05 CustomEventTextbox</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Textbox" method="post" runat="server">
			<apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber="5" ChapterTitle="Event-based Programming" />
			<h3>Ch05 CustomEventTextbox</h3>
			Enter your name:<br>
			<apress:customeventtextbox id="NameTextbox" runat="server"></apress:customeventtextbox><br>
			<br>
			<asp:button id="SubmitPageButton" runat="server" Text="Submit Page"></asp:button><br>
			<br>
			Before:<asp:label id="BeforeLabel" runat="server" Text=""></asp:label><br>
			After:<asp:label id="AfterLabel" runat="server" Text=""></asp:label><br>
			<apressUC:ControlsBookFooter id="Footer" runat="server" />
		</form>
	</body>
</HTML>
