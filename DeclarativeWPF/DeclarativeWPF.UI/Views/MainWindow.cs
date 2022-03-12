using CSharpMarkup.Wpf;

using System.Windows.Media;

using static CSharpMarkup.Wpf.Helpers;

namespace DeclarativeWPF.UI.Views;

partial class MainWindow
{
    public void Build() => Content =

        Grid(
            Columns(120, Star),

            TextBlock("Hello World!")
                .FontSize(36)
                .Foreground(Colors.Black)
                .Grid_Column(1)
                .VCenter()
                .HCenter(),

            Button("Click me!")
                .Grid_Column(0)
            )
            .UI;
}

partial class MainWindow : System.Windows.Window
{
    public MainWindow()
    {
        Build();
    }
}