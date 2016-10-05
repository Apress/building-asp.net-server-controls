<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Page language="c#" Codebehind="ClientState.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch04.ClientState" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Ch04 Client State</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="ClientState" method="post" runat="server">
			<apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber="4" ChapterTitle="State Management" />
			<h3>Ch04 Client State</h3>
			Enter your name:<br>
			<asp:textbox id="NameTextBox" runat="server"></asp:textbox><br>
			<br>
			<asp:button id="SetStateButton" runat="server" Text="Set State"></asp:button>&nbsp;
			<asp:button id="SubmitPageButton" runat="server" Text="Submit Page"></asp:button><br>
			<input id="HiddenName" type="hidden" runat="server">
			<br>
			<asp:hyperlink id="URLEncodeLink" runat="server">Link to encode name in URL</asp:hyperlink><br>
			<br>
			<h3>Results</h3>
			Cookie:<asp:label id="CookieLabel" runat="server"></asp:label><br>
			URL:<asp:label id="URLLabel" runat="server"></asp:label><br>
			Hidden Variable:<asp:label id="HiddenLabel" runat="server"></asp:label><br>
			ViewState:<asp:label id="ViewStateLabel" runat="server"></asp:label><br>
			<apressUC:ControlsBookFooter id="Footer" runat="server" />
		</form>
	</body>
</HTML>
