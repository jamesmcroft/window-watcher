namespace WindowWatcher;

public class WindowChangedEventArgs : EventArgs
{
    public WindowChangedEventArgs(Window? newWindow)
    {
        NewWindow = newWindow;
    }

    public Window? NewWindow { get; }
}