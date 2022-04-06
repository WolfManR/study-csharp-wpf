using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Xaml.Behaviors;
using NodeEditor.UI.ViewModels;
using RichCanvas;
using RichCanvas.Helpers;

namespace NodeEditor.UI.Helpers;

public class GroupBehavior : Behavior<System.Windows.Shapes.Rectangle>
{
    private RichItemContainer ItemContainer => VisualHelper.GetParentContainer(AssociatedObject);
    private Group GroupDataContext => ItemContainer.DataContext as Group;
    protected override void OnAttached()
    {
        ItemContainer.Host.DrawingEnded += Host_DrawingEnded;
    }

    private void RotateTransform_Changed(object sender, System.EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void Host_DrawingEnded(object sender, RoutedEventArgs e)
    {
        if (GroupDataContext != null)
        {
            List<object> intersectedElements = ItemContainer.Host.GetElementsInArea(new Rect(ItemContainer.Left, ItemContainer.Top, ItemContainer.Width, ItemContainer.Height));
            GroupDataContext.SetGroupedElements(intersectedElements.OfType<Drawable>().Where(d => !(d is Group) && d is IGroupable).ToArray());
            GroupDataContext.SetGroupSize();
        }
    }

}