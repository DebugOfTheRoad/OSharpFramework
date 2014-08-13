using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using ODeer.Plugin.Mvc;

using UIShell.NavigationService;


namespace ODeer.Hosting.Web
{
    public class MvcApplication : BundleRuntimeMvcApplication
    {
        public static IEnumerable<NavigationNode> NavigationNodes { get; set; }

        protected override void Application_Start(object sender, EventArgs e)
        {
            Assembly hostAssembly = Assembly.GetExecutingAssembly();
            Assembly[] hostDependencyAssemblies = hostAssembly.GetReferencedAssemblies()
                .Where(m => m.Name.Contains("ODeer")).Select(Assembly.Load).ToArray();
            IoCBundleActivator.HostingAssemblyFunc = () => new[] { hostAssembly }.Union(hostDependencyAssemblies).ToArray();
            DefaultConfig.RegisterHostingNamespaces(hostAssembly);

            base.Application_Start(sender, e);

            //DatabaseInitializer.Initialize();

            NavigationNodes = NavigationInitialize();
        }

        public override void RegisterResourceBundles()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleAjaxErrorAttribute());
            base.RegisterGlobalFilters(filters);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = HttpContext.Current.Server.GetLastError();
        }

        private IEnumerable<NavigationNode> NavigationInitialize()
        {
            INavigationService service = BundleRuntime.GetFirstOrDefaultService<INavigationService>();
            if (service == null)
            {
                return new List<NavigationNode>();
            }
            return service.NavgationNodes;
        }
    }
}
