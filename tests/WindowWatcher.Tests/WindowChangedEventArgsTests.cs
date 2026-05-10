namespace WindowWatcher.Tests;

public class WindowChangedEventArgsTests
{
    [Fact]
    public void Constructor_SetsNewWindow()
    {
        var window = new Window(new IntPtr(1), "Test");
        var args = new WindowChangedEventArgs(window);

        Assert.Equal(window, args.NewWindow);
    }

    [Fact]
    public void Constructor_WithNull_SetsNullNewWindow()
    {
        var args = new WindowChangedEventArgs(null);

        Assert.Null(args.NewWindow);
    }
}
