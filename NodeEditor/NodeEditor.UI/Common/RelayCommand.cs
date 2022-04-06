using System;
using System.Windows.Input;

namespace NodeEditor.UI.Common;

public class RelayCommand<T> : ICommand
{
    private readonly Action<T?> _execute;
    private readonly Func<T?, bool>? _canExecute;

    public event EventHandler? CanExecuteChanged;

    public RelayCommand(Action<T?> execute, Func<T?, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        var condition = _canExecute?.Invoke(parameter is null ? default : (T)parameter);
        return !condition.HasValue || condition.Value;
    }

    public void Execute(object? parameter)
        => _execute.Invoke(parameter is null ? default : (T)parameter);
}

public class RelayCommand : ICommand
{
    private readonly Func<bool>? _canExecute;
    private readonly Action _execute;

    public event EventHandler? CanExecuteChanged;
    public RelayCommand(Action execute, Func<bool>? canExecute = default)
    {
        _canExecute = canExecute;
        _execute = execute;
    }
    public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;

    public void Execute(object? parameter) => _execute.Invoke();

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}