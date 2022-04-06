using System;
using System.Text.Json;

namespace NodeEditor.UI.ViewModels;

public class Rectangle : Drawable, ICloneable, IGroupable
{
    private Group _group;

    public Group Group { get => _group; set => IsDraggable = value != null; }

    public object Clone() => JsonSerializer.Deserialize<Rectangle>(JsonSerializer.Serialize(this));
}