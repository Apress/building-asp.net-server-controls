using System;
using System.Web.UI;
using System.Reflection;
using System.Runtime.CompilerServices;

// version the assembly using strong name
[assembly: AssemblyKeyFile(@"..\..\Apress.GoogleControls.snk")]
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyCulture("")]	

// General information about control assembly
[assembly: AssemblyTitle("Apress.GoogleControls")]
[assembly: AssemblyDescription("Apress ASP.NET Control Library for Google Web Service")]
[assembly: AssemblyCompany("Apress")]
[assembly: AssemblyProduct("Google ASP.NET Web Control Library")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
	
// configure the tag/namespace to be used in the toolbox
[assembly: TagPrefix("Apress.GoogleControls","google") ]

// ensure Common Language Specification (CLS) compliance
[assembly: CLSCompliant(true)]
