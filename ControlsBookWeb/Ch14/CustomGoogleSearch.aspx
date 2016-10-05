<%@ Import Namespace="Apress.GoogleControls.Service" %>
<%@ Page language="c#" Codebehind="CustomGoogleSearch.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch13.CustomGoogleSearch" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Register TagPrefix="google" Namespace="Apress.GoogleControls" Assembly="Apress.GoogleControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9d0e1a77378e3a88" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
   <HEAD>
      <title>CustomGoogleSearch</title>
      <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
      <meta content="C#" name="CODE_LANGUAGE">
      <meta content="JavaScript" name="vs_defaultClientScript">
      <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
   </HEAD>
   <body MS_POSITIONING="FlowLayout">
      <form id="Form1" method="post" runat="server">
         <apressuc:controlsbookheader id="Header" runat="server" chapternumber="13" chaptertitle="Packaging and Deploying Controls"></apressuc:controlsbookheader>
         <h3>Ch14 Custom Google Search</h3>
         <google:search id="search" runat="server" ResultControl="result" RedirectToGoogle="false"></google:search><br>
         <br>
         <google:result id="result" runat="server" DisplayPager="false">
            <ItemTemplate>
               <A href="<%# ((ResultElement) Container.DataItem).URL  %>">
                  <%# ((ResultElement) Container.DataItem).URL  %>
               </A>
               <BR>
               <%# ((ResultElement) Container.DataItem).snippet  %>
               <BR>
            </ItemTemplate>
            <ItemStyle Font-Size="X-Small" Font-Names="Arial" Font-Italic="True"></ItemStyle>
            <StatusStyle Font-Bold="True" ForeColor="Red"></StatusStyle>
            <AlternatingItemTemplate>
               <A href="<%# ((ResultElement) Container.DataItem).URL  %>">
                  <%# ((ResultElement) Container.DataItem).URL  %>
               </A>
               <BR>
               <%# ((ResultElement) Container.DataItem).snippet  %>
               <BR>
            </AlternatingItemTemplate>
            <AlternatingItemStyle Font-Size="X-Small" Font-Names="Arial" Font-Italic="True"></AlternatingItemStyle>
            <StatusTemplate>
Displaying entries <%# ((GoogleSearchResult) Container.DataItem).startIndex.ToString()  %> - <%# ((GoogleSearchResult) Container.DataItem).endIndex.ToString()  %> of about <%# ((GoogleSearchResult) Container.DataItem).estimatedTotalResultsCount.ToString()  %>.<BR>
</StatusTemplate>
            <SeparatorTemplate>
               <HR>
            </SeparatorTemplate>
         </google:result><apressuc:controlsbookfooter id="Footer" runat="server"></apressuc:controlsbookfooter></form>
   </body>
</HTML>
