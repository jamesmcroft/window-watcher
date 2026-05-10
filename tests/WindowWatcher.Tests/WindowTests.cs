namespace WindowWatcher.Tests;

public class WindowTests
{
    [Fact]
    public void Empty_HasZeroHandleAndEmptyTitle()
    {
        var window = Window.Empty;

        Assert.Equal(IntPtr.Zero, window.Handle);
        Assert.Equal(string.Empty, window.Title);
    }

    [Fact]
    public void Constructor_SetsProperties()
    {
        var handle = new IntPtr(12345);
        var title = "Test Window";

        var window = new Window(handle, title);

        Assert.Equal(handle, window.Handle);
        Assert.Equal(title, window.Title);
    }

    [Fact]
    public void Equals_SameHandleAndTitle_ReturnsTrue()
    {
        var window1 = new Window(new IntPtr(1), "Title");
        var window2 = new Window(new IntPtr(1), "Title");

        Assert.True(window1.Equals(window2));
    }

    [Fact]
    public void Equals_DifferentHandle_ReturnsFalse()
    {
        var window1 = new Window(new IntPtr(1), "Title");
        var window2 = new Window(new IntPtr(2), "Title");

        Assert.False(window1.Equals(window2));
    }

    [Fact]
    public void Equals_DifferentTitle_ReturnsFalse()
    {
        var window1 = new Window(new IntPtr(1), "Title A");
        var window2 = new Window(new IntPtr(1), "Title B");

        Assert.False(window1.Equals(window2));
    }

    [Fact]
    public void Equals_NullWindow_ReturnsFalse()
    {
        var window = new Window(new IntPtr(1), "Title");

        Assert.False(window.Equals((Window?)null));
    }

    [Fact]
    public void Equals_SameReference_ReturnsTrue()
    {
        var window = new Window(new IntPtr(1), "Title");

        Assert.True(window.Equals(window));
    }

    [Fact]
    public void Equals_Object_SameValues_ReturnsTrue()
    {
        var window1 = new Window(new IntPtr(1), "Title");
        object window2 = new Window(new IntPtr(1), "Title");

        Assert.True(window1.Equals(window2));
    }

    [Fact]
    public void Equals_Object_DifferentType_ReturnsFalse()
    {
        var window = new Window(new IntPtr(1), "Title");

        Assert.False(window.Equals("not a window"));
    }

    [Fact]
    public void Equals_Object_Null_ReturnsFalse()
    {
        var window = new Window(new IntPtr(1), "Title");

        Assert.False(window.Equals((object?)null));
    }

    [Fact]
    public void Equals_Object_SameReference_ReturnsTrue()
    {
        var window = new Window(new IntPtr(1), "Title");

        Assert.True(window.Equals((object)window));
    }

    [Fact]
    public void GetHashCode_EqualWindows_ReturnsSameHashCode()
    {
        var window1 = new Window(new IntPtr(1), "Title");
        var window2 = new Window(new IntPtr(1), "Title");

        Assert.Equal(window1.GetHashCode(), window2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_DifferentWindows_ReturnsDifferentHashCode()
    {
        var window1 = new Window(new IntPtr(1), "Title A");
        var window2 = new Window(new IntPtr(2), "Title B");

        Assert.NotEqual(window1.GetHashCode(), window2.GetHashCode());
    }
}
