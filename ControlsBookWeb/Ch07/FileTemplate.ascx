<%@ Control Language="c#" AutoEventWireup="false" Codebehind="FileTemplate.ascx.cs" Inherits="ControlsBookWeb.Ch07.FileTemplate" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
Contact:<br>
<span> <%# DataBinder.Eval(Container, "DataItem.ContactName") %> </span>
<br>
