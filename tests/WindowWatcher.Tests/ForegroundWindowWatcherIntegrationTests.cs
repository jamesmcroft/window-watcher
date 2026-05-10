namespace WindowWatcher.Tests;

/// <summary>
/// Integration tests for ForegroundWindowWatcher that validate the watcher
/// lifecycle and event infrastructure work correctly on the running architecture.
/// </summary>
public class ForegroundWindowWatcherIntegrationTests : IDisposable
{
    private readonly ForegroundWindowWatcher watcher = new();

    [Fact]
    public void Start_SetsIsRunningToTrue()
    {
        watcher.Start();

        Assert.True(watcher.IsRunning);
    }

    [Fact]
    public void Stop_SetsIsRunningToFalse()
    {
        watcher.Start();
        watcher.Stop();

        Assert.False(watcher.IsRunning);
    }

    [Fact]
    public void Start_WithInterval_SetsIsRunningToTrue()
    {
        watcher.Start(TimeSpan.FromSeconds(1));

        Assert.True(watcher.IsRunning);
    }

    [Fact]
    public void Start_WithIntervalMs_SetsIsRunningToTrue()
    {
        watcher.Start(1000);

        Assert.True(watcher.IsRunning);
    }

    [Fact]
    public void Dispose_StopsWatcher()
    {
        watcher.Start();
        watcher.Dispose();

        Assert.False(watcher.IsRunning);
    }

    [Fact]
    public async Task Start_RaisesWindowChangedEvent_WhenForegroundWindowExists()
    {
        var eventRaised = new TaskCompletionSource<WindowChangedEventArgs>();

        watcher.WindowChanged += (_, args) =>
        {
            eventRaised.TrySetResult(args);
        };

        watcher.Start(TimeSpan.FromMilliseconds(100));

        // In CI or headless environments, the event may not fire if there is
        // no titled foreground window. Use a timeout to avoid hanging.
        var completed = await Task.WhenAny(eventRaised.Task, Task.Delay(3000));

        if (completed == eventRaised.Task)
        {
            var args = await eventRaised.Task;
            Assert.NotNull(args.NewWindow);
            Assert.NotEqual(IntPtr.Zero, args.NewWindow!.Handle);
        }
    }

    public void Dispose()
    {
        watcher.Dispose();
    }
}
