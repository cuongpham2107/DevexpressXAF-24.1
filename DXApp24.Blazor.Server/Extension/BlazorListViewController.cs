﻿using DevExpress.Blazor;
using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.Native;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Blazor.SystemModule;
using DevExpress.ExpressApp.Dashboards.Blazor.Controllers;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.BaseImpl;
using DXApp24.Module.Extension;
using System.Reflection;

namespace DXApp24.Blazor.Server.Controllers;

/// <summary>
/// TODO: điều chỉnh chung cho tất cả blazor list view
/// </summary>
public class BlazorListViewController : ViewController<ListView> {

    protected override void OnViewControlsCreated() {
        base.OnViewControlsCreated();

        //TODO: điều chỉnh cách hiển thị của DxGridListEditor
        if (View.Editor.Control is DxGridAdapter adapter) {
            adapter.GridModel.ColumnResizeMode = GridColumnResizeMode.NextColumn;
            adapter.GridModel.FooterDisplayMode = GridFooterDisplayMode.Auto;
            adapter.GridModel.AutoExpandAllGroupRows = true;
            adapter.GridModel.ShowFilterRow = true;
            adapter.GridModel.ShowGroupPanel = true;
            adapter.GridModel.ShowSearchBox = true;
            adapter.GridModel.EditNewRowPosition = GridEditNewRowPosition.Top;
            adapter.GridCommandColumnModel.Visible = true;
            //adapter.GridCommandColumnModel.ShowInColumnChooser = true;
            //adapter.GridSelectionColumnModel.ShowInColumnChooser = true;
            adapter.GridSelectionColumnModel.AllowSelectAll = true;
            

            var attr = View.ObjectTypeInfo.Type.GetCustomAttribute<CustomListViewColumnWidthAttribute>();
            if (attr != null) {
                foreach (string column in attr.ColumnWidths) {
                    var items = column.Split(':');
                    var field = items[0];
                    var width = items[1];
                    var columnModel = adapter.GridDataColumnModels.FirstOrDefault(cm => cm.FieldName == field);
                    if (columnModel != null && !string.IsNullOrEmpty(width)) {
                        columnModel.Width = width;
                    }
                }
            }
        }
    }

    protected override void OnActivated() {
        base.OnActivated();

        // mặc định ẩn full text search vì đã có searchbox của blazor grid
        var _filterController = Frame.GetController<FilterController>();
        _filterController?.FullTextFilterAction.Active.SetItemValue("Disable", false);
    }
}
