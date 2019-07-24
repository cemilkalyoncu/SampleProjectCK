using SampleProjectCK.Core.Aspects.Postsharp.ExceptionAspects;
using SampleProjectCK.Core.Aspects.Postsharp.LogAspects;
using SampleProjectCK.Core.Aspects.Postsharp.PerformanceAspects;
using SampleProjectCK.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System.Data.Entity.Infrastructure.Interception;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("SampleProjectCK.Northwind.Business")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("SampleProjectCK.Northwind.Business")]
[assembly: AssemblyCopyright("Copyright ©  2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
//[assembly: LogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "SampleProjectCK.Northwind.Business.Concrete.Managers.*")]
//[assembly: ExceptionLogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "SampleProjectCK.Northwind.Business.Concrete.Managers.*")]
[assembly: PerformanceCounterAspect(AttributeTargetTypes = "SampleProjectCK.Northwind.Business.Concrete.Managers.*")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("629ee3bb-4c25-49ae-8c8d-bf72cac5ac6d")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
