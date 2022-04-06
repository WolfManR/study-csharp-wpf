using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NodeEditor.UI.Common;

public class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(property, value)) return;
        property = value;
        OnPropertyChanged(propertyName);
    }

    protected virtual void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}