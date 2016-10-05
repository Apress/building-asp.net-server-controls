<%@ Page language="c#" Codebehind="PhoneBaseValidator.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch09.PhoneBaseValidator" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch09" Assembly="ControlsBookLib" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch09 Phone Validation Using BaseValidator-derived Control</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
  <body MS_POSITIONING="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <apressuc:controlsbookheader id="Header" runat="server" chapternumber="9" chaptertitle="Validation Controls"></apressuc:controlsbookheader>
      <h3>Ch09 Phone Validation Using BaseValidator-derived Control</h3>
      US Phone Number:<asp:textbox id="USPhoneNumber" Runat="server"></asp:textbox>
      <asp:requiredfieldvalidator id="Requiredfieldvalidator" runat="server" ErrorMessage="US PhoneNumber is a required field"
        ControlToValidate="USPhoneNumber" Display="Dynamic">*</asp:requiredfieldvalidator>
      <apress:phonevalidator id="PhoneValidatorUS" Runat="server" ErrorMessage="PhoneNumber must be in format (xxx) xxx-xxxx or xxx-xxx-xxxx"
        NumberType="US" ControlToValidate="USPhoneNumber" Display="Dynamic">*</apress:phonevalidator><BR>
      <br>
      International Phone Number:<asp:textbox id="IntlPhoneNumber" Runat="server"></asp:textbox>
      <asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="Intl PhoneNumber is a required field"
        ControlToValidate="IntlPhoneNumber" Display="Dynamic">*</asp:requiredfieldvalidator>
      <apress:phonevalidator id="PhonevalidatorIntl" Runat="server" ErrorMessage="Intl PhoneNumber must be in international format (8 to 20 digits '-' separators)"
        NumberType="Intl" ControlToValidate="IntlPhoneNumber" Display="Dynamic">*</apress:phonevalidator><BR>
      <asp:button id="Submit" Runat="server" Text="Submit"></asp:button><br>
      <BR>
      <asp:label id="Status" Runat="server" Text=""></asp:label><asp:validationsummary id="Summary" Runat="server"></asp:validationsummary><BR>
      <apressuc:controlsbookfooter id="Footer" runat="server"></apressuc:controlsbookfooter></form>
    </FORM>
  </body>
</HTML>
