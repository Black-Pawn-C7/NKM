using NKM.Base.Common.Ioc;

namespace NKM.Base {
    public static class Global {
        public static IocFactory Ioc { get; } = new IocFactory();
    }
}