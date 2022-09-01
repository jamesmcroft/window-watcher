namespace WindowWatcher;

/// <summary>
/// Provides data for the window changed event
/// </summary>
public class WindowChangedEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowChangedEventArgs"/> class with the new window.
    /// </summary>
    /// <param name="newWindow">The new <see cref="Window"/> that has been changed to.</param>
    public WindowChangedEventArgs(Window? newWindow)
    {
        NewWindow = newWindow;
    }

    /// <summary>
    /// Gets the new <see cref="Window"/> that has been changed to.
    /// </summary>
    public Window? NewWindow { get; }
}