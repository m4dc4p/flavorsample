using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Flavor;
using Microsoft.VisualStudio.Shell.Interop;

namespace Company.MyPackage
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid(GuidList.guidMyPackageProjectString)]
    public class MyPackageProject : FlavoredProjectBase
    {
        #region Fields
        private MyPackage package;
        private static Icon projectIcon;
        #endregion

        #region Constructors
        static MyPackageProject()
        {
            projectIcon = new Icon(typeof(MyPackageProject).Assembly.GetManifestResourceStream("Company.MyPackage.Resources.MyPackageProject.ico"));
        }

        public MyPackageProject(MyPackage package)
        {
            this.package = package;
        }
        #endregion

        protected override void SetInnerProject(IntPtr innerIUnknown)
        {
            object inner = null;

            inner = Marshal.GetObjectForIUnknown(innerIUnknown);

            if (base.serviceProvider == null)
            {
                base.serviceProvider = this.package;
            }

            base.SetInnerProject(innerIUnknown);
        }

        protected override void InitializeForOuter(string fileName, string location, string name, uint flags, ref Guid guidProject, out bool cancel)
        {
            base.InitializeForOuter(fileName, location, name, flags, ref guidProject, out cancel);
        }

        protected override int GetProperty(uint itemId, int propId, out object property)
        {
            switch (propId)
            {
                case (int)__VSHPROPID.VSHPROPID_IconIndex:
                case (int)__VSHPROPID.VSHPROPID_OpenFolderIconIndex:
                    {
                        if (itemId == VSConstants.VSITEMID_ROOT)
                        {
                            property = null;
                            //Forward to __VSHPROPID.VSHPROPID_IconHandle and __VSHPROPID.VSHPROPID_OpenFolderIconHandle propIds
                            return VSConstants.E_NOTIMPL;
                        }

                        break;
                    }
                case (int)__VSHPROPID.VSHPROPID_IconHandle:
                case (int)__VSHPROPID.VSHPROPID_OpenFolderIconHandle:
                    {
                        if (itemId == VSConstants.VSITEMID_ROOT && projectIcon != null)
                        {
                            property = projectIcon.Handle;
                            return VSConstants.S_OK;
                        }

                        break;
                    }
            }

            return base.GetProperty(itemId, propId, out property);
        }
    }
}
