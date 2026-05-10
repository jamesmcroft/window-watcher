namespace WindowWatcher.Tests;

/// <summary>
/// Integration tests for WindowHelper that validate P/Invoke calls
/// work correctly on the running architecture (x64, ARM64).
/// </summary>
public class WindowHelperIntegrationTests
{
    [Fact]
    public void GetCurrentForegroundWindow_DoesNotThrow()
    {
        var exception = Record.Exception(() => WindowHelper.GetCurrentForegroundWindow());

        Assert.Null(exception);
    }

    [Fact]
    public void GetCurrentForegroundWindow_WhenWindowExists_ReturnsWindowWithNonZeroHandle()
    {
        var window = WindowHelper.GetCurrentForegroundWindow();

        // In CI or headless environments, there may not be a titled foreground window.
        // If a window is returned, validate it has a valid handle and title.
        if (window is not null)
        {
            Assert.NotEqual(IntPtr.Zero, window.Handle);
            Assert.False(string.IsNullOrEmpty(window.Title));
        }
    }
}
