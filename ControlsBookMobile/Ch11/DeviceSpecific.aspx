<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Page language="c#" Codebehind="DeviceSpecific.aspx.cs" Inherits="ControlsBookMobile.Ch11.DeviceSpecific" AutoEventWireup="false" %>
<HEAD>
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="http://schemas.microsoft.com/Mobile/Page" name="vs_targetSchema">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
	<mobile:form id="InputForm" runat="server">
		<P>
			<mobile:Image id="Image1" ImageUrl="/ControlsBookMobile/Ch10/mslogo.bmp" Runat="server">
				<DeviceSpecific>
					<Choice Filter="prefersWBMP" ImageUrl="/ControlsBookMobile/Ch10/mslogo.wbmp"></Choice>
				</DeviceSpecific>
			</mobile:Image>
			<mobile:Label id="Label1" runat="server">Query by contact name:</mobile:Label>
			<mobile:TextBox id="NameTextBox" runat="server"></mobile:TextBox>
			<mobile:Command id="SelListCmd" runat="server">Submit</mobile:Command>
			<mobile:Label id="Label3" runat="server" BreakAfter="False">Agent:&nbsp;</mobile:Label>
			<mobile:Label id="AgentLabel" runat="server"></mobile:Label>
			<mobile:Label id="Label2" runat="server" BreakAfter="False">PreferredRenderingType:&nbsp;</mobile:Label>
			<mobile:Label id="PrefRendLabel" runat="server"></mobile:Label>
			<mobile:Label id="Label5" runat="server" BreakAfter="False">PreferredImageMIME:&#160;</mobile:Label>
			<mobile:Label id="PrefImageLabel" runat="server"></mobile:Label>
		</P>
	</mobile:form>
	<mobile:form id="ObjectListForm" runat="server" Paginate="True">
		<mobile:ObjectList id="ObjectList1" runat="server" Wrapping="NoWrap" CommandStyle-StyleReference="subcommand"
			LabelStyle-StyleReference="title" ItemsPerPage="10">
			<DeviceSpecific>
				<Choice Filter="isHTML32">
					<HeaderTemplate>
						<table>
							<tr bgcolor="#000084">
								<td>
									<font color="white">Contact Name</font>
								</td>
								<td>
									<font color="white">Contact Title</font>
								</td>
								<td>
									<font color="white">Company Name</font>
								</td>
							</tr>
					</HeaderTemplate>
					<ItemTemplate>
						<tr bgcolor="#EEEEEE">
							<td>
								<%#((ObjectListItem)Container)["ContactName"]%>
							</td>
							<td>
								<%#((ObjectListItem)Container)["ContactTitle"]%>
							</td>
							<td>
								<%#((ObjectListItem)Container)["CompanyName"]%>
							</td>
						</tr>
					</ItemTemplate>
					<AlternatingItemTemplate>
						<tr bgcolor="#DCDCDC">
							<td>
								<%#((ObjectListItem)Container)["ContactName"]%>
							</td>
							<td>
								<%#((ObjectListItem)Container)["ContactTitle"]%>
							</td>
							<td>
								<%#((ObjectListItem)Container)["CompanyName"]%>
							</td>
						</tr>
					</AlternatingItemTemplate>
					<FooterTemplate>
						</table>
					</FooterTemplate>
				</Choice>
				<Choice>
					<ItemTemplate>
						Name:<%#((ObjectListItem)Container)["ContactName"]%>&nbsp;&nbsp; Title:<%#((ObjectListItem)Container)["ContactTitle"]%>&nbsp;&nbsp; 
						Company:<%#((ObjectListItem)Container)["CompanyName"]%>
						<br />
					</ItemTemplate>
				</Choice>
			</DeviceSpecific>
		</mobile:ObjectList>
	</mobile:form>
</body>
