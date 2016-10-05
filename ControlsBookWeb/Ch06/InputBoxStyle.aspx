<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch06" Assembly="ControlsBookLib" %>
<%@ Page language="c#" Codebehind="InputBoxStyle.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch06.InputBoxStyle" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
   <HEAD>
      <title>InputBox Style</title>
      <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
      <meta name="CODE_LANGUAGE" Content="C#">
      <meta name="vs_defaultClientScript" content="JavaScript">
      <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
   </HEAD>
   <body MS_POSITIONING="FlowLayout">
      <form id="InputBoxStyle" method="post" runat="server">
         <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber="6" ChapterTitle="Control Styles" />
         <h3>Ch06 InputBox Style</h3>
         <apress:inputbox id="NameInputBox" runat="server" LabelText="Enter your name: " TextboxText="blank"
            Font-Names="Courier New" ForeColor="Red" Font-Italic="True"></apress:inputbox><br>
         <br>
         <table>
            <tr>
               <td><span style="FONT-WEIGHT: bold">Label Style</span><br>
                  <asp:radiobuttonlist id="LabelActionList" RepeatColumns="3" Runat="server">
                     <asp:ListItem Value="Off" Selected="True">Off</asp:ListItem>
                     <asp:ListItem Value="Apply">Apply</asp:ListItem>
                  </asp:radiobuttonlist><br>
                  Font-Name:
                  <asp:dropdownlist id="LabelFontDropDownList" Runat="server">
                     <asp:ListItem Value="Arial">Arial</asp:ListItem>
                     <asp:ListItem Value="Courier New">Courier New</asp:ListItem>
                     <asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
                     <asp:ListItem Value="Monotype Corsiva">Monotype Corsiva</asp:ListItem>
                  </asp:dropdownlist><br>
                  ForeColor:
                  <asp:dropdownlist id="LabelForeColorDropDownList" Runat="server">
                     <asp:ListItem Value="Blue">Blue</asp:ListItem>
                     <asp:ListItem Value="Red">Red</asp:ListItem>
                     <asp:ListItem Value="Black">Black</asp:ListItem>
                  </asp:dropdownlist><br>
                  <asp:checkbox id="LabelBoldCheckbox" runat="server" Text="Bold: " TextAlign="Left"></asp:checkbox><br>
                  <asp:checkbox id="LabelItalicCheckbox" runat="server" Text="Italic: " TextAlign="Left"></asp:checkbox><br>
               </td>
               <td><span style="FONT-WEIGHT: bold">Textbox Style</span><br>
                  <asp:radiobuttonlist id="TextboxActionList" RepeatColumns="3" Runat="server">
                     <asp:ListItem Value="Off" Selected="True">Off</asp:ListItem>
                     <asp:ListItem Value="Apply">Apply</asp:ListItem>
                  </asp:radiobuttonlist><br>
                  Font-Name:
                  <asp:dropdownlist id="TextboxFontDropDownList" Runat="server">
                     <asp:ListItem Value="Arial">Arial</asp:ListItem>
                     <asp:ListItem Value="Courier New">Courier New</asp:ListItem>
                     <asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
                     <asp:ListItem Value="Monotype Corsiva">Monotype Corsiva</asp:ListItem>
                  </asp:dropdownlist><br>
                  ForeColor:
                  <asp:dropdownlist id="TextboxForeColorDropDownList" Runat="server">
                     <asp:ListItem Value="Blue">Blue</asp:ListItem>
                     <asp:ListItem Value="Red">Red</asp:ListItem>
                     <asp:ListItem Value="Black">Black</asp:ListItem>
                  </asp:dropdownlist><br>
                  <asp:checkbox id="TextboxBoldCheckbox" runat="server" Text="Bold: " TextAlign="Left"></asp:checkbox><br>
                  <asp:checkbox id="TextboxItalicCheckbox" runat="server" Text="Italic: " TextAlign="Left"></asp:checkbox><br>
               </td>
            </tr>
         </table>
         <br>
         <br>
         <asp:button id="SetStyleButton" runat="server" Text="Set Style" Height="23px" Width="83px"></asp:button>&nbsp;
         <asp:button id="SubmitPageButton" runat="server" Text="Submit Page"></asp:button><br>
         <br>
         <apressUC:ControlsBookFooter id="Footer" runat="server" />
      </form>
   </body>
</HTML>
