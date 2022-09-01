namespace WindowWatcher;

using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// Defines a helper class for interacting with the user32.dll windowing APIs.
/// </summary>
public static class WindowHelper
{
    /// <summary>
    /// Gets the current foreground (active) window.
    /// </summary>
    /// <returns>The <see cref="Window"/> that represents the current foreground (active) window.</returns>
    public static Window? GetCurrentForegroundWindow()
    {
        var handle = GetForegroundWindow();

        var bufferSize = GetWindowTextLength(handle) + 1;
        var buffer = new StringBuilder(bufferSize);

        return GetWindowText(handle, buffer, bufferSize) > 0 ? new Window(handle, buffer.ToString()) : null;
    }

    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    private static extern int GetWindowTextLength(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
}