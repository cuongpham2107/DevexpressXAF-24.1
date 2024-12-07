using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Map.Native;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace DXApp24.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
    public partial class CustomShowNavigationControllercs : WindowController
    {

        private ShowNavigationItemController navigationController;

        protected override void OnFrameAssigned()
        {
            UnsubscribeFromEvents();
            base.OnFrameAssigned();
            navigationController = Frame.GetController<ShowNavigationItemController>();
            if (navigationController != null)
            {
                navigationController.NavigationItemCreated += NavigationItemCreated;
            }
        }
        void NavigationItemCreated(object sender, NavigationItemCreatedEventArgs e)
        {
            //e.NavigationItem.ImageName = $"IImageService/{e.NavigationItem.ImageName}";
            e.NavigationItem.ImageName = e.NavigationItem.ImageName;


        }
        private void UnsubscribeFromEvents()
        {
            if (navigationController != null)
            {
                navigationController.NavigationItemCreated -= NavigationItemCreated;
                navigationController = null;
            }
        }

    }
}
