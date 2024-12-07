
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DXApp24.Module.Commons;

namespace DXApp24.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("Mẫu email")]
    [NavigationItem(Menu.MenuMail)]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class EmailTemplate : BaseObject
    {
        public EmailTemplate(Session session) : base(session) { }

        string name;
        [XafDisplayName("Tên mẫu"), ToolTip("")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        string header;
        [XafDisplayName("Tiêu đề"), ToolTip("")]
        public string Header
        {
            get => header;
            set => SetPropertyValue(nameof(Header), ref header, value);
        }

        string body;
        [XafDisplayName("Nội dung"), ToolTip(""), Size(SizeAttribute.Unlimited)]
        public string Body
        {
            get => body;
            set => SetPropertyValue(nameof(Body), ref body, value);
        }
    }


}