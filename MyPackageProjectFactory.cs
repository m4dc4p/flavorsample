using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Flavor;

namespace Company.MyPackage
{
    [ComVisible(false)]
    [Guid(GuidList.guidMyPackageProjectFactoryString)]
    public class MyPackageProjectFactory : FlavoredProjectFactoryBase
    {
        private MyPackage package;

        public MyPackageProjectFactory(MyPackage package)
            : base()
        {
            this.package = package;
        }

        protected override object PreCreateForOuter(IntPtr outerProjectIUnknown)
        {
            return new MyPackageProject(this.package);
        }
    }
}
