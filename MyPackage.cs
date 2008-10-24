// VsPkg.cs : Implementation of MyPackage
//

using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;

namespace Company.MyPackage
{
    [ProvideProjectFactory(typeof(Company.MyPackage.MyPackageProjectFactory), 
        "My Package", "My Package Files (*.csproj);*.csproj", null, null, null)]
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\9.0")]
    [InstalledProductRegistration(false, "#110", "#112", "1.0", IconResourceID = 400)]
    /* Below used to generate load key:
    PZCEAIZCA3AJH2ECKZP2M8DZHAQRREC0JMR1DJP3MMP1DIMMIJRCD0KDAIMCJZQJH9PKC0ZZPKJDPTQTI2R1A3MIQTCHZRPMJ3D2A0P0EMD8PHKDC0ZZZMKMD8J2R3QK
     */
    [ProvideLoadKey("Standard", "1.0", "MyPackage", "Company", 1)]
    [Guid(GuidList.guidMyPackagePkgString)]
    public sealed class MyPackage : Package
    {
        public MyPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }


        protected override void Initialize()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            this.RegisterProjectFactory(new MyPackageProjectFactory(this));
            base.Initialize();
        }
    }
}