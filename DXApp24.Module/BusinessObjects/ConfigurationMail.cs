
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApp24.Module.Commons;

namespace DXApp24.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("Cấu hình Mail")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [NavigationItem(Menu.MenuMail)]
    [RuleObjectExists("AnotherSingletonExists", DefaultContexts.Save, "True", InvertResult = true,
    CustomMessageTemplate = "Chỉ tạo được một bản ghi.")]

    public class ConfigurationMail : BaseObject
    {
        public ConfigurationMail(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string mAIL_ENCRYPTION;
        string mAIL_PASSWORD;
        string mAIL_USERNAME;
        int mAIL_PORT;
        string mAIL_HOST;
        string mAIL_DRIVER;

        public string MAIL_DRIVER
        {
            get => mAIL_DRIVER;
            set => SetPropertyValue(nameof(MAIL_DRIVER), ref mAIL_DRIVER, value);
        }

        public string MAIL_HOST
        {
            get => mAIL_HOST;
            set => SetPropertyValue(nameof(MAIL_HOST), ref mAIL_HOST, value);
        }

        public int MAIL_PORT
        {
            get => mAIL_PORT;
            set => SetPropertyValue(nameof(MAIL_PORT), ref mAIL_PORT, value);
        }

        public string MAIL_USERNAME
        {
            get => mAIL_USERNAME;
            set => SetPropertyValue(nameof(MAIL_USERNAME), ref mAIL_USERNAME, value);
        }

        public string MAIL_PASSWORD
        {
            get => mAIL_PASSWORD;
            set => SetPropertyValue(nameof(MAIL_PASSWORD), ref mAIL_PASSWORD, value);
        }
        
        public string MAIL_ENCRYPTION
        {
            get => mAIL_ENCRYPTION;
            set => SetPropertyValue(nameof(MAIL_ENCRYPTION), ref mAIL_ENCRYPTION, value);
        }
    }
}