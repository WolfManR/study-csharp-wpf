using System.Collections.Generic;

namespace NodeEditor.UI.ViewModels;

public interface IConnectable
{
    ICollection<Drawable> Connections { get; }

    bool IsParent { get; }

    Drawable Parent { get; set; }

    void Move(double offsetX, double offsetY);
}