using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DXApp24.Module.Commons;
using DXApp24.Module.Extension;

namespace DXApp24.Module.BusinessObjects;

/// <summary>
/// Resource for person
/// </summary>
[DefaultClassOptions]
[NavigationItem(Menu.MenuExample)]

public class Document : BaseObject, IListViewPopup, INestedListViewInline {
    public Document(Session session) : base(session) { }

    string _name;
    [XafDisplayName("")]
    public string Name {
        get => _name;
        set => SetPropertyValue(nameof(Name), ref _name, value);
    }

    FileData _fileData;
    [XafDisplayName("")]
    public FileData FileData {
        get => _fileData;
        set => SetPropertyValue(nameof(FileData), ref _fileData, value);
    }

    string _link;
    [XafDisplayName("")]
    public string Link {
        get => _link;
        set => SetPropertyValue(nameof(Link), ref _link, value);
    }

    Personnel _personnel;
    [XafDisplayName("")]
    [Association("Personnel-Resources")]
    public Personnel Personnel {
        get => _personnel;
        set => SetPropertyValue(nameof(Personnel), ref _personnel, value);
    }

    string _description;
    [XafDisplayName("")]
    public string Description {
        get => _description;
        set => SetPropertyValue(nameof(Description), ref _description, value);
    }
}
