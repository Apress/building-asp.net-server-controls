<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch09" Assembly="ControlsBookLib" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Page language="c#" Codebehind="PhoneCustomValidator.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch09.PhoneCustomValidator" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch09 Phone Validation Using CustomValidator</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <script language="javascript">
function ClientPhoneValidate(source, args)
{
var regex = /^\(?\d{3}\)?(\s|-)\d{3}\-\d{4}$/;
var matches = regex.exec(args.Value);
args.IsValid = (matches != null &&
args.Value == matches[0]);
}
    </script>
  </HEAD>
  <body MS_POSITIONING="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <apressuc:controlsbookheader id="Header" runat="server" chaptertitle="Validation Controls" chapternumber="9"></apressuc:controlsbookheader>
      <h3>Ch09 Phone Validation Using CustomValidator</h3>
      <table id="inputtable">
        <tr vAlign="top">
          <td>
            <table>
              <TBODY>
                <tr>
                  <td>Name:</td>
                  <td><asp:textbox id="Name" runat="server"></asp:textbox></td>
                  <td><asp:requiredfieldvalidator id="NameReqValidator" runat="server" ControlToValidate="Name" ErrorMessage="Name is a required field">*</asp:requiredfieldvalidator></td>
                </tr>
                <tr vAlign="top">
                  <td>Sex:</td>
                  <td><asp:radiobuttonlist id="Sex" Runat="server">
                      <asp:ListItem>Male</asp:ListItem>
                      <asp:ListItem>Female</asp:ListItem>
                    </asp:radiobuttonlist></td>
                  <td><asp:requiredfieldvalidator id="SexReqValidator" runat="server" Display="Dynamic" ControlToValidate="Sex" ErrorMessage="Sex is a required field">*</asp:requiredfieldvalidator></td>
                </tr>
                <tr>
                  <td>Age:</td>
                  <td><asp:textbox id="Age" runat="server"></asp:textbox></td>
                  <td><asp:requiredfieldvalidator id="AgeReqValidator" runat="server" Display="Dynamic" ControlToValidate="Age" ErrorMessage="Age is a required field">*</asp:requiredfieldvalidator><asp:rangevalidator id="AgeRangeValidator" Display="Dynamic" ControlToValidate="Age" ErrorMessage="Age must be in range 1-100"
                      Runat="server" MinimumValue="1" MaximumValue="100" Type="Integer">*</asp:rangevalidator></td>
                </tr>
                <tr vAlign="top">
                  <td>Job:</td>
                  <td><asp:dropdownlist id="Job" Runat="server">
                      <asp:ListItem>Web Developer</asp:ListItem>
                      <asp:ListItem>Manager</asp:ListItem>
                    </asp:dropdownlist></td>
                  <td><asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" Display="Dynamic" ControlToValidate="Job"
                      ErrorMessage="Job is a required field">*</asp:requiredfieldvalidator></td>
                </tr>
                <tr>
                  <td>Password:</td>
                  <td><asp:textbox id="Password1" Runat="server" TextMode="Password"></asp:textbox></td>
                  <td><asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" Display="Dynamic" ControlToValidate="Password1"
                      ErrorMessage="Password is a required field">*</asp:requiredfieldvalidator><asp:comparevalidator id="CompareValidator1" Display="Dynamic" ControlToValidate="Password1" ErrorMessage="Passwords must match for confirmation"
                      Runat="server" ControlToCompare="Password2">*</asp:comparevalidator></td>
                </tr>
                <tr>
                  <td>Confirm Password:</td>
                  <td><asp:textbox id="Password2" Runat="server" TextMode="Password"></asp:textbox></td>
                  <td><asp:requiredfieldvalidator id="Requiredfieldvalidator5" runat="server" Display="Dynamic" ControlToValidate="Password2"
                      ErrorMessage="Confirm Password is a required field">*</asp:requiredfieldvalidator></td>
                </tr>
                <tr>
                  <td>Phone Number:</td>
                  <td><asp:textbox id="PhoneNumber" Runat="server"></asp:textbox></td>
                  <td><asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" Display="Dynamic" ControlToValidate="PhoneNumber"
                      ErrorMessage="PhoneNumber is a required field">*</asp:requiredfieldvalidator>
                    <asp:customvalidator id="CustomValidator" Display="Dynamic" ControlToValidate="PhoneNumber" ErrorMessage="PhoneNumber must be in format (xxx) xxx-xxxx or xxx-xxx-xxxx"
                      Runat="server" ClientValidationFunction="ClientPhoneValidate">*</asp:customvalidator>
                  </td>
                </tr>
                <tr>
                  <td>Comments:</td>
                  <td><asp:textbox id="Comments" Runat="server" TextMode="MultiLine" Rows="2"></asp:textbox></td>
                  <td><asp:requiredfieldvalidator id="Requiredfieldvalidator7" runat="server" Display="Dynamic" ControlToValidate="Comments"
                      ErrorMessage="Comments is a required field">*</asp:requiredfieldvalidator></td>
                </tr>
              </TBODY>
            </table>
          </td>
          <td>&nbsp;&nbsp;&nbsp;&nbsp;
          </td>
          <td>Errors:<br>
            <asp:validationsummary id="Summary" Runat="server" DisplayMode="List"></asp:validationsummary><BR>
          </td>
        </tr>
      </table>
      &nbsp;<br>
      <asp:button id="NoValidationSubmit" runat="server" Text="Submit (No-Validation)" CausesValidation="False"></asp:button>&nbsp;
      <asp:button id="Submit" Runat="server" Text="Submit"></asp:button><br>
      <BR>
      <asp:label id="Status" Runat="server" Text=""></asp:label><apressuc:controlsbookfooter id="Footer" runat="server"></apressuc:controlsbookfooter></form>
    </FORM>
  </body>
</HTML>
