﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ODeer.Plugin.Mvc;

using UIShell.OSGi;
using UIShell.PageFlowService;


namespace ODeer.Plugin.Demo
{
    public class BundleActivator : IBundleActivator
    {
        public static IBundle Bundle { get; private set; }

        public static ServiceTracker<IPageFlowService> PageFlowServiceTracker { get; set; }

        public static PageNode LayoutPageNode
        {
            get { return PageFlowServiceTracker.DefaultOrFirstService.GetPageNode("LayoutPage"); }
        }

        public static PageNode GridLayoutPageNode
        {
            get { return PageFlowServiceTracker.DefaultOrFirstService.GetPageNode("GridLayoutPage"); }
        }

        public void Start(IBundleContext context)
        {
            Bundle = context.Bundle;
            PageFlowServiceTracker = new ServiceTracker<IPageFlowService>(context);
            DefaultConfig.RegisterBundleNamespaces(context.Bundle.SymbolicName, GetType().Assembly);
        }

        public void Stop(IBundleContext context)
        { }
    }
}