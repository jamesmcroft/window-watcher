namespace WindowWatcher;

using System.Runtime.InteropServices;

/// <summary>
/// Defines a helper class for interacting with the user32.dll windowing APIs.
/// </summary>
public static partial class WindowHelper
{
    /// <summary>
    /// Gets the current foreground (active) window.
    /// </summary>
    /// <returns>The <see cref="Window"/> that represents the current foreground (active) window.</returns>
    public static Window? GetCurrentForegroundWindow()
    {
        var handle = GetForegroundWindow();

        var bufferSize = GetWindowTextLength(handle) + 1;
        var buffer = new char[bufferSize];

        var length = GetWindowText(handle, buffer, bufferSize);
        return length > 0 ? new Window(handle, new string(buffer, 0, length)) : null;
    }

    [LibraryImport("user32.dll")]
    private static partial IntPtr GetForegroundWindow();

    [LibraryImport("user32.dll", EntryPoint = "GetWindowTextLengthW")]
    private static partial int GetWindowTextLength(IntPtr hWnd);

    [LibraryImport("user32.dll", EntryPoint = "GetWindowTextW", StringMarshalling = StringMarshalling.Utf16)]
    private static partial int GetWindowText(IntPtr hWnd, [Out] char[] lpString, int nMaxCount);
}