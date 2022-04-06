﻿using System;
using System.Windows;

namespace NodeEditor.UI.Services;

public class DialogService
{
    public void OpenDialog<T>(object dataContext) where T : Window
    {
        var window = Activator.CreateInstance<T>();
        window.DataContext = dataContext;
        window.ShowDialog();
    }
}