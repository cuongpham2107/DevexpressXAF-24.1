

using DevExpress.ExpressApp.Actions;
using DXApp24.Module.BusinessObjects;
using DXApp24.Module.Extension;

namespace DXApplication.Module.Controllers;
public class SampleController : CustomController
{
    public SampleController()
    {
        // simple action 1
        SimpleAction action = CreateAction(ActionType.Simple,
                                  caption: "Press me!",
                                  toolTip: "You can press me now") as SimpleAction;
        action.Execute += (s, e) => {
            Application.ShowViewStrategy.ShowMessage("Hi! You've pressed me!");
        };

        // simple action 2
        SimpleAction action2 = CreateAction(ActionType.Simple,
                                  caption: "Press me again!",
                                  toolTip: "You can press me now") as SimpleAction;
        action2.Execute += (s, e) => {
            Application.ShowViewStrategy.ShowMessage("Hi! You've pressed me!");
        };

        // single choice action
        var action3 = CreateAction(ActionType.SingleChoice, caption: "Single choice action") as SingleChoiceAction;
        SetSingleChoiceAction(action3, new ChoiceActionItem[] {
            new ("Choice 1", null),
            new ("Choice 2", null),
            new ("Choice 3", null),
            new ("Choice 4", null),
        });
        action3.Execute += (s, e) => {
            Application.ShowViewStrategy.ShowMessage($"Hi! You've chosen {e.SelectedChoiceActionItem.Caption}!");
        };

        // popup action with detail view
        var action4 = CreateAction(ActionType.Popup, caption: "Show popup", objectType: typeof(Personnel), selectionType: SelectionDependencyType.RequireSingleObject) as PopupWindowShowAction;
        action4.CustomizePopupWindowParams += (s, e) => {
            e.View = CreateDetailView(View.CurrentObject);
        };
        action4.Execute += (s, e) => {
            var item = e.PopupWindowViewCurrentObject as Personnel;
            Application.ShowViewStrategy.ShowMessage($"Current person: {item.FullName}");
        };

        // popup action with picker detail view
        var action5 = CreateAction(ActionType.Popup, caption: "Picker") as PopupWindowShowAction;
        action5.CustomizePopupWindowParams += (s, e) => {
            e.View = CreatePickerDetailView<DateTimePicker>();
        };
        action5.Execute += (s, e) => {
            var item = e.PopupWindowViewCurrentObject as DateTimePicker;
            Application.ShowViewStrategy.ShowMessage($"Selected date: {item.Value}");
        };

        // popup action with lookup / list view
        var action6 = CreateAction(ActionType.Popup, caption: "Show person") as PopupWindowShowAction;
        action6.CustomizePopupWindowParams += (s, e) => {
            e.View = CreateListView<Personnel>(out var source);
        };
        action6.Execute += (s, e) => {
            var item = e.PopupWindowViewCurrentObject as Personnel;
            Application.ShowViewStrategy.ShowMessage($"Selected date: {item.FullName}");
        };

        // import from csv action
        ImportAction<Division>((i, r) => {
            Get<string>("Name", r, o => i.Name = o);
            Get<string>("Office", r, o => i.Office = o);

        }, "Division", new() { Header = "Name, Office" });
    }
}

