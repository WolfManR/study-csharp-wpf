using System.Windows.Media;
using static System.Windows.Media.Colors;
using CSharpMarkup.Wpf;
using static CSharpMarkup.Wpf.Helpers;

using Button_UI = System.Windows.Controls.Button;

namespace DeclarativeWPF.UI.Resources;

public static class ButtonStyles
{
    private static Style<Button>? _symbolButton;
    public static Style<Button> SymbolButton => _symbolButton ??= new Style<Button>(
        (Button_UI.FontFamilyProperty, new FontFamily("Segoe MDL2 Assets")),
        (Button_UI.ForegroundProperty, Green)
        );
}