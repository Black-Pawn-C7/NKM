using System;
using System.Collections.Generic;
using System.Linq;
using NKM.Base.Definition.Enums;
using NKM.Base.UI.Application;
using SimpleInjector;

namespace NKM.Base.Common.Ioc {
    public class IocFactory {
        private static readonly IDictionary<Lifecycle, Lifestyle> lifecycleMapper = new Dictionary<Lifecycle, Lifestyle> {
            {Lifecycle.Singleton, Lifestyle.Singleton},
            {Lifecycle.Scoped, Lifestyle.Scoped},
            {Lifecycle.Transient, Lifestyle.Transient}
        };

        private Container container;

        public IocFactory() {
            container = GetDefaultContainer();
        }

        public void Reset() {
            container.Dispose();
            container = GetDefaultContainer();
        }

        public Type GetMappedType(Type type) {
            return container.GetRegistration(type).Registration.ImplementationType;
        }

        public Type GetMappedType<T>() {
            return GetMappedType(typeof(T));
        }

        public void Register<TInterface, TClass>(Lifecycle lifecycle = Lifecycle.Transient) where TInterface : class where TClass : class, TInterface {
            container.Register<TInterface, TClass>(lifecycleMapper[lifecycle]);
        }

        public void Register(Type interfaceType, Type implementationType, Lifecycle lifecycle = Lifecycle.Transient) {
            container.Register(interfaceType, implementationType, lifecycleMapper[lifecycle]);
        }

        public void RegisterSingleton<TInterface, TClass>() where TInterface : class where TClass : class, TInterface {
            container.RegisterSingleton<TInterface, TClass>();
        }

        public void Register<TClass>(Lifecycle lifecycle = Lifecycle.Transient) where TClass : class {
            container.Register<TClass>(lifecycleMapper[lifecycle]);
        }

        public void Register<T>(Func<T> generator, Lifecycle lifecycle = Lifecycle.Transient) where T : class {
            container.Register(generator, lifecycleMapper[lifecycle]);
        }

        public void RegisterSingleton<T>(Func<T> generator) where T : class {
            container.RegisterSingleton(generator);
        }

        public T GetInstance<T>() where T : class {
            return container.GetInstance<T>();
        }

        public IList<object> GetAllInstances() {
            return container.GetCurrentRegistrations().Select(registration => registration.GetInstance()).ToList();
        }

        protected virtual ScopedLifestyle ScopedLifestyleFactory() {
            return new WebRequestLifecycle(() => AppState.HttpContext);
        }

        private Container GetDefaultContainer() {
            var defaultContainer = new Container();
            defaultContainer.Options.DefaultScopedLifestyle = ScopedLifestyleFactory();

            return defaultContainer;
        }
    }
}