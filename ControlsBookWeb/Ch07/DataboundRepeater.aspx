<%@ Register TagPrefix="apressUC" TagName="ControlsBookFooter" Src="..\ControlsBookFooter.ascx" %>
<%@ Register TagPrefix="apressUC" TagName="ControlsBookHeader" Src="..\ControlsBookHeader.ascx" %>
<%@ Page language="c#" Codebehind="DataboundRepeater.aspx.cs" AutoEventWireup="false" Inherits="ControlsBookWeb.Ch07.DataboundRepeater" %>
<%@ Register TagPrefix="apress" Namespace="ControlsBookLib.Ch07" Assembly="ControlsBookLib" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
   <HEAD>
      <title>Databound Repeater Control</title>
      <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
      <meta content="C#" name="CODE_LANGUAGE">
      <meta content="JavaScript" name="vs_defaultClientScript">
      <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
   </HEAD>
   <body MS_POSITIONING="FlowLayout">
      <form id="DataboundRepeater" method="post" runat="server">
         <apressuc:controlsbookheader id="Header" runat="server" ChapterNumber="7" ChapterTitle="Templates and Databinding"></apressuc:controlsbookheader>
         <h3>Ch07 Databound Repeater Control</h3>
         <br>
         <table>
            <TBODY>
               <tr vAlign="top">
                  <td><apress:repeater id="repeaterA" runat="server"><HEADERTEMPLATE><B>Array</B><BR>
                        </HEADERTEMPLATE>
                        <ITEMTEMPLATE>
                           <%# Container.DataItem %>
                        </ITEMTEMPLATE>
                        <SEPARATORTEMPLATE>
                           <BR>
                        </SEPARATORTEMPLATE>
                     </apress:repeater><br>
                  </td>
                  <td>&nbsp;&nbsp;</td>
                  <td><apress:repeater id="repeaterAl" runat="server"><HEADERTEMPLATE><B>ArrayList</B><BR>
                        </HEADERTEMPLATE>
                        <ITEMTEMPLATE>
                           <%# Container.DataItem %>
                        </ITEMTEMPLATE>
                        <SEPARATORTEMPLATE>
                           <BR>
                        </SEPARATORTEMPLATE>
                     </apress:repeater><br>
                  </td>
               </tr>
               <tr vAlign="top">
                  <td><apress:repeater id="repeaterRdrCust" runat="server"><HEADERTEMPLATE><B>Customers 
                              DataReader</B><BR>
                        </HEADERTEMPLATE>
                        <ITEMTEMPLATE>
                           <DIV style="DISPLAY: inline; FONT-WEIGHT: bold; WIDTH: 130px; COLOR: yellow; HEIGHT: 15px; BACKGROUND-COLOR: red"
                              ms_positioning="FlowLayout"><%# DataBinder.Eval(Container.DataItem,"ContactName") %></DIV>
                        </ITEMTEMPLATE>
                        <ALTERNATINGITEMTEMPLATE>
<DIV style="DISPLAY: inline; FONT-WEIGHT: bold; WIDTH: 130px; COLOR: yellow; HEIGHT: 15px; BACKGROUND-COLOR: blue"
                              ms_positioning="FlowLayout"><%# DataBinder.Eval(Container.DataItem,"ContactName") %></DIV></SPAN></ALTERNATINGITEMTEMPLATE>
                        <SEPARATORTEMPLATE>
                           <BR>
                        </SEPARATORTEMPLATE>
                        <FOOTERTEMPLATE><BR>End
of the list </FOOTERTEMPLATE>
                     </apress:repeater></td>
                  <td>&nbsp;&nbsp;</td>
                  <td><apress:repeater id="repeaterDtEmp" runat="server"><HEADERTEMPLATE><B>DataSet Employees 
                              DataTable</B><BR>
                        </HEADERTEMPLATE>
                        <ITEMTEMPLATE><%# DataBinder.Eval(Container.DataItem,"FirstName") %>&nbsp;
<%# DataBinder.Eval(Container.DataItem,"LastName") %></ITEMTEMPLATE>
                        <SEPARATORTEMPLATE>
                           <BR>
                        </SEPARATORTEMPLATE>
                     </apress:repeater></td>
                  <td>
                     <apress:repeater id=RepeaterDesignTime runat="server" DataSource="<%# dataSetEmp %>" DataMember="Employees">
                        <HEADERTEMPLATE>
                           <B>Binding to a Design-Time Data Source</B><BR>
                        </HEADERTEMPLATE>
                        <ITEMTEMPLATE><%# DataBinder.Eval(Container.DataItem,"FirstName") %>&nbsp;
<%# DataBinder.Eval(Container.DataItem,"LastName") %></ITEMTEMPLATE>
                        <SEPARATORTEMPLATE>
                           <BR>
                        </SEPARATORTEMPLATE>
                     </apress:repeater></td>
               </tr>
            </TBODY>
         </table>
         <asp:button id="Button1" runat="server" Text="Submit"></asp:button><apressuc:controlsbookfooter id="Footer" runat="server"></apressuc:controlsbookfooter></form>
   </body>
</HTML>
