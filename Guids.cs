using System;

namespace Company.MyPackage
{
    static class GuidList
    {
        public const string guidMyPackagePkgString = "b6c54c29-a4bf-4df6-ad09-446f49a252bb";
        public const string guidMyPackageCmdSetString = "00bdb82e-0813-45b7-8082-8ee3d804d5cb";
        public const string guidMyPackageProjectString = "fadb3c43-90d7-4c39-b428-21d37e24e150";
        public const string guidMyPackageProjectFactoryString = "623d0e1f-19c4-44c5-8f4f-483b71d0e2e7";

        public static readonly Guid guidMyPackageCmdSet = new Guid(guidMyPackageCmdSetString);
    };
}