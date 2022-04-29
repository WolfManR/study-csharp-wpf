using Gu.Localization;

using Thundire.MVVM.Core.Observable;

namespace Gu_Wpf_Localization_TestApp;

public class TestVM : NotifyBase
{
    private string _messageKey;
    private NoticeStatus _status = NoticeStatus.Success;
    private string? _message;

    public NoticeStatus Status
    {
        get => _status;
        set => Set(ref _status, value).DoOnSuccess(_ => UpdateViewTranslation());
    }
    
    public string? Message { get => _message; set => Set(ref _message, value); }

    public string MessageKey { get => $"{_messageKey}_{Status}"; init => _messageKey = value; }


    private TestVM()
    {
        Translator.CurrentCultureChanged += UpdateViewTranslation;
    }

    public static TestVM Create(string messageKey)
    {
        var vm = new TestVM(){ MessageKey = messageKey };
        vm.UpdateViewTranslation();
        return vm;
    }

    private void UpdateViewTranslation(object? sender, CultureChangedEventArgs e)
    {
        UpdateViewTranslation();
    }

    private void UpdateViewTranslation()
    {
        if (Status == NoticeStatus.Hide)
        {
            Message = string.Empty;
            return;
        }

        Message = Translator.Translate(Properties.Resources.ResourceManager, MessageKey);
    }
}