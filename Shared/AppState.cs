using MudBlazor;

namespace WishVine.Shared;

public class AppState
{
    //State for Message Box
    public bool ShowMessageBox { get; set; } = false;
    public string Message { get; set; } = string.Empty;
    public Severity Severity { get; set; } = Severity.Info;

    public event Action MessageStateChanged = null!;

    public void SetMessage(string message, Severity severity)
    {
        Message = message;
        Severity = severity;
        ShowMessageBox = true;

        MessageStateChanged?.Invoke();
    }

    public void ClearMessage()
    {
        Message = string.Empty;
        Severity = Severity.Info;
        ShowMessageBox = false;

        MessageStateChanged?.Invoke();
    }


}