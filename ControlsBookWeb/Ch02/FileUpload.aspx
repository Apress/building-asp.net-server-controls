<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Page language="c#" Codebehind="FileUpload.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch02.FileUpload" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Ch02 File Upload</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body>
    <form id="FileUpload" enctype="multipart/form-data" method="post" runat="server">
      <apressUC:ControlsBookHeader id="Header" runat="server" ChapterNumber=2 ChapterTitle="Server Control Basics"/>
      <h3>Ch02 File Upload</h3>
      File: <input type="file" id="File" runat="server"><br>
      <br>
      Upload FileName: <INPUT type="text" id="Name" runat="server" NAME="Name"><br>
      <br>
      <input type="submit" value="Upload" runat="server" id="Submit1" name="Submit1"><br>
      <br>
      <div id="result" runat="server"></div>
      <apressUC:ControlsBookFooter id="Footer" runat="server" />
    </form>
  </body>
</HTML>
