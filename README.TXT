Source code samples for "Building ASP.NET Server Controls" by Dale Michalk and 
Rob Cameron
-----------------------------------------------------------------------

PREREQUISITES:
SQL Server 2000 or MSDE 200 with the sample databases are used in the sample .aspx pages in Chapter 7 where data binding is covered.  The samples are configured to use impersonation when connecting to SQL Server 2000.  For this to work, uncheck Anonymous access and enable Windows authentication for the two virtual directories below.  This requires that the account that you are logged in under has permissions to the Northwind databases in SQL Server 2000.

INSTALLATION STEPS:
In the directory where the readme.txt is found, you will find a Visual Studio .NET 2003 solution named ControlsBook.sln as well as several project directories.  Here is a description of the projects:

Apress.GoogleControls - Library project that contains the server control code from Chapter's 13 and 14.

ControlsBookLib - Library project that contains source code for the server controls discussed in this book (Except for Chapter's 13 and 14).

ControlsBookMobile - Mobile web project that contains the .aspx test pages for server controls discussed in Chapter's 10 and 11.

ControlsBookWeb - Web project that contains the .aspx test pages for server controls discussed in all chapters (Except Chapter's 10 and 11). 

LicenseGenerator - Windows Forms project that generates licensing information for the Google Server Control.

TestDelegates - Console project that demonstrates delegates.

Here are steps to configure the two web projects (ControlsBookMobile and ControlsBookWeb)

1.  Right-click on the directory (ControlsBookMobile and ControlsBookWeb) and select "Properties"
2.  Select the "Web Sharing" tab and click "Share this folder".
3.  When the "Edit Alias" dialog box displays accept the defaults and click OK.
4.  Ensure Anonymous access is unchecked and that "Windows Authentication" is configured in the "Internet Information Services" configuration tool in the Control Panel.  (Right-click on the VDIR, select Properties | Directory Security | Edit...).

Once the two virtual directories are configured, double-click on ControlsBook.sln to open the solution in Visual Studio .NET 2003.
