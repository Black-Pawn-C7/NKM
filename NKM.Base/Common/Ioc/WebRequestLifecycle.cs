using System;
using Microsoft.AspNetCore.Http;
using SimpleInjector;

namespace NKM.Base.Common.Ioc {
    public class WebRequestLifecycle : ScopedLifestyle {
        private static readonly object ScopeKey = new object();
        private readonly Func<HttpContext> httpContextAccessor;

        public WebRequestLifecycle(Func<HttpContext> httpContextAccessor) : base("Web Request") {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override Scope GetCurrentScopeCore(Container container) {
            return GetOrCreateScope();
        }

        protected override Func<Scope> CreateCurrentScopeProvider(Container container) {
            if (container == null) throw new ArgumentNullException(nameof(container));

            return GetOrCreateScope;
        }

        public static void CleanUpWebRequest(HttpContext context) {
            if (context == null || !context.Items.TryGetValue(ScopeKey, out var scope)) return;
            ((Scope) scope)?.Dispose();
        }

        private Scope GetOrCreateScope() {
            var context = httpContextAccessor.Invoke();

            if (context == null) return null;

            if (!context.Items.ContainsKey(ScopeKey)) context.Items[ScopeKey] = new Scope();

            return (Scope) context.Items[ScopeKey];
        }
    }
}