using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

using ODeer.Plugin.Admin.Helper;
using ODeer.Plugin.Admin.ViewModels;
using ODeer.Plugin.Mvc;

using UIShell.BundleManagementService;
using UIShell.OSGi;
using UIShell.PageFlowService;

namespace ODeer.Plugin.Admin
{
    public class BundleActivator : IBundleActivator
    {
        public static IBundle Bundle { get; private set; }

        public static ServiceTracker<IPageFlowService> PageFlowServiceTracker { get; private set; }

        public static ServiceTracker<IBundleManagementService> BundleManagementServiceTracker { get; private set; }

        public static NavigationModel NavigationModel { get; private set; }

        public void Start(IBundleContext context)
        {
            Bundle = context.Bundle;
            PageFlowServiceTracker = new ServiceTracker<IPageFlowService>(context);
            BundleManagementServiceTracker = new ServiceTracker<IBundleManagementService>(context);
            //初始化菜单数据
            NavigationModel = new NavigationModel(context.Bundle);

            DefaultConfig.RegisterBundleNamespaces(context.Bundle.SymbolicName, GetType().Assembly);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void Stop(IBundleContext context)
        { }
    }
}