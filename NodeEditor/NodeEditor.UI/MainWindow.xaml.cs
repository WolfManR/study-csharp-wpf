using NodeEditor.UI.Helpers;

using System.Windows;

namespace NodeEditor.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void OnScrolling(object sender, RoutedEventArgs e) => AttachedAdorner.OnScrolling();
    }
}
