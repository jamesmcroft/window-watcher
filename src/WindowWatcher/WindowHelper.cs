using System.Runtime.InteropServices;
using System.Text;

namespace WindowWatcher;

public static class WindowHelper
{
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