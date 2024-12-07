using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Blazor.SystemModule;
using DevExpress.ExpressApp.Blazor.Templates;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Xpo;
using DXApp24.Blazor.Server.Services;
using DXApp24.Blazor.Server.Templates;

namespace DXApp24.Blazor.Server;

public class DXApp24BlazorApplication : BlazorApplication {
    public DXApp24BlazorApplication() {
        ApplicationName = "ASGL";
        CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
        DatabaseVersionMismatch += DXApp24BlazorApplication_DatabaseVersionMismatch;

        // TODO: đặt kích thước popup windows bằng 60% bề rộng màn hình
        CustomizeTemplate += (s, e) => {
            if (e.Template is IPopupWindowTemplateSize size)
            {
                size.MaxWidth = "60vw"; // bề rộng popup luôn bằng 60% bề rộng khuôn hình
                //size.Width = "1000px";
                //size.MaxHeight = "70vh";
                //size.Height = "800px";
            }
        };
    }
    protected override IFrameTemplate CreateDefaultTemplate(TemplateContext context)
    {
        //Top navigation
        //if (context == TemplateContext.ApplicationWindow)
        //{
        //    return new CustomMainFormTemplate((IModelOptionsBlazor)Model.Options) { AboutInfoString = AboutInfo.Instance.GetAboutInfoString(this) };
        //}
        return base.CreateDefaultTemplate(context);
    }

    protected override void OnSetupStarted() {
        base.OnSetupStarted();
#if DEBUG
        if(System.Diagnostics.Debugger.IsAttached && CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema) {
            DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
        }
#endif
    }
    private void DXApp24BlazorApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e) {
#if EASYTEST
        e.Updater.Update();
        e.Handled = true;
#else
        if(System.Diagnostics.Debugger.IsAttached) {
            e.Updater.Update();
            e.Handled = true;
        }
        else {
            string message = "The application cannot connect to the specified database, " +
                "because the database doesn't exist, its version is older " +
                "than that of the application or its schema does not match " +
                "the ORM data model structure. To avoid this error, use one " +
                "of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

            if(e.CompatibilityError != null && e.CompatibilityError.Exception != null) {
                message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
            }
            throw new InvalidOperationException(message);
        }
#endif
    }
}
