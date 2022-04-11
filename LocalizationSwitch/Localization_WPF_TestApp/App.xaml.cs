using System.Windows;
using Localization.WPF;
using Localization_WPF_TestApp.Properties;

namespace Localization_WPF_TestApp;

public partial class App : Application
{
    public App()
    {
        SetCulture();
    }

    private static void SetCulture()
    {
        LocalizationManager.CultureChanging += UpdateResourcesCultures;
        LocalizationManager.CultureChanged += SaveSelectedCulture;

        var lastCulture = Settings.Default.Culture;
        var culture = lastCulture == string.Empty ? "en-ES" : lastCulture;

        LocalizationManager.ChangeCulture(culture);
    }

    private static void SaveSelectedCulture(object? sender, LocalizationManager.CultureChangedEventArgs e)
    {
        Settings.Default.Culture = e.NewCulture.Name;
        Settings.Default.Save();
    }

    private static void UpdateResourcesCultures(object? sender, LocalizationManager.CultureChangedEventArgs e)
    {
        var culture = e.NewCulture;
        Localization_WPF_TestApp.Properties.Resources.Culture = culture;
    }
}