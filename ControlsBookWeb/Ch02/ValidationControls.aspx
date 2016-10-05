<%@ Page language="c#" Codebehind="ValidationControls.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch02.ValidationControls" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch02 Validator Controls</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <script language="javascript">
      function validateEven(oSrc, args){
        args.IsValid = ((args.Value % 2) == 0);
      }
    </script>
  </HEAD>
  <body>
    <form id="ValidationControls" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber=2 ChapterTitle = "Server Control Basics"/>
      <h3>Ch02 Validation Controls</h3>
      <asp:Label id="Label1" runat="server"> RequiredField</asp:Label><br>
      <asp:TextBox id="RequiredField" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredField needs an input value!"
        ControlToValidate="RequiredField"></asp:RequiredFieldValidator><br>
      <asp:Label id="Label2" runat="server"> ComparedField</asp:Label><br>
      <asp:TextBox id="ComparedField" runat="server"></asp:TextBox>
      <asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="RequiredField and ComparedField are not equal!"
        ControlToValidate="ComparedField" ControlToCompare="RequiredField"></asp:CompareValidator><br>
      <asp:Label id="Label3" runat="server"> RangeField</asp:Label><br>
      <asp:TextBox id="RangeField" runat="server"></asp:TextBox>
      <asp:RangeValidator id="RangeValidator1" runat="server" ErrorMessage="RangeField value must be between 1-10!"
        ControlToValidate="RangeField" MaximumValue="10" MinimumValue="1" Type="Integer"></asp:RangeValidator><br>
      <asp:Label id="Label4" runat="server"> RegexField (Phone)</asp:Label><br>
      <asp:TextBox id="RegexField" runat="server"></asp:TextBox>
      <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="RegexField must be a valid US phone number!"
        ControlToValidate="RegexField" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator><br>
      <asp:Label id="Label5" runat="server">CustomField (Even Number)</asp:Label><br>
      <asp:TextBox id="CustomField" runat="server"></asp:TextBox>
      <asp:CustomValidator id="CustomValidator1" runat="server" ErrorMessage="CustomField must be an even number!"
        ControlToValidate="CustomField" ClientValidationFunction="validateEven"></asp:CustomValidator><br>
      <br>
      <asp:Button id="Button1" runat="server" Text="Submit"></asp:Button><br>
      <asp:Label id="ResultsLabel" runat="server"></asp:Label><br>
      <br>
      <asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary>
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
