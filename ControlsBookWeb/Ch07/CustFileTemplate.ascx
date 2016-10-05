<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CustFileTemplate.ascx.cs" Inherits="ControlsBookWeb.Ch07.CustFileTemplate" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
Contact:<br>
<input type="text" value="<%# DataBinder.Eval(Container, "DataItem.ContactName") %>">
<br>
