using System;
using Microsoft.AspNetCore.Http;
using NKM.Base.Definition.Business.Service;

namespace NKM.Base.UI.Application {
    public class AppState {
        protected static IHttpContextAccessor httpContextAccessor;
        public static HttpContext HttpContext => httpContextAccessor?.HttpContext;

        public static IConfigurationService ConfigurationService { get; set; }

        internal static IServiceProvider ServiceProvider { get; private set; }

        internal static IServiceProvider MigrationServiceProvider { get; set; }

        internal static Func<ISession> CreateNHibernateSession { get; set; }

        public static void SetServiceProvider(IServiceProvider serviceProvider) {
            ServiceProvider = serviceProvider ?? throw new ArgumentNullException();

            httpContextAccessor = (IHttpContextAccessor) serviceProvider.GetService(typeof(IHttpContextAccessor));

            if (httpContextAccessor == null) throw new ArgumentNullException(nameof(httpContextAccessor), "HttpContextAccessorNotRegistered");
        }

        public static void ResetMigrationServiceProvider() {
            MigrationServiceProvider = null;
        }
    }
}