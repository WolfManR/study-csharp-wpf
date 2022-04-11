using System.Windows;

namespace Localization_WPF_TestApp;

public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();


    private void ClearForm(object sender, RoutedEventArgs e)
    {
        Firstname.Text = Lastname.Text = Age.Text = string.Empty;
    }
}