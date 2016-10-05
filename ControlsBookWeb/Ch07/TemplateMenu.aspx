<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Page language="c#" Codebehind="TemplateMenu.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch07.TemplateMenu" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch07" Assembly="ControlsBookLib" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Ch07 TemplateMenu Control</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="TemplateMenu" method="post" runat="server">
			<apressuc:controlsbookheader id="Header" runat="server" ChapterTitle="Templates and Databinding" ChapterNumber="7"></apressuc:controlsbookheader>
			<h3>Ch07 TemplateMenu Control</h3>
			<apress:templatemenu id="menu1" runat="server" Height="43px" Width="240px">
				<SeparatorTemplate>
&lt;&gt; 
</SeparatorTemplate>
				<HeaderTemplate>
					<SPAN style="FONT-WEIGHT: bold; COLOR: white; BACKGROUND-COLOR: blue">Some web 
						links.</SPAN>
				</HeaderTemplate>
				<FooterTemplate>
					<SPAN style="FONT-WEIGHT: bold; COLOR: white; BACKGROUND-COLOR: red">To browse to</SPAN>
				</FooterTemplate>
			</apress:templatemenu><br>
			<apressuc:controlsbookfooter id="Footer" runat="server"></apressuc:controlsbookfooter></form>
	</body>
</HTML>
