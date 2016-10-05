<%
' Title: Building ASP.NET Server Controls
'
' Chapter:  1 - User Interface Reuse
' File: Customers.asp
' Written by: Dale Michalk and Rob Cameron
'
' Copyright © 2003, Apress L.P. %>
<html>
  <body>
    <form method="post" action="Customers.asp">
      <%
     Function GetCustomersRS(Name)
          Dim RS
          Dim Conn
          Set Conn = Server.CreateObject("ADODB.Connection")
          Conn.Open "Provider=SQLOLEDB.1;Integrated Security=SSPI;" & _
               "Initial Catalog=Northwind;Data Source=(local);"

          Set RS = Server.CreateObject("ADODB.Recordset")
        SQL = "SELECT ContactName, CompanyName FROM Customers WHERE ContactName LIKE '%" & Trim(Name) & "%'"
          RS.CursorLocation = 3 'adUseClient
          RS.CursorType = 3     'adOpenStatic
          RS.ActiveConnection = Conn
    RS.Open SQL
    Set RS.ActiveConnection = Nothing
    Set GetCustomersRS = RS
          Conn.Close  
     End Function

     Dim CustName 
     CustName = Request("custname")
     Dim CustRS

%>
      <br>
      <h3>Customer Search</h3>
      ContactName<br>
      <input id=name name=custname type="text" value="<%= CustName  %>"><br>
      <input type="submit">
      <br>
      <h4>Results</h4>
      <table border="1" cellspacing="0" style="border-width:1px;border-style:solid;border-collapse:collapse;">
        <tr>
          <td><b>ContactName</b></td>
          <td><b>CompanyName</b></td>
        </tr>
        <%
     If CustName <> "" THen
          Set CustRS = GetCustomersRS(CustName)
          If Not CustRS.EOF Then
               Do While Not CustRS.EOF
%>
        <tr>
          <td><%= CustRS("ContactName") %></td>
          <td><%= CustRS("CompanyName") %></td>
        </tr>
        <%
                    CustRS.MoveNext
               Loop        
%>
      </table>
      <%  
        End If                  
     End If
%>
    </form>
  </body>
</html>
