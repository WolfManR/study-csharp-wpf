using System;
using System.Windows;
using Thundire.MVVM.Core.Observable;

namespace Gu_Wpf_Localization_TestApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = VM = TestVM.Create("Local");
        }

        public TestVM VM { get; set; }

        private void SwitchMessage(object sender, RoutedEventArgs e)
        {
            VM.Status = VM.Status switch
                        {
                            NoticeStatus.Hide    => NoticeStatus.Success,
                            NoticeStatus.Success => NoticeStatus.Fail,
                            NoticeStatus.Fail    => NoticeStatus.Warning,
                            NoticeStatus.Warning => NoticeStatus.Hide,
                            _                    => NoticeStatus.Hide
                        };
        }
    }
}
